[Setup]
VersionInfoVersion=2.6.1
VersionInfoCompany=Claus-Software
VersionInfoCopyright=2024
VersionInfoProductName=HWL 2.6
VersionInfoProductVersion=2.6
AppName=HWL Business
PrivilegesRequired=admin
DefaultDirName={pf}\HWL2.5
DefaultGroupName=HWL-2
OutputBaseFilename=hwl2.5-setup
MinVersion=0,6.1.7600
AppVersion=2.6
;AppVerName=HWL Businss 2.5
DisableDirPage=true
ShowLanguageDialog=auto
AppMutex=HWL2
DisableProgramGroupPage=true
AppPublisherURL=https://claus-software.de
UninstallDisplayIcon={app}\HWL2.exe
SolidCompression=false
Compression=lzma/normal
MergeDuplicateFiles=false
AppCopyright=Claus-Software 2024
AppID={{2C7F937E-6B45-41C0-992C-1295FFE55750}
VersionInfoTextVersion=2.6
AppSupportURL=https://www.claus-software.de/hwl-archiv/
AppPublisher=Claus-Software
AppUpdatesURL=https://www.claus-software.de/hwl-archiv/

[Files]
Source: HWL2-Applikation\bin\release\Vista Api.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWL\ApplicationInfo.ini; DestDir: {app}; Flags: ignoreversion
Source: HWL-Kernel\bin\release\DevExpress.Data.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\DevExpress.Utils.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL-Kernel\bin\release\DevExpress.Xpo.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\DevExpress.XtraBars.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\DevExpress.XtraEditors.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\DevExpress.XtraGrid.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraNavBar.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\DevExpress.XtraWizard.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraScheduler.v11.2.Core.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraScheduler.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraScheduler.v11.2.Extensions.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraScheduler.v11.2.Reporting.Extensions.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.XtraScheduler.v11.2.OutlookExchange.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.XtraScheduler.v11.2.iCalendarExchange.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.CodeParser.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraCharts.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraLayout.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraTreeList.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.Charts.v11.2.Core.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraRichEdit.v11.2.Extensions.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraRichEdit.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.RichEdit.v11.2.Core.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraReports.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.Reports.v11.2.Designer.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraReports.v11.2.Extensions.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraPrinting.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.Printing.v11.2.Core.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\release\DevExpress.XtraVerticalGrid.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.SpellChecker.v11.2.Core.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.XtraSpellChecker.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.XtraPivotGrid.v11.2.dll; DestDir: {app}; Flags: ignoreversion
Source: HWLInterops\bin\Release\DevExpress.PivotGrid.v11.2.Core.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWLInterops.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWLKernel.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL-Kernel\bin\release\MySql.Data.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWL2.exe; DestDir: {app}; Flags: ignoreversion
Source: DevExpress.language.DLL\de\DevExpress.Data.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.Utils.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.Xpo.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraBars.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraCharts.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraEditors.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraGrid.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraLayout.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraNavBar.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraPrinting.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraReports.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraRichEdit.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraScheduler.v11.2.Core.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraScheduler.v11.2.Extensions.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraScheduler.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraTreeList.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraVerticalGrid.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.XtraWizard.v11.2.resources.dll; DestDir: {app}\de\
Source: DevExpress.language.DLL\de\DevExpress.RichEdit.v11.2.Core.resources.dll; DestDir: {app}\de\
Source: HWL2-Applikation\bin\release\TemplateDataBase\template.mdb; DestDir: {app}\TemplateDataBase; Flags: overwritereadonly
Source: HWL2-Applikation\bin\release\Mommosoft.Capi.dll; DestDir: {app}; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\HWLKernel.xml; DestDir: {app}; Flags: ignoreversion
Source: Projekte\CommonImport\CommonImport\bin\release\CommonImport.dll; DestDir: {app}\connectors\CommonImport; Flags: ignoreversion
Source: HWL2-Applikation\bin\release\en-gb.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\release\de-de.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\ru-ru.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\pl-pl.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\fr-fr.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\Release\it.txt; DestDir: {commonappdata}\HWL2\Languages; Flags: promptifolder
Source: HWL2-Applikation\bin\release\Helpfiles\Help-de.chm; DestDir: {app}\helpfiles
Source: Projekte\Datanorm\bin\release\Datanorm.dll; DestDir: {app}\connectors\datanorm; Flags: ignoreversion
Source: Projekte\Datanorm\bin\Release\converter\DATANK05.exe; DestDir: {app}\connectors\datanorm; Flags: ignoreversion
Source: Projekte\Datanorm\bin\Release\converter\DATANDAT.DAT; DestDir: {app}\connectors\datanorm; Flags: ignoreversion
Source: Projekte\Datanorm\bin\release\Datanorm.dll; DestDir: {app}\connectors\SHK-Connect; Flags: ignoreversion


[Dirs]
Name: {app}\de
Name: {app}\TemplateDataBase
Name: {commonappdata}\HWL2
Name: {commonappdata}\HWL2\Languages; Languages: 
Name: {app}\connectors
Name: {app}\helpfiles
Name: {app}\connectors\datanorm
Name: {app}\connectors\CommonImport
Name: {app}\connectors\SHK-Connect
[Languages]
Name: Polish; MessagesFile: compiler:Languages\Polish.isl
Name: French; MessagesFile: compiler:Languages\French.isl
Name: Dutch; MessagesFile: compiler:Languages\Dutch.isl
Name: German; MessagesFile: compiler:Languages\German.isl
Name: Spanish; MessagesFile: compiler:Languages\Spanish.isl
Name: Italian; MessagesFile: compiler:Languages\Italian.isl
Name: english; MessagesFile: compiler:Default.isl
Name: Russian; MessagesFile: compiler:Languages\Russian.isl
[Icons]
Name: {group}\HWL-2; Filename: {app}\HWL2.exe; Comment: Startet HWL2: Angebote /Rechnungen; Languages: 
[Run]
Filename: {app}\HWL2.exe; Flags: postinstall nowait; Languages: 
