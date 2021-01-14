rem List the installed .NET SDKs
dotnet --list-sdks

rem Print some env vars
set PATH
set DOTNET_ROOT
set DOTNET_ROOT(x86)
set DOTNET_MULTILEVEL_LOOKUP
set DOTNET_INSTALL_DIR

powershell Tree .\dev\MRTCore\ /F | Select-Object -Skip 2
powershell Tree .\BuildOutput\ /F | Select-Object -Skip 2
