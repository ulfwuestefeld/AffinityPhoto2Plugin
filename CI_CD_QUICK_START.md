# Quick Start: GitHub Actions Pipelines

## 🚀 Schnellstart für normale Entwicklung

### 1. Code ändern und pushen
```powershell
cd H:\sources\loupedeck\AffinityPhoto2Plugin
git checkout develop      # oder main für hotfixes
git commit -am "feat: neue action hinzufügen"
git push origin develop
```

**Was passiert automatisch:**
- ✅ build.yml startet → Debug + Release Build
- ✅ quality.yml startet → Code-Analyse + Package-Test
- Schaue in GitHub unter **Actions** um Status zu sehen

---

## 🎉 Quick Start: Release erstellen

### Schritt 1: Version erhöhen
```yaml
# Datei: src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml
version: 0.2.1    # erhöhe von 0.2.0
```

### Schritt 2: Commit und Tag
```powershell
cd H:\sources\loupedeck\AffinityPhoto2Plugin

# Änderungen committen
git add src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml
git commit -m "chore: bump version to 0.2.1"
git push origin main

# Tag erstellen und pushen
git tag -a v0.2.1 -m "Release version 0.2.1"
git push origin v0.2.1
```

### Schritt 3: Release abwarten
- Gehe zu GitHub.com → Repository → **Actions**
- Suche `release.yml` mit Tag `v0.2.1`
- Warte bis alle Schritte grün ✅ sind
- Klicke auf **Releases** um das Paket zu sehen

### Ergebnis
📦 **GitHub Release v0.2.1** ist verfügbar mit:
- `AffinityPhoto2_0.2.1.lplug4` ← zum Herunterladen
- Release Notes (automatisch generiert)

---

## 📊 Status überwachen

### Im VS Code Terminal
```powershell
# GitHub CLI installiert? Wenn nicht, skip diesen Schritt
# winget install GitHub.cli

# Logs ansehen (optional)
gh run list --repo ulfwuestefeld/AffinityPhoto2Plugin
```

### Im Browser
1. https://github.com/ulfwuestefeld/AffinityPhoto2Plugin
2. Klick: **Actions** Tab
3. Wähle den Workflow-Run

---

## 🔄 Was die Workflows machen

| Workflow | Wann | Aufgabe |
|----------|------|--------|
| **build.yml** | Auto (Push/PR) | Build + Artifacts |
| **quality.yml** | Auto (Push/PR) | Tests + Package-Check |
| **release.yml** | Manual (Tag-Push) | Release erstellen |

---

## ⚠️ Wenn etwas schiefgeht

### Workflow ist rot ❌
```powershell
# 1. Gehe zu Actions → klick auf fehlgeschlagenen Workflow
# 2. Scrolle zu "failed" Schritt
# 3. Lies die Error-Nachricht
# 4. Behebe lokal und push erneut
```

### Häufige Fehler

**Problem:** "LogiPluginTool not found"
```powershell
# Lokal testen:
dotnet tool install --global LogiPluginTool
logiplugintool --version
```

**Problem:** "Package verification failed"
```powershell
# Prüfe LoupedeckPackage.yaml:
# - Sind alle required fields vorhanden?
# - Sind Pfade korrekt?

# Lokal testen:
logiplugintool verify AffinityPhoto2_0.2.1.lplug4
```

**Problem:** "Tag wurde nicht erkannt"
```powershell
# release.yml braucht Tags im Format v*:
git tag -a v0.2.1 ...   ✅ Korrekt
git tag -a 0.2.1 ...    ❌ Falsch

# Falschen Tag löschen und neuen erstellen:
git tag -d 0.2.1
git push origin :0.2.1
git tag -a v0.2.1 -m "..."
git push origin v0.2.1
```

---

## 🎁 Artifacts herunterladen

### Nach erfolgreichem Build
1. GitHub → **Actions** → Wähle Workflow
2. Scrolle zu **Artifacts** Sektion
3. Klick auf das Artifact zum Herunterladen

**Aufbewahrungsdauer:**
- `debug-build`: 5 Tage
- `release-build`: 30 Tage
- `plugin-package`: 90 Tage (nur bei main branch)

---

## 💡 Tipps & Tricks

### Pull Requests testen
```powershell
# Feature branch erstellen
git checkout -b feature/my-feature

# Ändern und pushen
git push origin feature/my-feature

# GitHub: Create Pull Request
# ✅ Workflows starten automatisch!
# ✅ Merge erst wenn alle Tests grün sind
```

### Manueller Build ohne Push
```powershell
# Lokal testen vor Push:

cd src\AffinityPhoto2Plugin
dotnet build -c Debug            # Schnelle Iteration
dotnet build -c Release          # Final Test
```

### Changelog automatisch generieren
```powershell
# Die release.yml generiert Changelog aus Commits seit letztem Release
# Edit: Gute Commit-Messages sind wichtig!

# ✅ Gute Messages:
# feat: add color picker action
# fix: handle long plugin names
# chore: update dependencies

# ❌ Schlechte Messages:
# asdf
# Fix bugs
# WIP
```

---

## 📚 Weitere Ressourcen

- **GITHUB_ACTIONS.md** - Komplette Dokumentation
- **BUILD.md** - Lokale Build-Anleitung
- GitHub Actions Docs: https://docs.github.com/en/actions

---

## 🔐 Secrets & Konfiguration

**Wichtig:** Keine Secrets nötig!
- GitHub token wird automatisch bereitgestellt
- Keine API-Keys erforderlich
- Alle Workflows sind "ready to go"

---

## Checkliste für Release

```
[ ] Code ist auf `main` branch
[ ] Tests bestanden (quality.yml ✅)
[ ] Version in LoupedeckPackage.yaml erhöht
[ ] Commit: "chore: bump version to X.Y.Z"
[ ] Tag: git tag -a vX.Y.Z -m "..."
[ ] git push origin main
[ ] git push origin vX.Y.Z
[ ] Actions-Tab: release.yml läuft
[ ] All jobs green ✅
[ ] GitHub Release erstelltt
[ ] .lplug4 Download funktioniert
```

---

**Viel Erfolg mit der automatisierten Build-Pipeline! 🚀**
