# Tutorial: CLI Build and Release on Windows 8.1

This guide shows how to build and release **IExDeluxe** from command line on **Windows 8.1**.

## 1) Prerequisites

Install one of the following:

- Visual Studio 2019 (or Build Tools 2019) with:
  - **.NET desktop build tools**
  - **MSBuild**
  - **.NET Framework 4.8 Developer Pack**

> Windows 8.1 can build .NET Framework desktop apps with compatible VS/Build Tools setup.

## 2) Open Developer Command Prompt

Use:

- **x86 Native Tools Command Prompt for VS 2019** (recommended)

Or call `VsDevCmd.bat` manually:

```bat
"C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\Common7\Tools\VsDevCmd.bat"
```

## 3) Build commands

From repository root (where `InternetExplorerXDeluxe.sln` exists):

### Debug build

```bat
msbuild InternetExplorerXDeluxe.sln /t:Build /p:Configuration=Debug /p:Platform=x86 /m
```

### Release build

```bat
msbuild InternetExplorerXDeluxe.sln /t:Build /p:Configuration=Release /p:Platform=x86 /m
```

## 4) Output locations

Build artifacts are created at:

- `IExDeluxe\bin\Debug\IExDeluxe.exe`
- `IExDeluxe\bin\Release\IExDeluxe.exe`

## 5) Clean + rebuild (recommended before release)

```bat
msbuild InternetExplorerXDeluxe.sln /t:Clean /p:Configuration=Release /p:Platform=x86
msbuild InternetExplorerXDeluxe.sln /t:Rebuild /p:Configuration=Release /p:Platform=x86 /m
```

## 6) Minimal release package

Create a folder such as `release\IExDeluxe-1.0.0\` and copy:

- `IExDeluxe.exe`
- `IExDeluxe.exe.config` (if generated)
- any required runtime/player dependencies you add later

Optional zip command (PowerShell):

```powershell
Compress-Archive -Path .\release\IExDeluxe-1.0.0\* -DestinationPath .\release\IExDeluxe-1.0.0-win8.1.zip -Force
```

## 7) Verify on clean Windows 8.1 target

Smoke test checklist:

1. App launches without crash.
2. Link open works.
3. File open works.
4. YouTube/Wayback/Archive launch correct URLs.
5. IPTV parser reads local `.m3u` file.

## 8) Troubleshooting

### `msbuild` not found

- Use a Visual Studio Developer Command Prompt.
- Confirm `where msbuild` returns a path.

### Missing .NET Framework targeting pack

- Install `.NET Framework 4.8 Developer Pack`.

### Platform mismatch warnings

- Build with `/p:Platform=x86` to match project configuration.

## 9) Suggested CI command line

For scripted CI/release job:

```bat
msbuild InternetExplorerXDeluxe.sln /t:Rebuild /p:Configuration=Release /p:Platform=x86 /m /verbosity:minimal
```
