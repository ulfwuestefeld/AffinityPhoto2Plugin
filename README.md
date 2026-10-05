# Affinity Photo 2 Loupedeck Plugin

Ein Feature-reiches Loupedeck Plugin für Affinity Photo 2.x, das Schnellzugriff auf häufig verwendete Tools und Funktionen bietet.

## Features

- ✨ **Tool-Auswahl:** Schneller Zugriff auf Paintbrush, Eraser, Clone, Color Picker und weitere Tools
- 🎨 **Blemish Removal Tool:** Dedizierter Button für das Blemish Removal Tool
- 🖱️ **Zoom & Brush Size:** Steuerung von Zoom und Pinselgröße direkt vom Loupedeck
- 🧰 **Persona-Shortcuts:** Liquify- und Develop-Werkzeuge sowie Ebenen-Deckkraft- und Pinsel-Härte-Voreinstellungen

Persona-spezifische Aktionen funktionieren nur, wenn die entsprechende Affinity-Persona aktiv ist.

## Installation

### Automatisch (empfohlen)
1. Lade das Plugin herunter: [AffinityPhoto2.x.lplug4](https://github.com/ulfwuestefeld/AffinityPhoto2Plugin/releases)
2. Doppelklick auf die `.lplug4` Datei
3. Loupedeck wird das Plugin automatisch installieren

### Manuell
1. Loupedeck Software öffnen
2. "Plug-Ins ein- und ausblenden"
3. Einstellungen (Zahnradsymbol)
4. "+ Plug-In mittels Datei installieren"
5. AffinityPhoto2.x.lplug4 auswählen

## Systemanforderungen

- **Affinity Photo 2.x** (jede Version)
- **Loupedeck Software** (Latest) - https://loupedeck.com/downloads/
- **Kompatible Geräte:**
  - Loupedeck CT
  - Loupedeck Live
  - Loupedeck Live S
  - Razer Stream Controller

## Unterstützung

- 💬 **Issues & Feature Requests:** https://github.com/ulfwuestefeld/AffinityPhoto2Plugin/issues
- 📧 **Email:** Siehe GitHub Profile

## Entwicklung

Das Plugin verwendet die aktuelle Logitech-C#-Pluginarchitektur auf **.NET 10**. Die installierte Logi Plugin Service API (`PluginApi.dll` 6.4.2.3414) referenziert `System.Runtime` 10 und ist deshalb nicht mehr mit einem .NET-8-Ziel kompatibel. Die API wird aus der lokalen Plugin-Service-Installation referenziert. Das Plugin-Projekt hat keine direkten NuGet-Paketabhängigkeiten.

Die Release-Pipeline prüft die mitgelieferten DLLs und erzeugt eine CycloneDX-1.6-SBOM sowie FOSS-Lizenzhinweise. Proprietäre Logitech-Hostkomponenten werden in der SBOM ausdrücklich ohne FOSS-Lizenzanspruch ausgewiesen.

Für Entwicklungs-Details siehe:

- [MODERNIZATION.md](MODERNIZATION.md) - Detaillierte Upgrade-Dokumentation
- [BUILD.md](BUILD.md) - Build & Deployment Anleitung
- [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md) und [FOSS-LICENSES.json](FOSS-LICENSES.json) - FOSS-Lizenzen und Paket-Allowlist

### Schnellstart für Entwickler

```powershell
# Setup
git clone https://github.com/ulfwuestefeld/AffinityPhoto2Plugin.git
cd AffinityPhoto2Plugin\src\AffinityPhoto2Plugin

# Development Build
dotnet build

# Release-Paket inklusive FOSS-Notices und SBOM erstellen (siehe BUILD.md)
```

## Lizenz

MIT License - Siehe [LICENSE](LICENSE) Datei

## Beitragen

Contributions sind willkommen! Bitte öffne einen Issue oder Pull Request auf GitHub.

---

- **Plugin Version:** 0.5.0
- **Logi Plugin Tool:** 6.1.4.22672
- **Loupedeck SDK:** .NET 10 / aktuelle installierte Plugin API
**Status:** ✅ Build und Paket lokal verifiziert (März 2026)
