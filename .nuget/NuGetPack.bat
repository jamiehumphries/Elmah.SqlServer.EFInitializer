@echo off
set /p version="Version: "
xcopy ..\Elmah.SqlServer.EFInitializer\bin\Release\Elmah.SqlServer.EFInitializer.dll lib\4.5\ /Y
nuget pack Elmah.SqlServer.EFInitializer.nuspec -Version %version%
pause