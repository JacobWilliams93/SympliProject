using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SympliProject.Interfaces
{
    public interface ISearchManager
    {
        public static HttpClient HttpClient { get; }
        public Task<List<int>> GetSearchResultPositions(List<string> keywords, string url, int numResults);
    }
}
