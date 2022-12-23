namespace Microshaoft
{
    using Microsoft.QualityTools.Testing.Fakes;
    using Newtonsoft.Json.Linq;
    using System.Net;
    using System.Net.Http.Fakes;
    [TestClass, TestCategory(nameof(MsTestFakeShimHttpClientUnitTest))]
    public class MsTestFakeShimHttpClientUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (ShimsContext.Create())
            {
                //ShimHttpClient.Constructor = (@this) =>
                //{
                //    Console.WriteLine($"Fake {nameof(ShimHttpClient)}");
                //};

                ShimHttpClient.AllInstances.SendAsyncHttpRequestMessage = (x, y) =>
                {
                    Console.WriteLine(y.RequestUri);
                    var json = $@"{{ ""result"" : ""Fake {nameof(ShimHttpClient.AllInstances.SendAsyncHttpRequestMessage)}.{nameof(HttpResponseMessage)}"" }}";
                    return
                        Task
                            .FromResult
                                (
                                    new HttpResponseMessage()
                                    {
                                        StatusCode = HttpStatusCode.OK
                                        ,
                                        Content = new StringContent
                                                    (
                                                        json
                                                    )
                                    }
                                );
                };

                //ShimHttpContent.AllInstances.ReadAsStringAsync = (x) =>
                //{
                //    return
                //        Task
                //            .FromResult
                //                    ("9999");
                //};

                var baseAddress = "https://www.fake.com";
                HttpClient httpClient = new ()
                {
                    BaseAddress = new Uri(baseAddress),
                    Timeout = TimeSpan.FromMinutes(5)
                };
                var relativeUrl = $"fake";
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(relativeUrl, UriKind.Relative))
                {
                    Content = new StringContent("{}")
                };
                var responseMessage = httpClient.SendAsync(requestMessage).Result;
                Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
                var json = responseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseMessage.StatusCode);
                Console.WriteLine(json);
                var result = JObject.Parse(json);
                Assert.IsNotNull(result);
                Assert.IsTrue(result is not null);
                Assert.IsTrue(result!["result"]!.Value<string>()!.StartsWith("fake", StringComparison.OrdinalIgnoreCase));
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            var divideByZeroException = new DivideByZeroException();
            var exceptionMessage = divideByZeroException.Message;
            Assert
                .That
                .Throws
                    <DivideByZeroException>
                        (
                            () =>
                            {
                                Task
                                    .Run
                                        (
                                            () =>
                                            {
                                                throw new Exception
                                                            (
                                                                $"Outter Exception"
                                                                , divideByZeroException
                                                                //, new NullReferenceException()

                                                            );
                                            }
                                        )
                                    .Wait();
                            }
                            , exceptionMessage
                        );
        }
        [TestMethod]
        public void TestMethod3()
        {
            var divideByZeroException = new DivideByZeroException();
            var exceptionMessage = new AggregateException().Message;
            Assert
                .That
                .Throws
                    <AggregateException>
                        (
                            () =>
                            {
                                Task
                                    .Run
                                        (
                                            () =>
                                            {
                                                throw new Exception
                                                            (
                                                                $""
                                                                //, divideByZeroException
                                                                , new NullReferenceException("", new AggregateException())

                                                            );
                                            }
                                        )
                                    .Wait();
                            }
                            , exceptionMessage
                        );
        }
        [TestMethod]
        public void TestMethod4()
        {
            var divideByZeroException = new DivideByZeroException();
            var exceptionMessage = new AggregateException().Message;
            Assert
                .That
                .Throws
                    <AggregateException>
                        (
                            () =>
                            {
                                throw new Exception
                                            (
                                                $"Outter Exception"
                                                //, divideByZeroException
                                                , new AggregateException()
                                            );
                            }
                            , exceptionMessage
                            //, drillDownInnerExceptions: false
                        );
        }
    }
}