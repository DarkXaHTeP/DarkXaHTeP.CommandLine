mkdir .\coverage

.\opencover\OpenCover.Console.exe ^
  -target:".\dotnet\dotnet.exe" ^
  -targetargs:"test /p:DebugType=full -f netcoreapp2.0 -c Release ..\CommandLine.Test\CommandLine.Test.csproj" ^
  -mergeoutput ^
  -hideskipped:File ^
  -output:coverage/coverage.xml ^
  -oldStyle ^
  -filter:"+[DarkXaHTeP.CommandLine*]* -[DarkXaHTeP.CommandLine.Test*]*" ^
  -searchdirs:"../CommandLine.Test/bin/Release/netcoreapp2.0" ^
  -register:user
