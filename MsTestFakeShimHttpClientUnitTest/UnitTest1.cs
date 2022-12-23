namespace FakeShimHttpClientMsTestUnitTest.Test
{
    using Microsoft.QualityTools.Testing.Fakes;
    using Newtonsoft.Json.Linq;
    using System.Net;
    using System.Net.Http.Fakes;
    [TestClass, TestCategory(nameof(FakeShimHttpClientMsTestUnitTest))]
    public class FakeShimHttpClientMsTestUnitTest
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
                var httpClient = new HttpClient
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
    }
}