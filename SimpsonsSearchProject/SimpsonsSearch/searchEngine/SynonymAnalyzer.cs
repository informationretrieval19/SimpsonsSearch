using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Synonym;
using Lucene.Net.Analysis.Util;
using Lucene.Net.Util;

namespace SimpsonsSearch.searchEngine
{
    public class SynonymAnalyzer : Analyzer
    {
        protected override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {
            
            var tokenizer = new StandardTokenizer(SimpleSearchBase.LUCENEVERSION, reader);


            var result = new SynonymFilter(tokenizer, GetSynonyms(), true);

            return new TokenStreamComponents(tokenizer, result);
        }

        
        // hier wortlisten er synonymmap hinzufügen
        public SynonymMap GetSynonyms()
        {

            var dictionaries = new Dictionaries();
            

            var sBuilder = new SynonymMap.Builder(true);
            
            for (int i = 1;  i <= dictionaries.alcoholDic.Count(); i++)
            {
                var key = $"key{i}";
                
                    sBuilder.Add(new CharsRef("alcohol"), new CharsRef(dictionaries.alcoholDic[key]), true);
                
            }

            for (int i = 1; i <= dictionaries.affairDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("affair"), new CharsRef(dictionaries.affairDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.actionDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("action"), new CharsRef(dictionaries.actionDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.animalsDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("animal"), new CharsRef(dictionaries.animalsDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.computingDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("computing"), new CharsRef(dictionaries.computingDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.crimeDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("crime"), new CharsRef(dictionaries.crimeDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.deathDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("death"), new CharsRef(dictionaries.deathDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.doomsdayDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("doomsday"), new CharsRef(dictionaries.doomsdayDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.educationDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("education"), new CharsRef(dictionaries.educationDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.environmentDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("environment"), new CharsRef(dictionaries.environmentDic[key]), true);

            }

            for (int i = 1; i <= dictionaries.fantasyDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("fantasy"), new CharsRef(dictionaries.fantasyDic[key]), true);

            }

            var synonyms = sBuilder.Build();
            return synonyms;
        }

        

    }
}
