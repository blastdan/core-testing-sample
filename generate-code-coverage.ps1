New-Item -ItemType Directory -Force -Path report\nuget
New-Item -ItemType Directory -Force -Path report\coverage

$nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$nugetOutput = "$PSScriptRoot\report\nuget\nuget.exe"
$start_time = Get-Date

$openCoverVersion = "4.6.519"
$reportGeneratorVersion = "3.1.2"

Invoke-WebRequest -Uri $nugetUrl -OutFile $nugetOutput
Write-Output "Time taken: $((Get-Date).Subtract($start_time).Seconds) second(s)"

.\report\nuget\nuget.exe install OpenCover -Version $openCoverVersion -OutputDirectory .\report\nuget -DirectDownload
.\report\nuget\nuget.exe install ReportGenerator -Version $reportGeneratorVersion -OutputDirectory .\report\nuget -DirectDownload


$openCoverCommand = "report\nuget\OpenCover.$openCoverVersion\tools\OpenCover.Console.exe"
$reportGeneratorCommand = "report\nuget\ReportGenerator.$reportGeneratorVersion\tools\ReportGenerator.exe"

& $openCoverCommand -register:user `
                    -target:"C:\Program Files\dotnet\dotnet.exe" `
                    -targetargs:"test core-testing-sample.test\core-testing-sample.test.csproj" `
                    -searchdirs:"core-testing-sample\core-testing-sample.test\bin\Debug\netcoreapp2.0" `
                    -filter:"+[core-testing-sample*]*" `
                    -oldStyle `
                    -output:report\coverage\CoreTestingSample.coverage.xml `
                    -excludebyattribute:*.ExcludeFromCodeCoverage*
& $reportGeneratorCommand -reports:"report\coverage\CoreTestingSample.coverage.xml" -targetdir:report -reporttypes:"Html;HtmlSummary;Badges;TextSummary"
cp .\report\badge_linecoverage.png .