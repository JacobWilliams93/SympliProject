using SympliProject.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SympliProjectTest.Managers
{
    public class GoogleSearchManagerTest
    {

        [Fact]
        public async Task GetSearchResultPositions_ReturnsZeroWhenNotFound()
        {
            // Arrange 
            var searchManager = new GoogleSearchManager();
            var keywords = new List<string>() {"ffgadsgsdfgafdsfdsgfa"};
            var url = "www.fake-example.com";

            // Act 
            var result = await searchManager.GetSearchResultPositions(keywords, url, 100);

            // Assert
            Assert.Single(result);
            Assert.Equal(0, result[0]);
        }

        [Fact]
        public async Task GetSearchResultPositions_ReturnsCorrectResult()
        {
            // Arrange 
            var searchManager = new GoogleSearchManager();
            var keywords = new List<string>() { "google" };
            var url = "www.google.com";

            // Act 
            var result = await searchManager.GetSearchResultPositions(keywords, url, 100);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1, result[0]);
        }
    }
}
