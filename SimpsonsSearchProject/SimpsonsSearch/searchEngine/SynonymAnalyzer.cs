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

        
        // hier wortlisten der synonymmap hinzufügen
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

            for (int i = 1; i <= dictionaries.foodDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("food"), new CharsRef(dictionaries.foodDic[key]), true);

            }
            for (int i = 1; i <= dictionaries.fantasyDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("fantasy"), new CharsRef(dictionaries.fantasyDic[key]), true);

            }
            for (int i = 1; i <= dictionaries.getting_marriedDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("getting married"), new CharsRef(dictionaries.getting_marriedDic[key]), true);

            }
            for (int i = 1; i <= dictionaries.holidayDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("holiday"), new CharsRef(dictionaries.holidayDic[key]), true);

            }
            for (int i = 1; i <= dictionaries.insanityDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("insanity"), new CharsRef(dictionaries.insanityDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.internetDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("internet"), new CharsRef(dictionaries.internetDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.kidsDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("kids"), new CharsRef(dictionaries.kidsDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.lgbtqDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("lgbtq"), new CharsRef(dictionaries.lgbtqDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.mafiaDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("mafia"), new CharsRef(dictionaries.mafiaDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.medical_themedDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("medical"), new CharsRef(dictionaries.medical_themedDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.militaryDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("military"), new CharsRef(dictionaries.militaryDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.moviesDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("movies films"), new CharsRef(dictionaries.moviesDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.musicalDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("musical"), new CharsRef(dictionaries.musicalDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.politicsDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("politics"), new CharsRef(dictionaries.politicsDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.religionDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("religion"), new CharsRef(dictionaries.religionDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.road_tripsDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("road trip"), new CharsRef(dictionaries.road_tripsDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.romanceDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("romance"), new CharsRef(dictionaries.romanceDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.schoolDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("school"), new CharsRef(dictionaries.schoolDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.sportsDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("sports"), new CharsRef(dictionaries.sportsDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.super_heroesDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("super-heroes"), new CharsRef(dictionaries.super_heroesDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.travelDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("travel"), new CharsRef(dictionaries.travelDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.workDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("work"), new CharsRef(dictionaries.workDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.electionsDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("election"), new CharsRef(dictionaries.electionsDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.gun_controlDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("gun control"), new CharsRef(dictionaries.gun_controlDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.mobbingDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("mobbing"), new CharsRef(dictionaries.mobbingDic[key]), true);
            }
            for (int i = 1; i <= dictionaries.patriotismDic.Count(); i++)
            {
                var key = $"key{i}";

                sBuilder.Add(new CharsRef("patriotism"), new CharsRef(dictionaries.patriotismDic[key]), true);
            }
            
            var synonyms = sBuilder.Build();
            return synonyms;
        }
    }
}
