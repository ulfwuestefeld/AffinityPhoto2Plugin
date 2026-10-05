param(
    [Parameter(Mandatory = $true)]
    [string]$BuildOutputPath,

    [Parameter(Mandatory = $true)]
    [string]$PackageRoot,

    [Parameter(Mandatory = $true)]
    [string]$PackageOutputPath
)

$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path $PSScriptRoot -Parent
$buildBinPath = (Resolve-Path -LiteralPath $BuildOutputPath).Path
$buildRoot = Split-Path $buildBinPath -Parent
$metadataSource = Join-Path $buildRoot 'metadata'
$packagePath = [System.IO.Path]::GetFullPath($PackageRoot)
$outputPath = [System.IO.Path]::GetFullPath($PackageOutputPath)

if (Test-Path -LiteralPath $packagePath) {
    throw "Refusing to overwrite existing package staging directory: $packagePath"
}
if (Test-Path -LiteralPath $outputPath) {
    throw "Refusing to overwrite existing plugin package: $outputPath"
}
if (-not (Test-Path -LiteralPath (Join-Path $buildBinPath 'AffinityPhoto2Plugin.dll') -PathType Leaf)) {
    throw "Plugin build output is incomplete: $buildBinPath"
}
if (-not (Test-Path -LiteralPath (Join-Path $metadataSource 'LoupedeckPackage.yaml') -PathType Leaf)) {
    throw "Build metadata directory is incomplete: $metadataSource"
}

$packageMetadata = Join-Path $packagePath 'metadata'
$packageWindows = Join-Path $packagePath 'win'
New-Item -ItemType Directory -Path $packageMetadata -Force | Out-Null
New-Item -ItemType Directory -Path $packageWindows -Force | Out-Null
$runtimeFiles = Get-ChildItem -LiteralPath $buildBinPath -File |
    Where-Object { $_.Extension -ne '.pdb' -and $_.Name -ne 'PluginApi.xml' }
if (-not ($runtimeFiles | Where-Object { $_.Name -ieq 'AffinityPhoto2Plugin.dll' })) {
    throw "Plugin build output does not contain AffinityPhoto2Plugin.dll: $buildBinPath"
}
$runtimeFiles | Copy-Item -Destination $packageWindows
foreach ($metadataFile in @(
    'LoupedeckPackage.yaml',
    'Icon16x16.png',
    'Icon32x32.png',
    'Icon48x48.png',
    'Icon256x256.png'
)) {
    Copy-Item -LiteralPath (Join-Path $metadataSource $metadataFile) -Destination $packageMetadata
}
Copy-Item -LiteralPath (Join-Path $repoRoot 'LICENSE') -Destination $packageMetadata
Copy-Item -LiteralPath (Join-Path $repoRoot 'THIRD-PARTY-NOTICES.md') -Destination $packageMetadata

& (Join-Path $PSScriptRoot 'Generate-Sbom.ps1') -PackageRoot $packagePath

$outputDirectory = Split-Path $outputPath -Parent
if (-not (Test-Path -LiteralPath $outputDirectory)) {
    New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
}

& logiplugintool pack $packagePath $outputPath
if ($LASTEXITCODE -ne 0) {
    throw 'LogiPluginTool pack failed.'
}

& logiplugintool verify $outputPath
if ($LASTEXITCODE -ne 0) {
    throw 'LogiPluginTool verification failed.'
}

$sidecarPath = [System.IO.Path]::ChangeExtension($outputPath, '.cdx.json')
Copy-Item -LiteralPath (Join-Path $packageMetadata 'sbom.cdx.json') -Destination $sidecarPath
Copy-Item -LiteralPath (Join-Path $repoRoot 'THIRD-PARTY-NOTICES.md') -Destination ([System.IO.Path]::ChangeExtension($outputPath, '.THIRD-PARTY-NOTICES.md'))
Write-Host "Verified plugin package: $outputPath"
