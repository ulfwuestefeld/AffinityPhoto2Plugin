# Affinity Photo 2 Plugin - Aktualisierung der Plugin-Architektur

## Problemstellung (März 2026)

Das Loupedeck Plugin "AffinityPhoto2" konnte **nicht installiert werden**. Die Ursachen waren:

### 1. **Veraltete .NET Framework Version** (KRITISCH)
- **Vorher:** .NET Framework 4.7.2 (veraltet, 2015)
- **Zwischenstand:** .NET 8.0
- **Aktuelles Ziel:** .NET 10.0, passend zur installierten Plugin API
- **Impact:** Plugin wurde von modernder Loupedeck SDK nicht erkannt

### 2. **Falsches Projektformat**
- **Vorher:** Altes Projekt-Format (`.csproj` mit manuellen Imports)
- **Nachher:** Modernes SDK-style Format
- **Impact:** Inkompatibilität mit modernem Tooling

### 3. **Fehlende Pflicht-Felder in LoupedeckPackage.yaml**
- Fehlte: `license` Feld
- Fehlte: `licenseUrl` Feld
- **Impact:** Paket-Validierung schlug fehl

### 4. **Veraltete PluginApi-Referenzierung**
- **Vorher:** Hardcoded Pfad zu lokaler Installation
- **Nachher:** Intelligente HintPath basierend auf Installation
- **Impact:** Build-Fehler bei unterschiedlichen Installationspfaden

### 5. **Falsches Paketformat**
- **Vorher:** `.lp5` (altes Format)
- **Nachher:** `.lplug4` (neues Format)
- **Impact:** Paket konnte nicht installiert werden

---

## Durchgeführte Änderungen

### Projektdatei: `src/AffinityPhoto2Plugin/AffinityPhoto2Plugin.csproj`

**Hauptänderungen:**
```xml
<!-- VORHER: Altes Format -->
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
  <Reference Include="PluginApi, Version=2.0.0.0">
    <HintPath>C:\Program Files (x86)\Loupedeck\Loupedeck2\PluginApi.dll</HintPath>
  </Reference>

<!-- NACHHER: Modernes SDK-style Format -->
<Project Sdk="Microsoft.NET.Sdk">
  <TargetFramework>net10.0</TargetFramework>
  <Reference Include="PluginApi">
    <HintPath>$(PluginApiDir)PluginApi.dll</HintPath>
  </Reference>
```

**Spezifische Konfigurationen:**
- SDK-Modell mit automatischem Default-Compile-Verhalten
- Post-Build-Targets für Plugin-Link und automatisches Reload
- CopyLocalLockFileAssemblies für Abhängigkeitsmanagement
- Intelligente Pfade für Windows/macOS

### Konfigurationsdatei: `src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml`

**Ergänzte Pflichtfelder:**
```yaml
license: MIT
licenseUrl: https://opensource.org/licenses/MIT
supportPageUrl: https://github.com/ulfwuestefeld/AffinityPhoto2Plugin/issues
homePageUrl: https://github.com/ulfwuestefeld/AffinityPhoto2Plugin
```

**Aktivierte Capability:**
```yaml
pluginCapabilities:
  - HasApplication  # War auskommentiert, ist jetzt aktiv
```

### Bereinigung: `src/AffinityPhoto2Plugin/Properties/AssemblyInfo.cs`

Entfernte doppelte Assembly-Attribute, die vom SDK automatisch generiert werden:
- `[assembly: AssemblyTitle(...)]`
- `[assembly: AssemblyVersion(...)]`
- Alle anderen Standard-Attribute

---

## Build und Deployment

### Lokales Development

```powershell
# Debug-Build (wird automatisch geladen von Loupedeck)
cd src\AffinityPhoto2Plugin
dotnet build

# Output: <Repository>\bin\Debug\bin\AffinityPhoto2Plugin.dll
# Plugin wird automatisch vom Loupedeck Service geladen
```

### Release und Distribution

```powershell
# Release-Paket inklusive FOSS-Notices und CycloneDX-SBOM erstellen
# Vollständiger Ablauf und Befehle: BUILD.md

# ✓ Installation möglich durch Doppelklick auf .lplug4 Datei
```

---

## Technische Details

### PluginApi-Auflösung

Die Projektdatei definiert die korrekten Pfade:
```xml
<PluginApiDir Condition="$(OS) == 'Windows_NT'">C:\Program Files\Logi\LogiPluginService\</PluginApiDir>
<PluginApiDir Condition="$(OS) != 'Windows_NT'">/Applications/Utilities/LogiPluginService.app/Contents/MonoBundle/</PluginApiDir>
```

Diese werden automatisch entsprechend des Betriebssystems aufgelöst.

### Post-Build Events

Das Projekt enthält automatisierte Post-Build-Targets:
1. **CopyPackage:** Kopiert Metadaten-Dateien
2. **PostBuild:** Erstellt `.link` Datei für Loupedeck Service zum Laden des Plugins
3. **PluginClean:** Bereinigt bei `dotnet clean`

### Embedded Resources

Alle Icon-Bilder werden als EmbeddedResources kompiliert:
```xml
<EmbeddedResource Include="Actions\AdjustZoom0.png" />
<EmbeddedResource Include="Actions\AdjustZoom1.png" />
<!-- ... weitere Icons -->
```

---

## Abhängigkeiten

Das Projekt benötigt folgende Tools:

| Tool | Version | Quelle |
|------|---------|--------|
| .NET SDK | 10.0+ | https://dotnet.microsoft.com/download/dotnet/10.0 |
| Logi Plugin Service API | 6.4.2.3414+ | Lokale Logi Plugin Service Installation |
| LogiPluginTool | 6.1.4.22672 | `dotnet tool install --global LogiPluginTool --version 6.1.4.22672` |
| Loupedeck Software | Latest | https://loupedeck.com/downloads/ |

`PluginApi.dll` wird von der Logi Plugin Service Installation bereitgestellt (nicht NuGet). Die aktuelle lokale API referenziert `System.Runtime` 10.0, daher kann das Plugin nicht mehr gegen .NET 8 gebaut werden.

---

## Häufige Fehler und Lösungen

### Fehler: "Das Paket "Loupedeck.PluginApi" wurde nicht gefunden"
**Lösung:** LogiPluginTool verwenden, nicht NuGet. Die PluginApi wird von der lokalen Loupedeck-Installation referenziert.

### Fehler: "LoupedeckPackage.yaml fehlt in metadata Ordner"
**Lösung:** Sicherstellen, dass die Verzeichnisstruktur korrekt ist:
```
AffinityPhoto2Package/
├── win/
│   └── AffinityPhoto2Plugin.dll
│   └── (alle anderen Abhängigkeiten)
└── metadata/
    ├── LoupedeckPackage.yaml
    └── Icon*.png
```

### Fehler: "Doppelte Compile-Elemente"
**Lösung:** Im SDK-Format keine expliziten `<Compile Include>` Einträge verwenden. Das SDK findet automatisch alle `.cs` Dateien.

### Plugin lädt nicht nach Build
**Lösung:** Loupedeck Service neu starten oder kurz warten. Das `PostBuild` Target versucht, `loupedeck://plugin/AffinityPhoto2/reload` zu triggern (erfordert, dass Loupedeck läuft).

---

## Verbleibende Verbesserungen

1. **Unit Tests:** Hinzufügen von Unit-Tests für Plugin-Logik
2. **Release-Runner:** Self-hosted Windows-Runner mit installiertem Logi Plugin Service SDK für automatische GitHub-Releases bereitstellen
3. **Runtime-Tests:** Plugin in Logi Plugin Service und Affinity Photo 2 testen
4. **Lokalisierung:** XLIFF-Support für mehrsprachige UI
5. **Icon Templates:** Custom `.ict` Templates für Action-Icons

---

## Referenzen

- **Offizielle Dokumentation:** https://logitech.github.io/actions-sdk-docs/csharp/
- **Plugin-Struktur:** https://logitech.github.io/actions-sdk-docs/csharp/tutorial/plugin-structure/
- **Distribution:** https://logitech.github.io/actions-sdk-docs/csharp/plugin-development/distributing-the-plugin/

---

**Letztes Update:** 15. März 2026
**Modernisiert von:** GitHub Copilot Migration Assistant
