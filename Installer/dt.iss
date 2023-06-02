; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "DISMTools"
#define MyAppVersion "0.3 Preview"
#define MyAppPublisher "CodingWonders Software"
#define MyAppURL "https://github.com/CodingWonders/DISMTools"
#define MyAppExeName "DISMTools.exe"
#define MyAppAssocName MyAppName + " project"
#define MyAppAssocExt ".dtproj"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AB033696-A4AC-4DF2-B802-9D8BB8B0EEB5}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableDirPage=yes
ChangesAssociations=yes
DisableProgramGroupPage=yes
LicenseFile=.\files\LICENSE
; Uncomment the following line to run in non administrative install mode (install for current user only.)
PrivilegesRequired=admin
OutputBaseFilename=dt_setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DisableWelcomePage=no
ArchitecturesInstallIn64BitMode=x64
CloseApplications=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "spanish"; MessagesFile: "compiler:Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: ".\files\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\DarkUI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\LICENSE"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\Microsoft.Dism.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\ScintillaNET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\System.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\System.Drawing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\System.Windows.Forms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\System.Xml.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\System.Xml.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\WeifenLuo.WinFormsUI.Docking.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\files\WeifenLuo.WinFormsUI.Docking.ThemeVS2012.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /load=""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent shellexec
