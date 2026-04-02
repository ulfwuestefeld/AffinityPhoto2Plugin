# Affinity Photo 2 Loupedeck Plugin

Ein Feature-reiches Loupedeck Plugin für Affinity Photo 2.x, das Schnellzugriff auf häufig verwendete Tools und Funktionen bietet.

## Features

- ✨ **Tool-Auswahl:** Schneller Zugriff auf Paintbrush, Eraser, Clone, Color Picker und weitere Tools
- 🎨 **Blemish Removal Tool:** Dedizierter Button für das Blemish Removal Tool
- 🖱️ **Zoom & Brush Size:** Steuerung von Zoom und Pinselgröße direkt vom Loupedeck

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

Dieses Plugin wurde zu **.NET 8.0** modernisiert. Für Entwicklungs-Details siehe:

- [MODERNIZATION.md](MODERNIZATION.md) - Detaillierte Upgrade-Dokumentation
- [BUILD.md](BUILD.md) - Build & Deployment Anleitung

### Schnellstart für Entwickler

```powershell
# Setup
git clone https://github.com/ulfwuestefeld/AffinityPhoto2Plugin.git
cd AffinityPhoto2Plugin\src\AffinityPhoto2Plugin

# Development Build
dotnet build

# Release Build & Paket
dotnet build -c Release
logiplugintool pack "..\..\..\bin\Release\" "..\..\..\AffinityPhoto2.lplug4"
```

## Lizenz

MIT License - Siehe [LICENSE](LICENSE) Datei

## Beitragen

Contributions sind willkommen! Bitte öffne einen Issue oder Pull Request auf GitHub.

---

**Plugin Version:** 0.5.0  
**Loupedeck SDK:** .NET 8.0  
**Status:** ✅ Funktionsfähig (März 2026)
