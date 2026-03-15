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
# Feld: version: 0.2.2

# 2. Build & Package
cd H:\sources\loupedeck\AffinityPhoto2Plugin\src\AffinityPhoto2Plugin
dotnet build -c Release

# 3. Verzeichnis vorbereiten
$pack = "H:\sources\loupedeck\AffinityPhoto2Package"
Remove-Item -Recurse -Force $pack -ErrorAction SilentlyContinue
mkdir $pack\win | Out-Null
mkdir $pack\metadata | Out-Null
cp H:\sources\loupedeck\bin\Release\bin\* $pack\win\ -Recurse -Exclude metadata
cp H:\sources\loupedeck\bin\Release\Icon*.png $pack\metadata\
cp H:\sources\loupedeck\bin\Release\LoupedeckPackage.yaml $pack\metadata\

# 4. Paket erstellen & validieren
cd H:\sources\loupedeck
logiplugintool pack "AffinityPhoto2Package" "AffinityPhoto2.x.lplug4"
logiplugintool verify "AffinityPhoto2.x.lplug4"
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
| `AffinityPhoto2Plugin.csproj` | Projekt-Konfiguration (.NET 8.0) |
| `LoupedeckPackage.yaml` | Plugin-Metadaten (Name, Version, Icons) |
| `AffinityPhoto2Plugin.cs` | Hauptplugin-Klasse |
| `AffinityPhoto2Application.cs` | App-Binding-Logik |
| `Actions/*.cs` | Plugin-Commands und Adjustments |
| `metadata/Icon*.png` | Plugin-Icons (erforderlich) |

## 🎯 Technische Details

- **Framework:** .NET 8.0 (nicht NuGet!)
- **PluginApi:** Von Loupedeck-Installation (`C:\Program Files\Logi\LogiPluginService\`)
- **Output:** `.lplug4` Paket (zip mit Struktur)
- **Supported Devices:** LoupedeckCtFamily (CT, Live, Live S, Razer Stream Controller)

## 📝 Checkliste für neue Versionen

- [ ] Code-Änderungen durchführen
- [ ] `LoupedeckPackage.yaml` Version erhöhen
- [ ] `dotnet build -c Release` ausführen
- [ ] Plugin-Verzeichnis korrekt strukturieren
- [ ] `logiplugintool pack` ausführen
- [ ] `logiplugintool verify` bestätigt OK
- [ ] Manuell in Loupedeck testen (Doppelklick auf .lplug4)
- [ ] GitHub Release erstellen (wenn öffentlich)

---

**Stand:** März 2026 | **Status:** ✅ Funktionsfähig | **Kontakt:** GitHub Issues
