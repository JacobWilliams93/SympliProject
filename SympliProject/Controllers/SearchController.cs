using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SympliProject.Factories;
using SympliProject.Helpers;
using SympliProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliProject.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private ISearchManagerFactory _searchManagerFactory;
        private IMemoryCache _cache;
        MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(60));
        public SearchController(ISearchManagerFactory searchManagerFactory, IMemoryCache memoryCache)
        {
            _searchManagerFactory = searchManagerFactory;
            _cache = memoryCache;
        }
        [HttpGet("{searchEngine}")]
        public async Task<List<int>> Get([FromRoute] string searchEngine, string keywords, string matchUrl, int numResults)
        {
            Enums.SearchManagerType searchManagerType;
            var keywordsArr = keywords.Split(' ').ToList();
            if (Enum.TryParse(searchEngine, true, out searchManagerType))
            {
                var searchManager = _searchManagerFactory.GetSearchManager(searchManagerType);
                var result = await _cache.GetOrCreateAsync(CacheHelper.GetCacheKey(keywordsArr.Append($"{matchUrl}_{searchEngine}").ToList()), 
                    entry => {
                        entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(60));
                        return searchManager.GetSearchResultPositions(keywordsArr, matchUrl, numResults);
                    });
                return result;
            }
            throw new ArgumentException($"The search engine \"{searchEngine}\" is not supported.");
        }
    }
}
