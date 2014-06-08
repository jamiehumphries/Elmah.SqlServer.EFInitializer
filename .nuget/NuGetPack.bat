@echo off
set /p version="Version: "
xcopy ..\Elmah.SqlServer.EFInitializer\bin\Release\Elmah.SqlServer.EFInitializer.dll lib\4.5\ /Y
xcopy ..\Elmah.SqlServer.EFInitializer\content content\ /S /Y
nuget pack Elmah.SqlServer.EFInitializer.nuspec -Version %version%
pause