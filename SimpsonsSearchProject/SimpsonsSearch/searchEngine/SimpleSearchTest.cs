using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class SimpleSearchTest : SimpleSearchBase
    {
        public SimpleSearchTest(IConversionService conversionService) : base(conversionService)
        {
        }

        public override string LuceneDir => @"index/test";

        

    }
}
