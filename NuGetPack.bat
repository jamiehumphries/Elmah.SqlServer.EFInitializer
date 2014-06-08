@echo off
set /p version="Version: "
"C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild" Elmah.SqlServer.EFInitializer.sln /P:Configuration=Release
rmdir /S /Q content
rmdir /S /Q lib
xcopy Elmah.SqlServer.EFInitializer\content nuget-pack\content\ /S /Y
xcopy Elmah.SqlServer.EFInitializer\bin\Release\Elmah.SqlServer.EFInitializer.dll nuget-pack\lib\4.5\ /Y
.nuget\NuGet pack nuget-pack\Elmah.SqlServer.EFInitializer.nuspec -Version %version%
pause