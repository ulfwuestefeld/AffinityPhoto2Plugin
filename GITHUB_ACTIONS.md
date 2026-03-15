# GitHub Actions Build Pipeline

Diese Datei dokumentiert die automatisierten Build-Pipelines für das AffinityPhoto2 Plugin.

## 📋 Übersicht

Die GitHub Actions Workflows automatisieren den kompletten Build-, Test- und Release-Prozess:

| Workflow | Trigger | Aufgaben |
|----------|----------|----------|
| **build.yml** | Push to `main`/`develop`, PR | Debug & Release byggning, Artifact-Upload |
| **quality.yml** | Push to `main`/`develop`, PR | Code-Analyse, Package-Verifikation |
| **release.yml** | Tag push (`v*`) | Release-Build, Packaging, Package-Upload |

---

## 🔄 Workflow Details

### 1. **build.yml** - Kontinuierliche Builds

**Trigger:**
- Auf Pushes zu `main` oder `develop`
- Auf Pull Requests gegen `main`
- Nur wenn Dateien in `src/` geändert wurden

**Schritte:**

```
✅ Code auschecken
   ↓
✅ .NET 8.0 setup
   ↓
✅ Dependencies restoren
   ↓
✅ Debug-Build (dotnet build -c Debug)
   ↓
✅ Release-Build (dotnet build -c Release)
   ↓
✅ Artifacts hochladen (Debug: 5 Tage, Release: 30 Tage)
```

**Ergebnis:**
- Artifacts: `debug-build` und `release-build`
- Enthält: DLLs, Dependencies, Metadaten-Dateien

---

### 2. **quality.yml** - Code Quality & Verifikation

**Trigger:** Gleich wie build.yml

**Schritte:**

**Job 1: Code-Analyse**
```
✅ Code auschecken
   ↓
✅ .NET 8.0 Setup
   ↓
✅ Format-Check (dotnet format --verify-no-changes)
   ↓
✅ Build mit Code-Style-Enforcement
```

**Job 2: Package-Verifikation (Trockentest)**
```
✅ Release-Build
   ↓
✅ LogiPluginTool installieren
   ↓
✅ Package-Struktur vorbereiten
   ↓
✅ Plugin packen (logiplugintool pack)
   ↓
✅ Paket verifizieren (logiplugintool verify)
   ↓
✅ Package-Integrität prüfen
```

**Ergebnis:**
- Stellt sicher, dass Paket immer gültig ist
- Frühe Erkennung von Package-Problemen

---

### 3. **release.yml** - Tag-basiertes Release

**Trigger:**
- Push von Tag `v*` (z.B. `v0.2.2`)

**Schritte:**

```
✅ Code für Tag auschecken
   ↓
✅ Release-Build
   ↓
✅ LogiPluginTool installieren
   ↓
✅ Package-Struktur vorbereiten
   ↓
✅ Version aus LoupedeckPackage.yaml extrahieren
   ↓
✅ Plugin packen (AffinityPhoto2_<VERSION>.lplug4)
   ↓
✅ Paket verifizieren
   ↓
✅ GitHub Release erstellen mit:
   - *.lplug4 Paket
   - AffinityPhoto2Plugin.dll
   - Auto-generierte Release Notes
   ↓
✅ Paket als Artifact (90 Tage) speichern
```

**Ergebnis:**
- GitHub Release mit Binaries
- Downloadbar für Benutzer
- .lplug4 fertig zum Installieren

---

## 🚀 Verwendung

### Build triggern

**Option 1: Automatisch beim Push**
```powershell
# Pushen zu main oder develop →
# ✅ build.yml + quality.yml starten automatisch
git push origin main
```

**Option 2: Manuell über GitHub UI**
- Repo → Actions → Choose Workflow → Run Workflow

### Release erstellen

**Schritt 1: Version erhöhen**
```yaml
# src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml
version: 0.2.2  # Erhöhen
```

**Schritt 2: Commit und Tag**
```powershell
git add src/AffinityPhoto2Plugin/metadata/LoupedeckPackage.yaml
git commit -m "chore: bump version to 0.2.2"
git tag -a v0.2.2 -m "Release version 0.2.2"
git push origin main
git push origin v0.2.2
```

**Schritt 3: GitHub Release wird automatisch erstellt**
- release.yml startet
- Build, Package, Verify
- GitHub Release mit Downloads

**Ergebnis:**
```
GitHub Release v0.2.2
├── AffinityPhoto2_0.2.2.lplug4  ← Für Benutzer
├── AffinityPhoto2Plugin.dll      ← Debug-Info
└── Release Notes
```

---

## 📊 Workflow-Status überwachen

1. Gehe zu: Repo → **Actions**
2. Klicke auf den Workflow-Run, den du überwachen möchtest
3. Sehe alle Jobs und deren Status

**Status-Bedeutungen:**
- 🟢 **Success** - Alles okay
- 🟡 **In Progress** - Läuft noch
- 🔴 **Failed** - Fehler aufgetreten
- ⏭️ **Skipped** - Bedingt übersprungen

---

## 🔧 Konfiguration

### Environment Variables

Die Workflows verwenden diese Variablen (aus `.github/workflows/`):

```yaml
- GITHUB_TOKEN: Automatisch für Release-Uploads
- Keine benutzerdefinierten Secrets erforderlich!
```

### Anpassungen

Zum Modifizieren der Workflows:

**Pfade ändern:**
```yaml
# In build.yml, quality.yml, release.yml
paths:
  - 'src/**'        # Nur prüfen wenn src/ geändert
  - '.github/workflows/*.yml'  # Oder wenn Workflows geändert
```

**Branches ändern:**
```yaml
on:
  push:
    branches: [ main, develop, staging ]  # Weitere branches hinzufügen
```

**Artifact-Aufbewahrung:**
```yaml
retention-days: 90  # z.B. 30 für kürzere Aufbewahrung
```

---

## 🐛 Troubleshooting

### Problem: Workflow schlägt beim Packaging fehl

**Grund:** LogiPluginTool nicht installiert oder Pfade falsch

```powershell
# Prüfen in workflow logs:
# "Install LogiPluginTool" Schritt ausgeben lesen

# Lokal testen:
dotnet tool install --global LogiPluginTool
logiplugintool pack AffinityPhoto2Package test.lplug4
```

### Problem: Release.yml wird nicht ausgelöst

**Grund:** Tag-Format falsch

```powershell
# ✅ Correct:
git tag -a v0.2.2 -m "Release 0.2.2"

# ❌ Wrong (wird nicht erkannt):
git tag -a 0.2.2 -m "Release 0.2.2"
```

### Problem: Artifacts lassen sich nicht herunterladen

**Grund:** Artifact abgelaufen oder workflow fehlgeschlagen

```powershell
# Prüfe:
# 1. Ist der Workflow erfolgreich (🟢)?
# 2. Ist das Artifact noch im Aufbewahrungsfenster?

# Artifacts mit längerer Aufbewahrung:
# - release-build: 30 Tage
# - plugin-package: 90 Tage (nur bei main branch)
```

---

## 📈 Best Practices

### 1. **Normale Entwicklung**
```powershell
# Entwickeln und pushen
git commit -am "feat: add new action"
git push origin develop

# ✅ build.yml + quality.yml starten automatisch
# ✅ Prüfe Workflow-Status
```

### 2. **Vor Release**
```powershell
# Sicher sein:
# 1. ✅ Alle Tests bestanden (quality.yml erfolgreich)
# 2. ✅ Version in LoupedeckPackage.yaml erhöht
# 3. ✅ Code in main gemergt
```

### 3. **Release durchführen**
```powershell
git tag -a v0.2.2 -m "Release version 0.2.2"
git push origin v0.2.2

# ✅ release.yml startet automatisch
# ✅ GitHub Release wird erstellt
# ✅ Paket ist downloadbar
```

---

## 📝 Checkliste für Releasung

- [ ] Version in `LoupedeckPackage.yaml` erhöht
- [ ] `git commit` mit Versions-Bump
- [ ] `git tag -a v<VERSION>` erstellt
- [ ] `git push origin main` (für neuen Code)
- [ ] `git push origin v<VERSION>` (für Tag)
- [ ] release.yml startet (Actions-Tab prüfen)
- [ ] Paket-Verifikation erfolgreich (grünes ✅)
- [ ] GitHub Release erstellt
- [ ] Paket-Download funktioniert
- [ ] Installation im Loupedeck testen

---

## 📚 Weitere Ressourcen

- **BUILD.md** - Detaillierte lokale Build-Anleitung
- **MODERNIZATION.md** - Migration zu .NET 8.0
- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [LogiPluginTool Dokumentation](https://github.com/Loupedeck/SDK)
