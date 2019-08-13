using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch.searchEngine
{
    public class Dictionaries
    {
        public Dictionary<string, string> actionDic = new Dictionary<string, string>
        {
            {"key1", "hit"},
            {"key2", "robbery"},
            {"key3", "criminal"},
            {"key4", "chase"},
            {"key5", "skate"},
            {"key6", "skateboard"},
            {"key7", "shoot"},
            {"key8", "run"},
            {"key9", "thriller"},
            {"key10", "beat"},
            {"key11", "hit'n'run"},
        };

        public Dictionary<string, string> affairDic = new Dictionary<string, string>
        {
            {"key1", "infidelity"},
            {"key2", "lover"},
            {"key3", "mistress"},
            {"key4", "intimate"},
            {"key5", "kiss"},
            {"key6", "betray"},
            {"key7", "sex"},
            {"key8", "polygamy"},
            {"key9", "scandal"},
            {"key10", "fling"},
            {"key11", "sexual relationship"},
            {"key12", "married"}

        };

        public Dictionary<string, string> alcoholDic = new Dictionary<string, string>
        {
            {"key1", "abuse"},
            {"key2", "addiction"},
            {"key3", "bar"},
            {"key4", "beer"},
            {"key5", "wine"},
            {"key6", "cider"},
            {"key7", "duff"},
            {"key8", "brewery"},
            {"key9", "vomit"},
            {"key10", "underage"},
            { "key11", "drink"},
            { "key12", "cocktail"},
            { "key13", "disorder"},
            { "key14", "liquor"}

        };


        public Dictionary<string, string> animalsDic = new Dictionary<string, string>
        {
            {"key1", "frog"},
            {"key2", "toad"},
            {"key3", "scorpion"},
            {"key4", "spider"},
            {"key5", "bird"},
            {"key6", "crow"},
            {"key7", "fly"},
            {"key8", "fish"},
            {"key9", "ant"},
            {"key10", "bee"},
            {"key11", "beetle"},
            {"key12", "cockroach"},
            {"key13", "bear"},
            {"key14", "dog"},
            {"key15", "cat"},
            {"key16", "fox"},
            {"key17", "horse"},
            {"key18", "goat"},
            {"key19", "giraffe"},
            {"key20", "mouse"},
            {"key21", "rat"},
            {"key22", "sheep"},
            {"key23", "tiger"},
            {"key24", "whale"},
            {"key25", "wolf"},
            {"key26", "elephant"},
            {"key27", "lion"},
            {"key28", "snake"},
            {"key29", "crocodile"},
            {"key30", "chicken"}

        };

        public Dictionary<string, string> computingDic = new Dictionary<string, string>
        {
            {"key1", "program"},
            {"key2", "code"},
            {"key3", "game"},
            {"key4", "algorithm"},
            {"key5", "backup"},
            {"key6", "byte"},
            {"key7", "bit"},
            {"key8", "bug"},
            {"key9", "keyboard"},
            {"key10", "mouse"},
            {"key11", "screen"},
            {"key12", "data"},
            {"key13", "output"},
            {"key14", "command"},
            {"key15", "ai"},
            {"key16", "array"},
            {"key17", "java"},
            {"key18", "linux"},
            {"key19", "shell"},
            {"key20", "typing"},

        };

        public Dictionary<string, string> crimeDic = new Dictionary<string, string>
        {
            {"key1", "shooting"},
            {"key2", "robbery"},
            {"key3", "arms"},
            {"key4", "hit"},
            {"key5", "criminal"},
            {"key6", "beat"},
            {"key7", "guilty"},
            {"key8", "gun"},
            {"key9", "kidnap"},
            {"key10", "police"},
            {"key11", "officer"},
            {"key12", "speeding"},
            {"key13", "investigation"},
            {"key14", "weapon"},
            {"key15", "witness"},
            {"key16", "kill"},
            {"key17", "rape"},
            {"key18", "riot"},
            {"key19", "vandalism"},
            {"key20", "steal"},
            {"key21", "thief"},
            {"key22", "fight"},
            {"key23", "damage"},
            {"key24", "punish"},
            {"key25", "murder"}

        };

        public Dictionary<string, string> deathDic = new Dictionary<string, string>
        {
            {"key1", "die"},
            {"key2", "funeral"},
            {"key3", "accident"},
            {"key4", "corpse"},
            {"key5", "carcass"},
            {"key6", "cremation"},
            {"key7", "enbalm"},
            {"key8", "pyre"},
            {"key9", "cemetery"},
            {"key10", "autopsy"},
            {"key11", "suicide"},
            {"key12", "homicide"},
            {"key13", "ressurrection"},
            {"key14", "murder"},

        };

        public Dictionary<string, string> doomsdayDic = new Dictionary<string, string>
        {
            {"key1", "apocalypse"},
            {"key2", "judgement"},
            {"key3", "day"},
            {"key4", "reckoning"},
            {"key5", "last"},
            {"key6", "armageddon"},
            {"key7", "fate"},
            {"key8", "end"},
            {"key9", "world"},
            {"key10", "catastrophe"},

        };

        public Dictionary<string, string> educationDic = new Dictionary<string, string>
        {
            {"key1", "school"},
            {"key2", "assignment"},
            {"key3", "blackboard"},
            {"key4", "book"},
            {"key5", "pen"},
            {"key6", "calculator"},
            {"key7", "chalk"},
            {"key8", "teacher"},
            {"key9", "class"},
            {"key10", "classroom"},
            {"key11", "yard"},
            {"key12", "break"},
            {"key13", "exam"},
            {"key14", "test"},
            {"key15", "homework"},
            {"key16", "learn"},
            {"key17", "lesson"},
            {"key18", "science"},
            {"key19", "student"}
        };

        public Dictionary<string, string> environmentDic = new Dictionary<string, string>
        {
            {"key1", "climate"},
            {"key2", "acid"},
            {"key3", "biodiversity"},
            {"key4", "monoxide"},
            {"key5", "dioxide"},
            {"key6", "earthquake"},
            {"key7", "deforestation"},
            {"key8", "drought"},
            {"key9", "energy"},
            {"key10", "extiction"},
            {"key11", "flood"},
            {"key12", "fumes"},
            {"key13", "nature"},
            {"key14", "resources"},
            {"key15", "global warming"},
            {"key16", "greenhouse"},
            {"key17", "effect"},
            {"key18", "renewable"},
            {"key19", "pollution"},
            {"key20", "recycle"},
            {"key21", "tsunami"},
            {"key22", "volcano"},
            {"key23", "waste"},
            {"key24", "animal rights"},
            {"key25", "protection"},
            {"key26", "rubbish"},
            {"key27", "garbage"},
            {"key28", "trash"},
            {"key29", "carbon"},
            {"key30", "toxic"}

        };

        public Dictionary<string, string> fantasyDic = new Dictionary<string, string>
        {
            {"key1", "dwarf"},
            {"key2", "elf"},
            {"key3", "prince"},
            {"key4", "quest"},
            {"key5", "sorcery"},
            {"key6", "witch"},
            {"key7", "werewolf"},
            {"key8", "vampire"},
            {"key9", "evil"},
            {"key10", "ghost"},
            {"key11", "mystery"},
            {"key12", "myth"},
            {"key13", "pixie"},
            {"key14", "knight"},
            {"key15", "potion"},
            {"key16", "supernatural"},
            {"key17", "wand"},
            {"key18", "alchemy"},
            {"key19", "demon"},
            {"key20", "dragon"},
            {"key21", "fairy"},
            {"key22", "kingdom"},
            {"key23", "legend"}
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