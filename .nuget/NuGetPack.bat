@echo off
set /p version="Version: "
"C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe" ..\Elmah.SqlServer.EFInitializer.sln /P:Configuration=Release
rmdir /S /D content
rmdir /S /D lib
xcopy ..\Elmah.SqlServer.EFInitializer\content content\ /S /Y
xcopy ..\Elmah.SqlServer.EFInitializer\bin\Release\Elmah.SqlServer.EFInitializer.dll lib\4.5\ /Y
nuget pack Elmah.SqlServer.EFInitializer.nuspec -Version %version%
pause