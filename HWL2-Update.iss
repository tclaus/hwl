[Setup]
VersionInfoVersion=2.5.0.3
VersionInfoCompany=Claus-Software
VersionInfoCopyright=2015
VersionInfoProductName=HWL 2.5
VersionInfoProductVersion=2.5
AppName=HWL Businss
PrivilegesRequired=admin
DefaultDirName={pf}\HWL2.5
DefaultGroupName=HWL-2
OutputBaseFilename=hwl2.5-update
MinVersion=0,5.01.2600sp2
AppVerName=HWL Businss 2.5
DisableDirPage=true
ShowLanguageDialog=auto
AppMutex=HWL2
DisableProgramGroupPage=true
AppPublisherURL=http://claus-software.de
UninstallDisplayIcon={app}\HWL2.exe
SolidCompression=false
Compression=lzma/normal
MergeDuplicateFiles=false
AppCopyright=Claus-Software 2015
AppID={{2C7F937E-6B45-41C0-992C-1295FFE55750}
VersionInfoTextVersion=2.5
CreateUninstallRegKey=false
AppSupportURL=http://claus-software.de
[Files]
Source: HWL2-Applikation\bin\release\Vista Api.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWLInterops.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWLKernel.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL-Kernel\bin\release\MySql.Data.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWL2.exe; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\SendErrorMessage.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\TemplateDataBase\template.mdb; DestDir: {app}\TemplateDataBase; Flags: overwritereadonly
Source: HWL2-Applikation\bin\release\Mommosoft.Capi.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWLKernel.xml; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\en-gb.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\release\de-de.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\pl-pl.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\ru-ru.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\fr-fr.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\it.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\release\Helpfiles\Help-de.chm; DestDir: {app}\helpfiles
Source: Projekte\Datanorm\bin\release\Datanorm.dll; DestDir: {app}\connectors\datanorm; Flags: ignoreversion
Source: Projekte\CommonImport\CommonImport\bin\release\CommonImport.dll; DestDir: {app}\connectors\CommonImport
Source: Projekte\Datanorm\bin\release\Datanorm.dll; DestDir: {app}\connectors\SHK-Connect


[Dirs]
Name: {app}\connectors
Name: {app}\connectors\datanorm
Name: {app}\connectors\CommonImport
Name: {app}\helpfiles
Name: {app}\connectors\SHK-Connect
[Languages]
Name: Polish; MessagesFile: compiler:Languages\Polish.isl
Name: French; MessagesFile: compiler:Languages\French.isl
Name: Dutch; MessagesFile: compiler:Languages\Dutch.isl
Name: German; MessagesFile: compiler:Languages\German.isl
Name: Spanish; MessagesFile: compiler:Languages\Spanish.isl
Name: Italian; MessagesFile: compiler:Languages\Italian.isl
Name: english; MessagesFile: compiler:Default.isl
[Icons]
Name: {group}\HWL-2; Filename: {app}\HWL2.exe; Comment: Startet HWL2: Angebote /Rechnungen; Languages: 
[Run]
Filename: {app}\HWL2.exe; Flags: postinstall nowait; Languages: 
