using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class AdvancedSearchBase : SimpleSearchBase
    {
        public AdvancedSearchBase(IConversionService conversionService) : base(conversionService)
        {
        }
    }
}
