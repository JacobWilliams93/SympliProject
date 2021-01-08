using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SympliProject.Enums;
using SympliProject.Interfaces;
using SympliProject.Managers;

namespace SympliProject.Factories
{
    public class SearchManagerFactory: ISearchManagerFactory
    {
        public ISearchManager GetSearchManager(SearchManagerType searchManagerType)
        {

            switch(searchManagerType)
            {
                case SearchManagerType.Google:
                    return new GoogleSearchManager();
                case SearchManagerType.Bing:
                    return new BingSearchManager();
                default:
                    throw new NotImplementedException($"{searchManagerType} is not currently supported");
            }
        }
    }
}
