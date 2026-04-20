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

- Primary build target: **.NET Framework 4.8 WinForms** (`x86`) using MSBuild.
- Intended legacy-friendly behavior with external player/browser integrations.
- Extremely old OS targets (Windows 98/ME/2000) are documented as conceptual,
  but modern VB.NET runtime support is limited. For true native support, a
  separate legacy-native codebase is recommended.

## Build (Windows CLI)

```bat
msbuild InternetExplorerXDeluxe.sln /p:Configuration=Release /p:Platform=x86
```

Output binary (default):

- `IExDeluxe\bin\Release\IExDeluxe.exe`


## Tutorials

- [General project tutorial](tutorial.md)
- [CLI build and release on Windows 8.1](tutorial%20cil%20build%20and%20release%20windows%208.1.md)
