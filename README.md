# MsTest Fake Shim HttpClient UnitTest

## Visual Studio Developer Command Line Usage:
```
# The command can be used in Azure Pipeline CI/CD with pool vmImage: 'windows-latest' VSTest related step 
vstest.console.exe MoqFakeShimHttpClientUnitTests\bin\Debug\net6.0\MoqFakeShimHttpClientUnitTests.dll /logger:"console;verbosity=detailed"
```
Above Command Line Console Right Output:
```
Test Run Failed.
Total tests: 6
     Passed: 4
     Failed: 2

Passed TestMethod1 [165 ms]
  Standard Output Messages:
 fake
 OK
 { "result" : "Fake SendAsyncHttpRequestMessage.HttpResponseMessage" }


  Passed TestMethod2 [40 ms]
  Passed TestMethod3 [2 ms]
  Failed TestMethod4 [9 ms]
  Error Message:
   Assert.IsTrue failed. Expected exception of type System.AggregateException with a message of "One or more errors occurred." but expected exception with actual message of "One or more errors occurred.aaa" was thrown instead.
The caught actual "System.AggregateException" as below:
<<<<<<<<<<<<<<<<<<<<<<<<<<
System.AggregateException: One or more errors occurred.aaa
>>>>>>>>>>>>>>>>>>>>>>>>>>

  Stack Trace:
     at Microshaoft.AssertHelper.processExpectedExceptionMessage(Exception exception, String expectedExceptionMessage) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 57
   at Microshaoft.AssertHelper.Throws(Assert this, Action action, Type expectedExceptionType, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 254
   at Microshaoft.AssertHelper.Throws[TExpectedException](Assert this, Action action, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 90
   at Microshaoft.MsTestFakeShimHttpClientUnitTest.TestMethod4() in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\MsTestFakeShimHttpClientUnitTest\UnitTest1.cs:line 136

  Failed TestMethod5 [< 1 ms]
  Error Message:
   Assert.Fail failed. Expected exception of type "System.AggregateException" but no exception was thrown.
  Stack Trace:
     at Microshaoft.AssertHelper.Throws(Assert this, Action action, Type expectedExceptionType, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 239
   at Microshaoft.AssertHelper.Throws[TExpectedException](Assert this, Action action, String expectedExceptionMessage, Action`1 onProcessAction, Boolean needDrillDownInnerExceptions) in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\AssertHelper\AssertHelper.cs:line 90
   at Microshaoft.MsTestFakeShimHttpClientUnitTest.TestMethod5() in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\MsTestFakeShimHttpClientUnitTest\UnitTest1.cs:line 163

  Passed TestMethod6 [< 1 ms]
  Standard Output Messages:
 Expected Exception Type:
        System.Exception
 Caught Actual Exception Type:
        System.AggregateException,
 Caught Actual Exception Message:
        One or more errors occurred.,
 Caught Actual Exception:
        System.AggregateException: One or more errors occurred.


  Passed TestMethod7 [1 ms]
  Standard Output Messages:
 Expected Exception Type:
        System.AggregateException
 Caught Actual Exception Type:
        System.AggregateException,
 Caught Actual Exception Message:
        One or more errors occurred. (One or more errors occurred.1),
 Caught Actual Exception:
        System.AggregateException: One or more errors occurred. (One or more errors occurred.1)
  ---> System.Exception: One or more errors occurred.1
  ---> System.NullReferenceException: One or more errors occurred.2
  ---> System.AggregateException: One or more errors occurred.
    --- End of inner exception stack trace ---
    --- End of inner exception stack trace ---
    at Microshaoft.MsTestFakeShimHttpClientUnitTest.<>c__DisplayClass6_0.<TestMethod7>b__1() in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\MsTestFakeShimHttpClientUnitTest\UnitTest1.cs:line 249
    at System.Threading.Tasks.Task`1.InnerInvoke()
    at System.Threading.Tasks.Task.<>c.<.cctor>b__272_0(Object obj)
    at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
 --- End of stack trace from previous location ---
    at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
    at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
    --- End of inner exception stack trace ---
    at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
    at System.Threading.Tasks.Task.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
    at System.Threading.Tasks.Task.Wait()
    at Microshaoft.MsTestFakeShimHttpClientUnitTest.<>c__DisplayClass6_0.<TestMethod7>b__0() in D:\MyGitHub\MsTestFakeShimHttpClientUnitTest\MsTestFakeShimHttpClientUnitTest\UnitTest1.cs:line 244
    at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException[T](Action action, String message, Object[] parameters)



Test Run Failed.
Total tests: 7
     Passed: 5
     Failed: 2
 Total time: 1.4524 Seconds
```