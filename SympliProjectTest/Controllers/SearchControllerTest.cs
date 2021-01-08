using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Threading.Tasks;
using SympliProject.Controllers;
using Microsoft.Extensions.Caching.Memory;
using SympliProject.Interfaces;
using SympliProject.Enums;
using SympliProject.Managers;

namespace SympliProjectTest.Controllers
{
    public class SearchControllerTest
    {

        [Theory]
        [InlineData(SearchManagerType.Google)]
        [InlineData(SearchManagerType.Bing)]
        public async Task Search_AcceptsCorrectRoutes(SearchManagerType searchEngine)
        {
            //Arrange
            var keywords = "term1 term2";
            var url = "www.example.com";
            var searchController = getSUT();

            //Act
            var result = await searchController.Get(searchEngine.ToString(), keywords, url, 100);
        }

        [Fact]
        public async Task Search_ThrowsOnIncorrectRoutes()
        {
            //Arrange
            var keywords = "term1 term2";
            var url = "www.example.com";
            var searchController = getSUT();

            //Act
            await Assert.ThrowsAsync<ArgumentException>(() => searchController.Get("Invalid", keywords, url, 100));
        }

        private SearchController getSUT()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var mockFactory = new Mock<ISearchManagerFactory>();
            mockFactory.Setup(x => x.GetSearchManager(SearchManagerType.Google))
                .Returns(new GoogleSearchManager());
            mockFactory.Setup(x => x.GetSearchManager(SearchManagerType.Bing))
                .Returns(new BingSearchManager());
            mockFactory.Setup(x => x.GetSearchManager(SearchManagerType.Invalid))
                .Throws<ArgumentException>();

            return new SearchController(mockFactory.Object, cache);
        }


    }
}
