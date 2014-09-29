@echo off
set /p version="Version: "
msbuild Elmah.SqlServer.EFInitializer.sln /P:Configuration=Release
rmdir /S /Q content
rmdir /S /Q lib
xcopy Elmah.SqlServer.EFInitializer\content nuget-pack\content\ /S /Y
xcopy Elmah.SqlServer.EFInitializer\bin\Release\Elmah.SqlServer.EFInitializer.dll nuget-pack\lib\4.5\ /Y
.nuget\nuget pack nuget-pack\Elmah.SqlServer.EFInitializer.nuspec -Version %version%
pause
