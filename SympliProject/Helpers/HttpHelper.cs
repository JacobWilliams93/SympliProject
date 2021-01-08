using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SympliProject.Helpers
{
    public static class HttpHelper
    {
        private static HttpClient _httpClient;

        public static HttpClient HttpClient
        {
            get
            {
                if(_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }
                return _httpClient;
            }
        }

        public async static Task<HttpResponseMessage> GetResponse(string requestUrl)
        {
            return await HttpClient.GetAsync(requestUrl);
        }
    }
}
