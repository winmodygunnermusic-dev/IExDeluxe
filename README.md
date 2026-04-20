# Internet Explorer XDeluxe (Visual Basic)

A generated **Visual Basic .NET (Windows Forms)** starter project for the requested
"Internet Explorer XDeluxe" concept, oriented for CLI/MSBuild workflows.

## Included feature stubs

The project ships with a `MainForm` that provides buttons/tabs for:

- Link/file launcher
- YouTube video player launcher (browser-based)
- Classic local video player launcher
- SWF Flash player placeholder
- IPTV M3U loader and playlist preview
- Wayback URL finder helper
- Internet Archive video search helper

These are implemented as safe starter stubs so you can extend each module.

## Platform notes

- Primary build target: **.NET Framework 2.0 WinForms** (`x86`) for broader legacy compatibility and Visual Studio 2010/MSBuild 4.0 build tooling.
- Intended legacy-friendly behavior with external player/browser integrations.
- Legacy tracks for Windows 98/ME/2000 and beta builds are included as explicit compatibility profiles for testing and packaging workflows.

## Build (Windows CLI)

```bat
msbuild InternetExplorerXDeluxe.sln /t:Rebuild /p:Configuration=Release /p:Platform=x86
```

Output binary (default):

- `IExDeluxe\bin\Release\IExDeluxe.exe`


## Tutorials

- [General project tutorial](tutorial.md)
- [CLI build and release on Windows 8.1](tutorial%20cil%20build%20and%20release%20windows%208.1.md)


## Legacy compatibility profiles

The project now includes explicit compatibility profile names for:

- Windows `98`, `2000`, `ME`, `XP`, `Longhorn`, `Vista`, `7`, `8`, `8.1`, `10`
- Beta profile tags: `beta-me`, `beta-whistler` / `beta-wishter`, `beta-xp`, `beta-longhorn`, `beta-vista`, `beta-7`, `beta-8`, `beta-8.1`, `beta-10`

These profiles are exposed in `CompatibilityProfiles.vb` and logged at startup to help organize legacy testing tracks.
