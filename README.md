# MsTest Fake Shim HttpClient UnitTest

## Visual Studio Developer Command Line Usage:
```
# The command can be used in Azure Pipeline CI/CD with pool vmImage: 'windows-latest' VSTest related step 
vstest.console.exe MsTestFakeShimHttpClientUnitTest\bin\Debug\net6.0\MsTestFakeShimHttpClientUnitTest.dll /logger:"console;verbosity=detailed"
```