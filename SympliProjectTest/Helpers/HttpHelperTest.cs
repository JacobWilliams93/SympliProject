using SympliProject.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SympliProjectTest.Helpers
{
    public class HttpHelperTest
    {
        [Fact]
        public void HttpHelper_HttpClient_UsesSameInstance()
        {

            var client1 = HttpHelper.HttpClient;
            var client2 = HttpHelper.HttpClient;
            Assert.Equal(client1, client2);
        }

        [Fact]
        public async void HttpHelper_GetResponseTest()
        {
            string testUrl = "https://google.com";
            var result = await HttpHelper.GetResponse(testUrl);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
    }
}
