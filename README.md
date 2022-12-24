# MsTest Fake Shim HttpClient UnitTest

## Visual Studio Developer Command Line Usage:
```
# The command can be used in Azure Pipeline CI/CD with pool vmImage: 'windows-latest' VSTest related step 
vstest.console.exe MsTestFakeShimHttpClientUnitTest\bin\Debug\net6.0\MsTestFakeShimHttpClientUnitTest.dll /logger:"console;verbosity=detailed"
```
Above Command Line Console Right Output:
```
Test Run Failed.
Total tests: 6
     Passed: 4
     Failed: 2

  Passed TestMethod1 [211 ms]
  Standard Output Messages:
 fake
 OK
 { "result" : "Fake SendAsyncHttpRequestMessage.HttpResponseMessage" }


  Passed TestMethod2 [59 ms]
  Passed TestMethod3 [3 ms]
  Failed TestMethod4 [11 ms]
  Error Message:
   Assert.IsTrue failed. Expected exception of type System.AggregateException with a message of "One or more errors occurred." but expected exception with actual message of "One or more errors occurred.aaa" was thrown instead.
The caught actual "System.AggregateException" as below:
<<<<<<<<<<<<<<<<<<<<<<<<<<
System.AggregateException: One or more errors occurred.aaa
>>>>>>>>>>>>>>>>>>>>>>>>>>

  Stack Trace:
     at Microshaoft.AssertHelper.processExpectedExceptionMessage(Exception exception, String expectedExceptionMessage) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 57
   at Microshaoft.AssertHelper.Throws(Assert this, Action action, Type expectedExceptionType, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 250
   at Microshaoft.AssertHelper.Throws[TExpectedException](Assert this, Action action, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 90
   at Microshaoft.MsTestFakeShimHttpClientUnitTest.TestMethod4() in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\MsTestFakeShimHttpClientUnitTest\UnitTest1.cs:line 136

  Failed TestMethod5 [1 ms]
  Error Message:
   Assert.Fail failed. Expected exception of type "System.AggregateException" but no exception was thrown.
  Stack Trace:
     at Microshaoft.AssertHelper.Throws(Assert this, Action action, Type expectedExceptionType, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 235
   at Microshaoft.AssertHelper.Throws[TExpectedException](Assert this, Action action, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 90
   at Microshaoft.MsTestFakeShimHttpClientUnitTest.TestMethod5() in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\MsTestFakeShimHttpClientUnitTest\UnitTest1.cs:line 163

  Passed TestMethod6 [1 ms]
  Standard Output Messages:
 Expected Exception Type:
        System.Exception
 Caught Actual Exception Type:
        System.AggregateException,
 Caught Actual Exception Message:
        One or more errors occurred.,
 Caught Actual Exception:
        System.AggregateException: One or more errors occurred.



Test Run Failed.
Total tests: 6
     Passed: 4
     Failed: 2
 Total time: 1.7830 Seconds
```