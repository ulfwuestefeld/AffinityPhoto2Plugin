$version = "0.2.3"

$location = Get-Location

Set-Location H:\sources\loupedeck\AffinityPhoto2Plugin\

$LoupedeckPackageyaml = "H:\sources\loupedeck\AffinityPhoto2Plugin\src\AffinityPhoto2Plugin\metadata\LoupedeckPackage.yaml"
(Get-Content $LoupedeckPackageyaml) -replace "version: [0-9]+\.[0-9]+\.[0-9]+", ("version: " + $version) | Set-Content $LoupedeckPackageyaml
$readmemd = "H:\sources\loupedeck\AffinityPhoto2Plugin\README.md"
(Get-Content $readmemd) -replace "**Plugin Version:** [0-9]+\.[0-9]+\.[0-9]+", ("**Plugin Version:** " + $version) | Set-Content $readmemd

git add $LoupedeckPackageyaml
git commit -m ("Bump version to " + $version)
git push origin main
git tag -a $version -m ("Release version " + $version)
git push origin $version
dotnet build -c Release
Set-Location H:\sources\loupedeck
if (Test-Path AffinityPhoto2Package) {
    Remove-Item -Recurse -Force AffinityPhoto2Package
}
mkdir AffinityPhoto2Package\win | Out-Null     
mkdir AffinityPhoto2Package\metadata | Out-Null
Copy-Item -Path "bin\Release\bin\*" -Destination "AffinityPhoto2Package\win\" -Exclude "metadata" -Recurse -Force
Copy-Item -Path "bin\Release\Icon*.png" -Destination "AffinityPhoto2Package\metadata\"
Copy-Item -Path "bin\Release\LoupedeckPackage.yaml" -Destination "AffinityPhoto2Package\metadata\"
logiplugintool pack "AffinityPhoto2Package" "AffinityPhoto2.x.lplug4"                          
logiplugintool verify "AffinityPhoto2.x.lplug4"
Move-Item .\AffinityPhoto2.x.lplug4 .\AffinityPhoto2Plugin\releases\ -Force
Set-Location $location