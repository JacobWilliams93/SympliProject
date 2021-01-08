using SympliProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SympliProject.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace SympliProject.Managers
{
    public class GoogleSearchManager : ISearchManager
    {

        private string baseUrl = "https://google.com/search";

        public async Task<List<int>> GetSearchResultPositions(List<string> keywords, string url, int numResults)
        {
            string requestUrl = $"{baseUrl}?q={String.Join('+', keywords)}&num={numResults}";
            HttpResponseMessage response = await HttpHelper.GetResponse(requestUrl);
            string htmlResponse = await response.Content.ReadAsStringAsync();
            return parseSearchResults(htmlResponse, url);
        }

        private List<int> parseSearchResults(string searchResults, string url)
        {
            List<int> result = new List<int>();
            string pattern = @"<a[^>]*href=""([^""]*)""><h3";
            MatchCollection regexResult = Regex.Matches(searchResults, pattern);
            for(int i=0; i < regexResult.Count; i++)
            {
                if (regexResult[i].Groups[1].Value.Contains(url))
                {
                    result.Add(i + 1);
                }
            }
            if(result.Count == 0)
            {
                result.Add(0);
            }
            return result;
        }
    }
}
