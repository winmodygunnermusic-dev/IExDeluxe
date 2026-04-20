[Setup]
AppId={{8D3D4EF3-57B8-4D08-9F0E-7E24BE65432E}
AppName=XDeluxe
AppVersion=1.0.0
DefaultDirName={pf}\XDeluxe
DefaultGroupName=XDeluxe
OutputDir=.
OutputBaseFilename=XDeluxe-Setup
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Tasks]
Name: "desktopicon"; Description: "Create desktop shortcut"; GroupDescription: "Additional icons:";

[Files]
Source: "..\release\bin\x86\*"; DestDir: "{app}\x86"; Flags: recursesubdirs ignoreversion
Source: "..\release\bin\x64\*"; DestDir: "{app}\x64"; Flags: recursesubdirs ignoreversion
Source: "..\release\ruffle\*"; DestDir: "{app}\ruffle"; Flags: recursesubdirs ignoreversion
Source: "..\release\data\*"; DestDir: "{app}\data"; Flags: recursesubdirs ignoreversion

[Icons]
Name: "{group}\XDeluxe"; Filename: "{code:GetExePath}"
Name: "{commondesktop}\XDeluxe"; Filename: "{code:GetExePath}"; Tasks: desktopicon

[Code]
function GetExePath(Value: string): string;
begin
  if IsWin64 then
    Result := ExpandConstant('{app}\x64\XDeluxe.exe')
  else
    Result := ExpandConstant('{app}\x86\XDeluxe.exe');
end;
