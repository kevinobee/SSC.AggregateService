@echo Off
cd %~dp0

SETLOCAL

set target=%1
if "%target%" == "" (
   set target=Full
)
set config=%2
if "%config%" == "" (
   set config=Debug
)

nuget restore src\Build\packages.config -PackagesDirectory packages -ConfigFile src\build\nuget\NuGet.Config

packages\GitVersion.CommandLine.3.6.5\tools\GitVersion.exe /updateassemblyinfo AssemblyInfo.cs /ensureassemblyinfo

MSBuild.exe Build\Build.proj /t:%target% /p:Configuration=%config% /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false