# Build und Deployment Anleitung

## Voraussetzungen

Stelle sicher, dass folgende Tools installiert sind:

```powershell
# .NET 8.0 SDK prüfen
dotnet --version
# Sollte mindestens 8.0.x anzeigen

# Loupedeck Software
# https://loupedeck.com/downloads/

# LogiPluginTool installieren (wenn nicht vorhanden)
dotnet tool install --global LogiPluginTool
```

---

## Entwicklungs-Workflow

### 1. Code ändern und bauen

```powershell
cd H:\sources\loupedeck\AffinityPhoto2Plugin\src\AffinityPhoto2Plugin

# Debug-Build
dotnet build

# Oder mit Hot-Reload während der Entwicklung:
dotnet watch build
```

**Was passiert beim Build:**
- `.NET 8.0` kompiliert den Code
- Abhängigkeiten (PluginApi.dll etc.) werden kopiert
- Metadaten-Dateien (Icons, YAML) werden kopiert
- Automatisch ein `.link` File für Loupedeck erstellt
- Plugin wird automatisch neu geladen (wenn Loupedeck läuft)

**Output:**
```
H:\sources\loupedeck\bin\Debug\bin\AffinityPhoto2Plugin.dll
H:\sources\loupedeck\bin\Debug\bin\metadata\
```

### 2. Testing im Loupedeck

Nach dem Build:
1. Öffne die Loupedeck Software
2. Das Plugin sollte in "Show and hide plugins" erscheinen
3. Aktiviere es und teste die Actions

Falls das Plugin nicht erscheint:
```powershell
# Option A: Loupedeck Service neustarten
Stop-Process -Name "LogiPluginService" -Force
Start-Process "C:\Program Files\Logi\LogiPluginService\LogiPluginService.exe"

# Option B: Reload über URL (wenn Loupedeck läuft)
start loupedeck:plugin/AffinityPhoto2/reload
```

---

## Release-Build

### 1. Vorbereitung

Aktualisiere die Version in [metadata/LoupedeckPackage.yaml](src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml):

```yaml
version: 0.2.1         # Erhöhe versionsnummer
```

### 2. Release-Build erstellen

```powershell
cd H:\sources\loupedeck\AffinityPhoto2Plugin\src\AffinityPhoto2Plugin

# Release-Build
dotnet build -c Release

# Output:
# H:\sources\loupedeck\bin\Release\bin\AffinityPhoto2Plugin.dll
```

### 3. Plugin-Paket vorbereiten

```powershell
cd H:\sources\loupedeck

# Backup der alten Paket-Struktur
if (Test-Path AffinityPhoto2Package) {
    Remove-Item -Recurse -Force AffinityPhoto2Package
}

# Neue Verzeichnisstruktur
mkdir AffinityPhoto2Package\win | Out-Null
mkdir AffinityPhoto2Package\metadata | Out-Null

# Release-Dateien kopieren
Copy-Item -Path "bin\Release\bin\*" `
          -Destination "AffinityPhoto2Package\win\" `
          -Exclude "metadata" `
          -Recurse -Force

# Metadaten kopieren
Copy-Item -Path "bin\Release\Icon*.png" `
          -Destination "AffinityPhoto2Package\metadata\"
Copy-Item -Path "bin\Release\LoupedeckPackage.yaml" `
          -Destination "AffinityPhoto2Package\metadata\"
```

### 4. Paket erstellen und validieren

```powershell
# .lplug4 Paket erstellen
logiplugintool pack "AffinityPhoto2Package" "AffinityPhoto2.x.lplug4"

# Paket validieren
logiplugintool verify "AffinityPhoto2.x.lplug4"
# Sollte "OK" zurückgeben
```

**Erfolgreicher Output:**
```
Verifying plugin package 'H:\sources\loupedeck\AffinityPhoto2.x.lplug4'
Unpacking plugin...
OK
Verifying plugin package...
OK
Operation succeeded in 0,7 seconds.
```

---

## Distribution

### Lokale Installation

```powershell
# Doppelklick auf die .lplug4 Datei
# oder
Invoke-Item "AffinityPhoto2.x.lplug4"
```

### Marketplace Submission

1. Gehe zu: https://marketplace.logi.com/ (als Developer registrieren)
2. Upload: `AffinityPhoto2.x.lplug4`
3. Fülle die Details aus
4. Stelle sicher, dass alles folgendermaßen dokumentiert ist:
   - ✓ `license` Feld in YAML
   - ✓ `licenseUrl` Feld in YAML
   - ✓ `supportPageUrl` Feld in YAML
   - ✓ `homePageUrl` Feld in YAML
   - ✓ Icon (metadata/Icon256x256.png)
   - ✓ Alle Abhängigkeiten im Paket

---

## Debugging

### Verbose Build

```powershell
dotnet build --diagnostic
```

### Build-Output inspizieren

```powershell
# Alle Dateien im Output
Get-ChildItem -Path "H:\sources\loupedeck\bin\Debug\bin\" -Recurse

# Spezifisch das DLL prüfen
Get-Item "H:\sources\loupedeck\bin\Debug\bin\AffinityPhoto2Plugin.dll" -Verbose
```

### Plugin.link Datei prüfen

Das Plugin wird über eine `.link` Datei geladen:

```powershell
# Pfad auf Windows
$linkPath = "$env:LOCALAPPDATA\Logi\LogiPluginService\Plugins\AffinityPhoto2Plugin.link"

# Inhalt prüfen
Get-Content $linkPath

# Sollte den Build-Output Pfad enthalten:
# H:\sources\loupedeck\bin\Debug\
```

### Logs prüfen

```powershell
# LogiPluginService Logs
$logPath = "$env:LOCALAPPDATA\Logi\LogiPluginService\logs"
Get-ChildItem -Path $logPath -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 5
```

---

## Häufige Build-Fehler

### Fehler: `error CS0579: Duplicate attribute`
**Ursache:** Alte AssemblyInfo.cs mit manuellen Attributen
**Lösung:** 
```powershell
# Datei leeren oder minimal halten:
# Properties/AssemblyInfo.cs sollte nur haben:
using System.Reflection;
using System.Runtime.InteropServices;
// SDK generiert den Rest automatisch
```

### Fehler: `error NETSDK1022: Duplicate compile items`
**Ursache:** Explizite `<Compile Include>` Einträge im SDK-Format
**Lösung:** Aus der `.csproj` Datei entfernen. SDK findet `.cs` Dateien automatisch.

### Fehler: `Cannot find PluginApi.dll`
**Ursache:** Loupedeck Software nicht installiert
**Lösung:** 
1. Loupedeck installieren von https://loupedeck.com/downloads/
2. `PluginApiDir` in `.csproj` sollte korrekt auf `C:\Program Files\Logi\LogiPluginService\` zeigen

### Fehler: Plugin wird nicht geladen
**Ursache:** `.link` Datei zeigt auf falschen Pfad
**Lösung:**
```powershell
# Manuell neu bauen und link neuerstellten lassen
dotnet clean
dotnet build

# Oder link manuell korrigieren
$pluginDir = "$env:LOCALAPPDATA\Logi\LogiPluginService\Plugins\"
$buildPath = "H:\sources\loupedeck\bin\Debug\"
Set-Content -Path "$pluginDir\AffinityPhoto2Plugin.link" -Value $buildPath
```

---

## Automatisierung mit PowerShell

Verwende dieses Script für schnelleres Deployment während der Entwicklung:

```powershell
# build-and-reload.ps1
param(
    [string]$Configuration = "Debug"
)

cd H:\sources\loupedeck\AffinityPhoto2Plugin\src\AffinityPhoto2Plugin

# Build
Write-Host "🔨 Building with $Configuration configuration..." -ForegroundColor Cyan
dotnet build -c $Configuration

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Build failed" -ForegroundColor Red
    exit 1
}

Write-Host "✅ Build successful" -ForegroundColor Green

# Reload
Write-Host "🔄 Reloading plugin..." -ForegroundColor Cyan
start loupedeck:plugin/AffinityPhoto2/reload

Write-Host "✅ Done!" -ForegroundColor Green
```

Verwendung:
```powershell
.\build-and-reload.ps1
```

---

**Letzte Aktualisierung:** 15. März 2026
