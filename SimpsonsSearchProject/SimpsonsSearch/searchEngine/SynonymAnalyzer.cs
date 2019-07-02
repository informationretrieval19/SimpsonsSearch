using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Synonym;
using Lucene.Net.Util;

namespace SimpsonsSearch.searchEngine
{
    public class SynonymAnalyzer : Analyzer
    {
        protected override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {

            var synonyms = GetSynonyms();

            var tokenizer = new StandardTokenizer(SimpleSearchBase.LUCENEVERSION, reader);
            var result = new SynonymFilter(tokenizer, synonyms, true);
            return new TokenStreamComponents(tokenizer, result);
        }


        public SynonymMap GetSynonyms()
        {
            var base1 = "weihnachtsmann";
            var syn1 = "christmas";

            var sBuilder = new SynonymMap.Builder(true);
            sBuilder.Add(new CharsRef(base1), new CharsRef(syn1), true);
            var synonyms = sBuilder.Build();
            return synonyms;
        }

    }
}