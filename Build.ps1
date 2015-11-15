param(
    [String] $majorMinor = "0.0",  # 2.0
    [String] $patch = "0",         # $env:APPVEYOR_BUILD_VERSION
    [String] $customLogger = "",   # C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll
    [Switch] $notouch,
    [String] $sln                  # e.g ReflectInsight-Extension-Name
)

function Set-AssemblyVersions($informational, $assembly)
{
    (Get-Content assets/VersionInfo.cs) |
        ForEach-Object { $_ -replace """1.0.0.0""", """$assembly""" } |
        ForEach-Object { $_ -replace """1.0.0""", """$informational""" } |
        ForEach-Object { $_ -replace """1.1.1.1""", """$($informational).0""" } |
        Set-Content assets/VersionInfo.cs
}

function Install-NuGetPackages($solution)
{
	(New-Object Net.WebClient).DownloadFile('https://www.nuget.org/nuget.exe', 'C:\Tools\NuGet\NuGet.exe')
    nuget restore $solution
}

function Invoke-MSBuild($solution, $customLogger)
{
    if ($customLogger)
    {
        msbuild "$solution" /verbosity:minimal /p:Configuration=Release /logger:"$customLogger"
    }
    else
    {
        msbuild "$solution" /verbosity:minimal /p:Configuration=Release
    }
}

function Invoke-NuGetPackProj($csproj)
{
    nuget pack -Prop Configuration=Release -Symbols $csproj
}

function Invoke-NuGetPackSpec($nuspec, $version)
{
    nuget pack $nuspec -Version $version -OutputDirectory ..\..\
}

function Invoke-NuGetPack($version)
{
    ls src/**/*.csproj |
        Where-Object { -not ($_.Name -like "*net40*") } |
        ForEach-Object { Invoke-NuGetPackProj $_ }
}

function Invoke-Build($majorMinor, $patch, $customLogger, $notouch, $sln)
{
    $package="$majorMinor.$patch"
    $slnfile = "$sln.sln"

    Write-Output "$sln $package"

    if (-not $notouch)
    {
        $assembly = "$majorMinor.0.0"

        Write-Output "Assembly version will be set to $assembly"
        Set-AssemblyVersions $package $assembly
    }

    Install-NuGetPackages $slnfile
    
    Invoke-MSBuild $slnfile $customLogger

    Invoke-NuGetPack $package
}

$ErrorActionPreference = "Stop"

if (-not $sln)
{
    $slnfull = ls *.sln |
        Where-Object { -not ($_.Name -like "*net40*") } |
        Select -first 1

    $sln = $slnfull.BaseName
}

Invoke-Build $majorMinor $patch $customLogger $notouch $sln

