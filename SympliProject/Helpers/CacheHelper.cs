using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliProject.Helpers
{
    public static class CacheHelper
    {
        public static string GetCacheKey(List<string> input)
        {
            return String.Join('_', input);
        }
    }
}
