using SympliProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliProject.Interfaces
{
    public interface ISearchManagerFactory
    {
        public ISearchManager GetSearchManager(SearchManagerType searchManagerType);
    }
}
