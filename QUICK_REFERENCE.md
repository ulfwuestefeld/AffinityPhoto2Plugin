# Quick Reference - Affinity Photo 2 Plugin

## 🚀 Schnellstart (Development)

```powershell
# 1. Projekt bauen
cd src\AffinityPhoto2Plugin
dotnet build

# 2. Loupedeck öffnen und Plugin aktivieren
# → "Show and hide plugins" → "AffinityPhoto2" aktivieren
```

## 📦 Release erstellen

```powershell
# 1. Version aktualisieren
# Datei: src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml
# Feld: version: 0.5.0 (oder nächste Release-Version)

# 2. Isolierter .NET 10 Release-Build und Package
cd H:\sources\loupedeck\AffinityPhoto2Plugin\src\AffinityPhoto2Plugin
$releaseRoot = Join-Path $env:TEMP ("AffinityPhoto2-" + [guid]::NewGuid().ToString('N'))
$releaseBin = Join-Path $releaseRoot "Release\bin"
dotnet build .\AffinityPhoto2Plugin.csproj -c Release "-p:OutputPath=$releaseBin\" -p:EnablePluginReload=false
if ($LASTEXITCODE -ne 0) { throw "Release build failed." }

$repo = (Resolve-Path ..\..).Path
$stage = Join-Path $env:TEMP ("AffinityPhoto2Package-" + [guid]::NewGuid().ToString('N'))
$package = Join-Path $repo "AffinityPhoto2_0.5.0.lplug4"
& (Join-Path $repo "build\Package-Plugin.ps1") -BuildOutputPath $releaseBin -PackageRoot $stage -PackageOutputPath $package
```

## 🧹 Problembehebung

| Problem | Lösung |
|---------|--------|
| Plugin lädt nicht | `dotnet clean && dotnet build` |
| `PluginApi.dll` nicht gefunden | Loupedeck-Software neu installieren |
| Paket-Validierung fehlschlag | Prüfe YAML auf Syntax-Fehler |
| Doppelte Attribute-Fehler | Leere Properties/AssemblyInfo.cs |
| Paket nicht installierbar | Prüfe: `logiplugintool verify <file>` |

## 📚 Dokumentation

- **MODERNIZATION.md** - Was wurde warum geändert? (Migrations-Details)
- **BUILD.md** - Umfassende Build-Anleitung mit Debugging
- **README.md** - Benutzer-Dokumentation

## 🔧 Wichtige Dateien

| Datei | Zweck |
|-------|-------|
| `AffinityPhoto2Plugin.csproj` | Projekt-Konfiguration (.NET 10.0) |
| `LoupedeckPackage.yaml` | Plugin-Metadaten (Name, Version, Icons) |
| `AffinityPhoto2Plugin.cs` | Hauptplugin-Klasse |
| `AffinityPhoto2Application.cs` | App-Binding-Logik |
| `Actions/*.cs` | Plugin-Commands und Adjustments |
| `metadata/Icon*.png` | Plugin-Icons (erforderlich) |

## 🎯 Technische Details

- **Framework:** .NET 10.0 (Plugin API lokal aus dem Logi Plugin Service)
- **PluginApi:** Von Loupedeck-Installation (`C:\Program Files\Logi\LogiPluginService\`)
- **Output:** `.lplug4` Paket (zip mit Struktur)
- **Supported Devices:** LoupedeckCtFamily (CT, Live, Live S, Razer Stream Controller)

## 📝 Checkliste für neue Versionen

- [ ] Code-Änderungen durchführen
- [ ] `LoupedeckPackage.yaml` Version erhöhen
- [ ] Isolierten .NET 10 Release-Build ausführen
- [ ] `build/Package-Plugin.ps1` für Notices, CycloneDX-SBOM und Paket-Verifikation ausführen
- [ ] Manuell in Loupedeck testen (Doppelklick auf .lplug4)
- [ ] GitHub Release erstellen (wenn öffentlich)

---

**Stand:** März 2026 | **Status:** ✅ Build und Paket verifiziert; Runtime nicht getestet | **Kontakt:** GitHub Issues
