# IExDeluxe Tutorial

This tutorial explains how to use and extend the generated **Internet Explorer XDeluxe** Visual Basic project.

## 1) Project structure

- `InternetExplorerXDeluxe.sln` — Solution file
- `IExDeluxe/IExDeluxe.vbproj` — VB.NET WinForms project (.NET Framework 2.0, x86, Visual Studio 2010 compatible)
- `IExDeluxe/Program.vb` — Application startup entry point
- `IExDeluxe/MainForm.vb` — Main UI and feature button handlers
- `IExDeluxe/FeatureModules.vb` — Helper modules (URL builder + M3U parsing)
- `IExDeluxe/CompatibilityProfiles.vb` — Legacy OS and beta profile list used for testing tracks

## 2) Run from Visual Studio 2010

1. Open `InternetExplorerXDeluxe.sln`.
2. Set configuration to `Debug` and platform to `x86`.
3. Press **F5** to build and run.

## 3) Feature buttons quick guide

The first textbox accepts a URL, file path, or search query depending on the button:

- **Open Link**: opens a web URL.
- **Open File**: opens local file path in default app.
- **YouTube**: opens YouTube or a query search URL.
- **Classic Video**: placeholder hook for VLC/MPC-HC integration.
- **SWF Flash**: placeholder hook for Ruffle/legacy SWF host.
- **IPTV M3U**: parses a local M3U/M3U8 file and shows channel count.
- **Wayback**: opens Wayback lookup URL.
- **Archive Videos**: opens Internet Archive movies search.

## 4) Implementing real players

### Classic video player integration example

Replace stub code in `OnClassicVideo` with a player launch. Example approach:

- Add configurable path for VLC (`vlc.exe`)
- Validate selected file
- Launch process with command-line args

### SWF playback options

Modern Windows no longer includes Flash Player by default. Practical options:

- Integrate **Ruffle** desktop/web runtime
- Use an external compatibility tool for archived SWF content

## 5) IPTV workflow

Current implementation counts channel URLs in an M3U file. Next improvements:

- Parse `#EXTINF` metadata into a list/grid
- Add click-to-play with external player
- Add network URL M3U download support

## 6) Safety notes

- Validate all URLs and file inputs before launching external processes.
- Avoid running unknown SWF/M3U sources without sandboxing.
- Keep app architecture modular (`FeatureModules.vb` or separate classes).

## 7) Release readiness checklist

- [ ] Add app icon and version metadata
- [ ] Add exception logging file
- [ ] Add config file for player paths
- [ ] Add smoke tests for helper methods
- [ ] Build `Release|x86` and verify startup on Windows 8.1 (VS2010 toolchain)
