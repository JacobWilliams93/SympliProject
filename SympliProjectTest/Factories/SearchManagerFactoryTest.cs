using SympliProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SympliProject.Managers;
using SympliProject.Interfaces;
using SympliProject.Factories;

namespace SympliProjectTest.Factories
{
    public class SearchManagerFactoryTest
    {
        [Theory]
        [InlineData(SearchManagerType.Bing)]
        [InlineData(SearchManagerType.Google)]
        public void SearchManagerFactory_ReturnsCorrectService(SearchManagerType searchManagerType)
        {
            // Arrange
            var searchManagerFactory = new SearchManagerFactory();

            // Act
            var result = searchManagerFactory.GetSearchManager(searchManagerType);

            // Assert
            switch (searchManagerType)
            {
                case SearchManagerType.Google:
                    Assert.IsType<GoogleSearchManager>(result);
                    break;
                case SearchManagerType.Bing:
                    Assert.IsType<BingSearchManager>(result);
                    break;
            }
        }

        [Fact]
        public void SearchManagerFactory_ThrowsExceptionOnIncorrectType()
        {
            // Arrange
            var searchManagerFactory = new SearchManagerFactory();

            // Act and Assert
            Assert.Throws<NotImplementedException>(() => searchManagerFactory.GetSearchManager(SearchManagerType.Invalid));
        }
    }
}
