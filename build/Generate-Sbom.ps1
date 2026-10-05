param(
    [Parameter(Mandatory = $true)]
    [string]$PackageRoot,

    [string]$Version
)

$ErrorActionPreference = 'Stop'

$packagePath = (Resolve-Path -LiteralPath $PackageRoot).Path
$metadataPath = Join-Path $packagePath 'metadata'
$windowsPath = Join-Path $packagePath 'win'
$yamlPath = Join-Path $metadataPath 'LoupedeckPackage.yaml'
$inventoryPath = Join-Path (Split-Path $PSScriptRoot -Parent) 'FOSS-LICENSES.json'
$outputPath = Join-Path $metadataPath 'sbom.cdx.json'

if (-not (Test-Path -LiteralPath $yamlPath -PathType Leaf)) {
    throw "Plugin metadata not found: $yamlPath"
}
if (-not (Test-Path -LiteralPath $windowsPath -PathType Container)) {
    throw "Windows package directory not found: $windowsPath"
}

$inventory = Get-Content -LiteralPath $inventoryPath -Raw | ConvertFrom-Json
$componentsByFile = @{}
foreach ($component in $inventory.components) {
    $componentsByFile[$component.fileName.ToLowerInvariant()] = $component
}

if (-not $Version) {
    $metadataText = Get-Content -LiteralPath $yamlPath -Raw
    $versionMatch = [regex]::Match($metadataText, '(?m)^version:\s*(\S+)')
    if (-not $versionMatch.Success) {
        throw "Could not determine package version from $yamlPath"
    }
    $Version = $versionMatch.Groups[1].Value
}

$pluginDll = Join-Path $windowsPath 'AffinityPhoto2Plugin.dll'
if (-not (Test-Path -LiteralPath $pluginDll -PathType Leaf)) {
    throw "Plugin assembly not found: $pluginDll"
}

$dllFiles = @(Get-ChildItem -LiteralPath $windowsPath -Filter '*.dll' -File)
if ($dllFiles.Count -eq 0) {
    throw "No DLLs found in $windowsPath"
}

foreach ($dll in $dllFiles) {
    $entry = $componentsByFile[$dll.Name.ToLowerInvariant()]
    if (-not $entry) {
        throw "No FOSS/SBOM inventory entry for shipped DLL '$($dll.Name)'. Update FOSS-LICENSES.json after reviewing its license."
    }

    if ($entry.minimumAssemblyVersion) {
        $assemblyVersion = [System.Reflection.AssemblyName]::GetAssemblyName($dll.FullName).Version
        if ($assemblyVersion -lt [version]$entry.minimumAssemblyVersion) {
            throw "$($dll.Name) assembly version $assemblyVersion is older than required minimum $($entry.minimumAssemblyVersion). Rebuild against the current Logi Plugin Service SDK."
        }
    }
}

foreach ($entry in $inventory.components) {
    if ($entry.required -and -not (Test-Path -LiteralPath (Join-Path $windowsPath $entry.fileName) -PathType Leaf)) {
        throw "Required package component is missing: $($entry.fileName)"
    }
}

$bomComponents = [System.Collections.Generic.List[object]]::new()
$dependencyRefs = [System.Collections.Generic.List[string]]::new()
$pluginHash = (Get-FileHash -LiteralPath $pluginDll -Algorithm SHA256).Hash.ToLowerInvariant()
$pluginRef = "pkg:generic/affinity-photo2-plugin@$Version"

foreach ($dll in $dllFiles) {
    if ($dll.Name -ieq 'AffinityPhoto2Plugin.dll') {
        continue
    }

    $entry = $componentsByFile[$dll.Name.ToLowerInvariant()]
    $assembly = [System.Reflection.AssemblyName]::GetAssemblyName($dll.FullName)
    $fileVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dll.FullName).FileVersion
    $componentVersion = $assembly.Version.ToString()
    if ($fileVersion -match '^(\d+\.\d+\.\d+(?:\.\d+)?)') {
        $componentVersion = $Matches[1]
    }
    $packageName = [System.Uri]::EscapeDataString($entry.name.ToLowerInvariant())
    $bomRef = "pkg:generic/$packageName@$componentVersion"
    $component = [ordered]@{
        type = 'library'
        'bom-ref' = $bomRef
        name = $entry.name
        version = $componentVersion
        hashes = @(
            [ordered]@{
                alg = 'SHA-256'
                content = (Get-FileHash -LiteralPath $dll.FullName -Algorithm SHA256).Hash.ToLowerInvariant()
            }
        )
        properties = @(
            [ordered]@{ name = 'fileName'; value = "win/$($dll.Name)" }
        )
    }
    if ($entry.license) {
        $component.licenses = @(
            [ordered]@{ license = [ordered]@{ id = $entry.license } }
        )
    } else {
        $component.properties += [ordered]@{
            name = 'licenseStatus'
            value = $entry.licenseStatus
        }
    }
    if ($entry.sourceUrl) {
        $component.externalReferences = @(
            [ordered]@{
                type = 'website'
                url = $entry.sourceUrl
            }
        )
    }
    $bomComponents.Add($component)
    $dependencyRefs.Add($bomRef)
}

$packageFiles = Get-ChildItem -LiteralPath $packagePath -File -Recurse |
    Where-Object { $_.FullName -ne $outputPath -and $_.FullName -ne $pluginDll }
foreach ($file in $packageFiles) {
    $relativePath = [System.IO.Path]::GetRelativePath($packagePath, $file.FullName).Replace('\', '/')
    $bomComponents.Add([ordered]@{
        type = 'file'
        'bom-ref' = "file:$relativePath"
        name = $relativePath
        hashes = @(
            [ordered]@{
                alg = 'SHA-256'
                content = (Get-FileHash -LiteralPath $file.FullName -Algorithm SHA256).Hash.ToLowerInvariant()
            }
        )
    })
}

$bom = [ordered]@{
    bomFormat = 'CycloneDX'
    specVersion = '1.6'
    serialNumber = "urn:uuid:$([guid]::NewGuid())"
    version = 1
    metadata = [ordered]@{
        timestamp = [DateTime]::UtcNow.ToString('yyyy-MM-ddTHH:mm:ssZ')
        component = [ordered]@{
            type = 'application'
            'bom-ref' = $pluginRef
            name = 'Affinity Photo 2 Loupedeck Plugin'
            version = $Version
            hashes = @(
                [ordered]@{
                    alg = 'SHA-256'
                    content = $pluginHash
                }
            )
            licenses = @(
                [ordered]@{ license = [ordered]@{ id = 'MIT' } }
            )
        }
    }
    components = @($bomComponents.ToArray())
    dependencies = @(
        [ordered]@{
            'ref' = $pluginRef
            dependsOn = @($dependencyRefs.ToArray())
        }
    )
}

$json = ConvertTo-Json -InputObject $bom -Depth 30
[System.IO.File]::WriteAllText($outputPath, $json, [System.Text.UTF8Encoding]::new($false))
$null = Get-Content -LiteralPath $outputPath -Raw | ConvertFrom-Json
Write-Host "CycloneDX SBOM written to $outputPath ($($bomComponents.Count) packaged components)."
