using SympliProject.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SympliProjectTest.Helpers
{
    public class CacheHelperTest
    {
        [Fact]
        public void CacheHelper_GetCacheKey_ReturnsCorrectResult()
        {
            var parameters = new List<string> { "param1", "param2", "param3" };
            var expected = "param1_param2_param3";
            var actual = CacheHelper.GetCacheKey(parameters);
            Assert.Equal(expected, actual);
        }
    }
}
