using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class SimpleSearchTest : SimpleSearchBase
    {
        // hier können alle methoden und attribute der klasse simplesearchbase überschrieben werden 
        public SimpleSearchTest(IConversionService conversionService) : base(conversionService)
        {
        }

        public override string LuceneDir => @"index/test";

        public override void BuildIndex()
        {
            // eigene implementation einfügen
        }

        public override SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs)
        {
            return base.CompileResults(searcher, topDocs);
        }

        public override Document BuildDocument(ScriptLine scriptLine)
        {
            return base.BuildDocument(scriptLine);
        }
    }
}
