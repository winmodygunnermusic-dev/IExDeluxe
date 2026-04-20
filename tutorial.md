# XDeluxe tutorial

## Main modern build (VB.NET)

1. Open `XDeluxe.sln`.
2. Restore NuGet packages.
3. Build both configurations:
   - `Release-x86`
   - `Release-x64`
4. Run `XDeluxe.UI`.

Main tabs/features in `MainForm`:
- Embedded Chromium browser (CefSharp) for YouTube/Wayback/SWF wrapper pages.
- Video playback tab (LibVLC VideoView) for local files and IPTV stream playback.
- Logs tab for runtime diagnostics.

Core logic in `XDeluxe.Core`:
- M3U parsing (`M3uParser`)
- Playlist management (`PlaylistManager`)
- Wayback + Archive URL helper (`WaybackClient`)
- YouTube URL/search helper (`YouTubeHelper`)

## Legacy build (VB6)

Open `LegacyVB6/XDeluxeLegacy.vbp` in VB6.

This project is intentionally minimal and supports only:
- local file browsing
- opening files via ShellExecute
