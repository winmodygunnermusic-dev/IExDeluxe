# CLI build and release (Windows 8.1)

## Prerequisites

- Visual Studio Build Tools 2019/2022 (or full VS)
- .NET Framework 4.7.2 targeting pack
- NuGet restore capability
- Inno Setup (`iscc.exe`)

## 1) Build x86 and x64

```bat
msbuild XDeluxe.sln /p:Configuration=Release-x86 /p:Platform=x86 /t:Build
msbuild XDeluxe.sln /p:Configuration=Release-x64 /p:Platform=x64 /t:Build
```

## 2) Stage binaries

```bat
copy XDeluxe.UI\bin\Release-x86\XDeluxe.exe release\bin\x86\
copy XDeluxe.UI\bin\Release-x64\XDeluxe.exe release\bin\x64\
```

Copy NuGet/runtime-native payloads:
- CefSharp runtime files to each arch folder
- LibVLC native files (`libvlc.dll`, `libvlccore.dll`, `plugins`) to each arch folder
- `ruffle.js` + `sample.swf` into `release\ruffle\`

## 3) Build installer

```bat
iscc installer\XDeluxe.iss
```

## 4) Smoke test

- launch installed app
- test YouTube/Wayback in embedded browser
- test local file playback in VideoView
- test IPTV M3U playback
- test SWF wrapper loading
