using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch.searchEngine
{
    public class Dictionaries
    {
        public Dictionary<string, string> alcoholDic = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"key1", "abuse"},
            {"key2", "addiction"},
            {"key3", "alcoholic"},
            {"key4", "alcoholism"},
            {"key5", "bar"},
            {"key6", "beer"},
            {"key7", "wine"},
            {"key8", "cider"},
            {"key9", "duff"},
            {"key10", "brew"},
            {"key11", "brewery"},
            {"key12", "vomit"},
            {"key13", "underage"}, {"key14", "drink"}, {"key15", "cocktail"}, {"key16", "disorder"}, {"key17", "liquer"}

        };

        public Dictionary<string, string> topicDic = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"Homer", "t1"},
            {"Krusty", "t2"},
            {"Bart Bob", "t3"},
            {"Homer tavern", "t4"},
            {"Stupid Flanders", "t5"},
            {"Okily Dokily", "t6"},
            {"Lisa saxophone", "t7"},
            {"Lisa Bart treehouse", "t8"},
            {"How many times is Bart in the Detention Room", "t9"},
            {"Who says donut most often", "t10"},
            {"Where is Bart’s favorite location", "t11"},
            {"lisa milhouse alone", "t12"},
            {"top words in episode 100", "t13"},
            {"most relevant words in season 1", "t14"},
            {"action", "t15"},
            {"affair", "t16"},
            {"alcohol", "t17"},
            {"animal", "t18"},
            {"computing", "t19"},
            {"crime", "t20"},
            {"death", "t21"},
            {"doomsday", "t22"},
            {"environment", "t24"},
            {"fantasy", "t25"},
            {"food", "t26"},
            {"getting married", "t27"},
            {"holiday", "t28"},
            {"insanity", "t29"},
            {"internet", "t30"},
            {"kids", "t31"},
            {"lgbtq", "t32"},
            {"mafia", "t33"},
            {"medical themed", "t34"},
            {"military", "t35"},
            {"movies films", "t36"},
            {"musical", "t37"},
            {"politics", "t38"},
            {"religion", "t39"},
            {"road trip", "t40"},
            {"romance", "t41"},
            {"school", "t42"},
            {"sports", "t43"},
            {"super-heroes", "t44"},
            {"travel", "t45"},
            {"work", "t46"},
            {"election", "t47"},
            {"gun control", "t48"},
            {"mobbing", "t49"},
            {"patriotism", "t50"},

        };
    }
}