#define MsTestUnitTests
#if MsTestUnitTests
namespace Microshaoft
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    //using static Microsoft.QualityTools.Testing.Fakes.FakesDelegates;

    public static class AssertHelper
    {
        private static Exception drillDownInnerException(this Exception @this, Func<Exception, bool> onProcessFunc = null!)
        {
            var result = @this;
            while (result != null)
            {
                if (onProcessFunc != null)
                {
                    bool @return = onProcessFunc(result);
                    if (@return)
                    {
                        break;
                    }
                }
                result = result.InnerException;
            }
            return result!;

        }

        private static void processExpectedExceptionMessage
                                        (
                                            Exception exception
                                            , string expectedExceptionMessage = null!
                                        )
        {
            if
                (
                    !string
                        .IsNullOrEmpty
                                (
                                    expectedExceptionMessage
                                )
                )
            {
                Assert
                    .IsTrue
                        (
                            string.Compare(expectedExceptionMessage, exception.Message, true) == 0
                            , $@"Expected exception with a message of ""{expectedExceptionMessage}"" but exception with message of ""{exception.Message}"" was thrown instead.
<<<<<<<<<<<<<<<<<<<<<<<<<<
{exception}
>>>>>>>>>>>>>>>>>>>>>>>>>>
"
                        );
            }
        }
        public static void Throws
                                <TExpectedException>
                                    (
                                        this Assert @this
                                        , Action action
                                        , string expectedExceptionMessage = null!
                                        , Action<TExpectedException> onProcessAction = null!
                                        , bool drillDownInnerExceptions = true
                                    )
                                        where TExpectedException : Exception
        {
            Exception caughtException = null!;
            Exception caughtExpectedException = null!;
            var foundExpected = false;
            void drillDownInnerExceptionsProcess(Exception e)
            {
                if (drillDownInnerExceptions)
                {
                    caughtExpectedException = e
                                                .drillDownInnerException
                                                    (
                                                        (ee) =>
                                                        {
                                                            foundExpected =
                                                                (
                                                                    ee is TExpectedException
                                                                    &&
                                                                    (
                                                                        string
                                                                            .Compare
                                                                                (
                                                                                    expectedExceptionMessage
                                                                                    , ee.Message
                                                                                    , true
                                                                                ) == 0
                                                                        ||
                                                                        string.IsNullOrEmpty(expectedExceptionMessage)
                                                                    )
                                                                );
                                                            return foundExpected;
                                                        }
                                                    );

                }
            }

            try
            {
                action();
            }
            catch (AggregateException aggregateException)
            {
                caughtException = aggregateException;
                if (caughtException is TExpectedException)
                {
                    if
                        (
                            string
                                .Compare
                                    (
                                        expectedExceptionMessage
                                        , caughtException.Message
                                        , true
                                    ) == 0
                            ||
                            string.IsNullOrEmpty(expectedExceptionMessage)
                        )
                    {
                        foundExpected = true;
                    }
                }
                if (!foundExpected)
                {
                    if (drillDownInnerExceptions)
                    {
                        if (caughtException.InnerException != null)
                        {
                            drillDownInnerExceptionsProcess(caughtException.InnerException);
                        }
                    }
                }
                if (!foundExpected)
                {
                    var innerExceptions = aggregateException.Flatten().InnerExceptions;
                    if (drillDownInnerExceptions)
                    {
                        foreach (var e in innerExceptions)
                        {
                            drillDownInnerExceptionsProcess(e);
                            if (foundExpected)
                            {
                                break;
                            }
                        }
                    }
                    if (!foundExpected)
                    {
                        caughtExpectedException = null!;
                    }
                }
            }
            catch (TExpectedException expectedException)
            {
                caughtException = expectedException;
                caughtExpectedException = expectedException;
                drillDownInnerExceptionsProcess(caughtExpectedException);

            }
            catch (Exception exception)
            {
                caughtException = exception;
                caughtExpectedException = exception;
                drillDownInnerExceptionsProcess(caughtExpectedException);
            }
            Assert
                .IsTrue
                    (
                        foundExpected
                        , $@"Expected exception of type ""{typeof(TExpectedException)}"" but type of ""{caughtException.GetType()}"" was thrown instead.
<<<<<<<<<<<<<<<<<<<<<<<<<<
{caughtException}
>>>>>>>>>>>>>>>>>>>>>>>>>>
"
                    );
            processExpectedExceptionMessage(caughtExpectedException, expectedExceptionMessage);
            onProcessAction?.Invoke((TExpectedException)caughtExpectedException);
        }
    }
}
#endif