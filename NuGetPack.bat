@echo off
set /p version="Version: "
msbuild Elmah.SqlServer.EFInitializer.sln /P:Configuration=Release-NET40
msbuild Elmah.SqlServer.EFInitializer.sln /P:Configuration=Release-NET45
rmdir /S /Q nuget-pack\content
rmdir /S /Q nuget-pack\lib
xcopy Elmah.SqlServer.EFInitializer\content nuget-pack\content\ /S /Y
xcopy Elmah.SqlServer.EFInitializer\bin\Release-NET40\Elmah.SqlServer.EFInitializer.dll nuget-pack\lib\net40\ /Y
xcopy Elmah.SqlServer.EFInitializer\bin\Release-NET45\Elmah.SqlServer.EFInitializer.dll nuget-pack\lib\net45\ /Y
.nuget\nuget pack nuget-pack\Elmah.SqlServer.EFInitializer.nuspec -Version %version%
pause
