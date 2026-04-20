# XDeluxe

Modern build target: **VB.NET / .NET Framework 4.7.2** (Windows 7 -> Windows 8.1 and newer).

Legacy build target: **separate VB6 launcher** for Windows 98/ME/2000/XP where only local file launching is realistic.

## Projects

- `XDeluxe.UI`
  - `Program.vb` (CefSharp init/shutdown entrypoint)
  - `MainForm.vb` (WinForms UI with embedded browser + LibVLC VideoView)
- `XDeluxe.Core`
  - `M3uParser.vb`
  - `PlaylistManager.vb`
  - `WaybackClient.vb`
  - `YouTubeHelper.vb`
- `LegacyVB6`
  - tiny Win32 launcher using ShellExecute for local files only

## Dependency strategy

### CefSharp (embedded Chromium)

- NuGet in `XDeluxe.UI/packages.config`: `CefSharp.Common`, `CefSharp.WinForms`.
- `Program.vb` initializes Cef before showing the form.
- `MainForm.vb` hosts `ChromiumWebBrowser` for YouTube, Wayback, and SWF/Ruffle wrapper pages.

### LibVLC

- NuGet in `XDeluxe.UI/packages.config`: `LibVLCSharp`, `LibVLCSharp.WinForms`.
- `MainForm.vb` uses `VideoView` + `MediaPlayer` for classic local playback and IPTV playback from parsed M3U entries.

### SWF via Ruffle

- `release/ruffle/ruffle_player.html` loads `ruffle.js` and then `sample.swf`.
- The app loads this local wrapper in the embedded browser tab/button flow.

## Build

```bat
msbuild XDeluxe.sln /p:Configuration=Release-x86 /p:Platform=x86 /t:Build
msbuild XDeluxe.sln /p:Configuration=Release-x64 /p:Platform=x64 /t:Build
```

## Packaging runtime files

Place ABI-matched files into:

- `release/bin/x86/` -> XDeluxe.exe + CefSharp x86 + LibVLC x86
- `release/bin/x64/` -> XDeluxe.exe + CefSharp x64 + LibVLC x64
- `release/ruffle/` -> `ruffle.js`, `ruffle_player.html`, `sample.swf`

Build installer:

```bat
iscc installer\XDeluxe.iss
```

## Legacy OS notes

For Windows 98/ME/2000/XP, use `LegacyVB6` only:
- local file listing
- ShellExecute opening in installed external players

Do not expect reliable modern HTTPS/TLS stacks, embedded Chromium, or full modern web playback on those systems.
