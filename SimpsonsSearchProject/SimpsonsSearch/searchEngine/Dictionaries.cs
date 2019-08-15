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
		
		public Dictionary<string, string> foodDic = new Dictionary<string, string>
		{
			{"key1", "fruit"},
			{"key2", "vegetable"},
			{"key3", "bacon"},
			{"key4", "apple"},
			{"key5", "almond"},
			{"key6", "anchovy"},
			{"key7", "appetizer"},
			{"key8", "apsaragus"},
			{"key9", "avocado"},
			{"key10", "bake"},
			{"key11", "bagel"},
			{"key12", "bacon"},
			{"key13", "broccoli"},
			{"key14", "dinner"},
			{"key15", "supper"},
			{"key16", "eat"},
			{"key17", "breakfast"},
			{"key18", "lunch"},
			{"key19", "brunch"},
			{"key20", "burrito"},
			{"key21", "doughnut"},
			{"key22", "cake"},
			{"key23", "calorie"},
			{"key24", "candy"},
			{"key25", "cheese"},
			{"key26", "chew"},
			{"key27", "chips"},
			{"key28", "chili"},
			{"key29", "desert"},
			{"key30", "diet"},
			{"key31", "dish"},
			{"key32", "edible"},
			{"key33", "fast food"},
			{"key34", "feed"},
			{"key35", "hamburger"},
			{"key36", "burger"},
			{"key37", "hungry"},
			{"key38", "junk food"},
			{"key39", "nutrition"},
			{"key40", "restaurant"},
			{"key41", "fries"},
		};
		
		public Dictionary<string, string> getting_marriedDic = new Dictionary<string, string>
		{
			{"key1", "marriage"},
			{"key2", "wedding"},
			{"key3", "husband"},
			{"key4", "wife"},
			{"key5", "wedding dress"},
			{"key6", "love"},
			{"key7", "anniversary"},
			{"key8", "vows"},
			{"key9", "ceremony"},
			{"key10", "relationship"},
			{"key11", "proposal"},
			
		};

		public Dictionary<string, string> holidayDic = new Dictionary<string, string>
		{
			{"key1", "Halloween"},
			{"key2", "Horror"},
			{"key3", "Pumpkin"},
			{"key4", "treehouse of horror"},
			{"key5", "christmas"},
			{"key6", "presents"},
			{"key7", "santa"},
			{"key8", "christmas eve"},
			{"key9", "christmas day"},
			{"key10", "ornaments"},
			{"key11", "snow"},
			{"key12", "reindeer"},
			{"key13", "santa"},
			{"key14", "valentines day"},
			{"key15", "valentine"},
			{"key16", "st patricks day"},
			{"key17", "ireland"},
			{"key18", "thanks giving"},
			{"key19", "turkey"},
			{"key20", "thanksgiving"}
			
		};

		public Dictionary<string, string> insanityDic = new Dictionary<string, string>
		{
			{"key1", "demented"},
			{"key2", "demonic"},
			{"key3", "twisted"},
			{"key4", "dementia"},
			{"key5", "sanity"},
			{"key6", "solitary"},
			{"key7", "mental"},
			{"key8", "asylum"},
			{"key9", "schizophrenia"},
			{"key10", "psychotic"},
			{"key11", "psychopath"},
			{"key12", "paradox"},
			{"key13", "demon"},
			{"key14", "crazy"},
			{"key15", "mad"},
			{"key16", "madness"},
			{"key17", "deranged"},
			{"key18", "delusional"},
			{"key19", "hallucination"},
			{"key20", "sociopath"}
		
		};
		
		public Dictionary<string, string> internetDic = new Dictionary<string, string>
		{
			{"key1", "web"},
			{"key2", "google"},
			{"key3", "amazon"},
			{"key4", "facebook"},
			{"key5", "www"},
			{"key6", "email"},
			{"key7", "virus"},
			{"key8", "browser"},
			{"key9", "nsa"},
			{"key10", "user"},
			{"key11", "domain"},
			{"key12", "online"},
			{"key13", "website"},
			{"key14", "malware"},
			{"key15", "post"},
			{"key16", "twitter"},
			{"key17", "tweet"},
			{"key18", "clicks"},
			{"key19", "cyberspace"},
			{"key20", "darkweb"},
			{"key21", "offline"},
			{"key22", "login"},
			{"key23", "log in"},
			{"key24", "youtube"},
			{"key25", "video"},
			{"key26", "spam"},
			{"key27", "wifi"},
			{"key28", "router"}
		
		};

		public Dictionary<string, string> kidsDic = new Dictionary<string, string>
		{
			{"key1", "playing"},
			{"key2", "child"},
			{"key3", "children"},
			{"key4", "son"},
			{"key5", "daughter"},
			{"key6", "kid"},
			{"key7", "young"},
			{"key8", "Ralph Wiggum"},
			{"key9", "Milhouse Van Houten"},
			{"key10", "Nelson Muntz"},
			{"key11", "Martin Prince "},
			{"key12", "Sherri and Terri"},
			{"key13", "Jimbo Jones"},
			{"key14", "Dolph Starbeam"},
			{"key15", "Kearney Zzywicz"},
			{"key16", "Ralph"},
			{"key17", "Nelson"},
			{"key18", "Milhouse"},
			{"key19", "Martin"},
			{"key20", "Sherri"},
			{"key21", "Terri"},
			{"key22", "Jimbo"},
			{"key23", "Dolph"},
			{"key24", "Kearny"},
			{"key25", "Bart"},
			{"key26", "Lisa"},
			{"key27", "Maggie"},
			{"key28", "Todd"},
			{"key29", "Rod"}
			
		};
		
		public Dictionary<string, string> lgbtqDic = new Dictionary<string, string>
		{
			{"key1", "lesbian"},
			{"key2", "gay"},
			{"key3", "transgender"},
			{"key4", "bi"},
			{"key5", "bisexual"},
			{"key6", "trans"},
			{"key7", "equality"},
			{"key8", "homosexual"},
			{"key9", "homophobia"},
			{"key10", "homophobe"},
			{"key11", "tranny"},
			{"key12", "asexual"},
			{"key13", "bicurious"},
			{"key14", "coming out"},
			{"key15", "fag"},
			{"key16", "faggot"},
			{"key17", "pansexual"}
			
		};

		public Dictionary<string, string> mafiaDic = new Dictionary<string, string>
		{
			{"key1", "organized crime"},
			{"key2", "terrorist"},
			{"key3", "criminal"},
			{"key4", "fat tony"},
			{"key5", "gang"},
			{"key6", "attack"},
			{"key7", "money laundry"}
			
		};

		public Dictionary<string, string> medical_themedDic = new Dictionary<string, string>
		{
			{"key1", "hospital"},
			{"key2", "specimen"},
			{"key3", "injection"},
			{"key4", "diagnosis"},
			{"key5", "examine"},
			{"key6", "paralyze"},
			{"key7", "autopsy"},
			{"key8", "patient"},
			{"key9", "doctor"},
			{"key10", "infectio"},
			{"key11", "vaccine"},
			{"key12", "surgery"},
			{"key13", "surgeon"}
			
		};

		public Dictionary<string, string> militaryDic = new Dictionary<string, string>
		{
			{"key1", "air force"},
			{"key2", "artillery"},
			{"key3", "army"},
			{"key4", "battlefield"},
			{"key5", "bomb"},
			{"key6", "bombardment"},
			{"key7", "bullet"},
			{"key8", "canon"},
			{"key9", "command"},
			{"key10", "combat"},
			{"key11", "colonel"},
			{"key12", "officer"},
			{"key13", "enemy"},
			{"key14", "garrison"},
			{"key15", "general"},
			{"key16", "grenade"},
			{"key17", "guerrilla"},
			{"key18", "infantry"},
			{"key19", "invasion"},
			{"key20", "leutenant"},
			{"key21", "major"},
			{"key22", "veteran"},
			{"key23", "officer"},
			{"key24", "pentagon"},
			{"key25", "recruit"},
			{"key26", "sergeant"},
			{"key27", "soldier"},
			{"key28", "tank"},
			{"key29", "war"}
			
		};

		public Dictionary<string, string> moviesDic = new Dictionary<string, string>
		{
			{"key1", "film"},
			{"key2", "video"},
			{"key3", "dvd"},
			{"key4", "stream"},
			{"key5", "actor"},
			{"key6", "actress"},
			{"key7", "producer"},
			{"key8", "soundtrack"},
			{"key9", "cameraman"},
			{"key10", "editor"},
			{"key11", "blooper"},
			{"key12", "cast"},
			{"key13", "cinema"},
			{"key14", "theater"}
			
		};

		public Dictionary<string, string> musicalDic = new Dictionary<string, string>
		{
			{"key1", "sing"},
			{"key2", "performance"},
			{"key3", "dance"},
			{"key4", "gypsy"},
			{"key5", "my fair lady"},
			{"key6", "sweeney todd"},
			{"key7", "cats"},
			{"key8", "guys and dolls"},
			{"key9", "west side story"}
		
		};

		public Dictionary<string, string> politicsDic = new Dictionary<string, string>
		{
			{"key1", "democracy"},
			{"key2", "anarchy"},
			{"key3", "revolution"},
			{"key4", "political"},
			{"key5", "president"},
			{"key6", "rights"},
			{"key7", "demonstration"},
			{"key8", "protest"},
			{"key9", "senate"},
			{"key10", "senator"},
			{"key11", "minister"},
			{"key12", "ministry"},
			{"key13", "election"},
			{"key14", "vote"},
			{"key15", "constitution"},
			{"key16", "government"},
			{"key17", "law"}
			
		};

		public Dictionary<string, string> religionDic = new Dictionary<string, string>
		{
			{"key1", "christian"},
			{"key2", "christianity"},
			{"key3", "catholic"},
			{"key4", "catholicism"},
			{"key5", "church"},
			{"key6", "priest"},
			{"key7", "believer"},
			{"key8", "buddhism"},
			{"key9", "jewish"},
			{"key10", "jew"},
			{"key11", "buddhist"},
			{"key12", "hindu"},
			{"key13", "hinduist"},
			{"key14", "islam"},
			{"key15", "islamic"},
			{"key16", "agnostic"},
			{"key17", "atheist"},
			{"key18", "mosque"},
			{"key19", "bible"}
			
		};
		
		public Dictionary<string, string> road_tripsDic = new Dictionary<string, string>
		{
			{"key1", "car"},
			{"key2", "road"},
			{"key3", "trip"},
			{"key4", "back seat"},
			{"key5", "front seat"},
			{"key6", "highway"},
			{"key7", "drive"},
			{"key8", "detour"},
			{"key9", "dead end"},
			{"key10", "fast lane"},
			{"key11", "tire"},
			{"key12", "fuel"},
			{"key13", "gas"},
			{"key14", "mph"},
			{"key15", "miles per hour"},
			{"key16", "speeding ticket"},
			{"key17", "traffic jam"},
			{"key18", "truck"}
			
		};

		public Dictionary<string, string> romanceDic = new Dictionary<string, string>
		{
			{"key1", "romantic"},
			{"key2", "flowers"},
			{"key3", "valentines day"},
			{"key4", "candles"},
			{"key5", "proposal"},
			{"key6", "wedding"},
			{"key7", "kiss"},
			{"key8", "bedroom"},
			{"key9", "hot"},
			{"key10", "compliment"},
			{"key11", "roses"}
			
		};
		
		public Dictionary<string, string> schoolDic = new Dictionary<string, string>
		{
			{"key1", "assignment"},
			{"key2", "blackboard"},
			{"key3", "book"},
			{"key4", "pen"},
			{"key5", "calculator"},
			{"key6", "teacher"},
			{"key7", "classroom"},
			{"key8", "yard"},
			{"key9", "break"},
			{"key10", "exam"},
			{"key11", "test"},
			{"key12", "homework"},
			{"key13", "learn"},
			{"key14", "lesson"},
			{"key15", "class"},
			{"key16", "education"},
			{"key17", "student"}
			
		};

		public Dictionary<string, string> sportsDic = new Dictionary<string, string>
		{
			{"key1", "aerobics"},
			{"key2", "archery"},
			{"key3", "arena"},
			{"key4", "exercise"},
			{"key5", "badminton"},
			{"key6", "ball"},
			{"key7", "basketball"},
			{"key8", "baseball"},
			{"key9", "rugby"},
			{"key10", "bicycle"},
			{"key11", "bike"},
			{"key12", "billard"},
			{"key13", "pool"},
			{"key14", "boxing"},
			{"key15", "medal"},
			{"key16", "champion"},
			{"key17", "competition"},
			{"key18", "curling"},
			{"key19", "marathon"},
			{"key20", "triathlon"},
			{"key21", "dodgeball"},
			{"key22", "gym"},
			{"key23", "fit"},
			{"key24", "fitness"},
			{"key25", "jog"},
			{"key26", "olympics"},
			{"key27", "play"},
			{"key28", "winner"}
		
		};
		
		public Dictionary<string, string> super_heroesDic = new Dictionary<string, string>
		{
			{"key1", "villain"},
			{"key2", "evil"},
			{"key3", "superpower"},
			{"key4", "nemesis"},
			{"key5", "shape shifting"},
			{"key6", "super speed"},
			{"key7", "rapid healing"},
			{"key8", "telekinesis"},
			{"key9", "batman"},
			{"key10", "superman"},
			{"key11", "wonderwoman"},
			{"key12", "hulk"},
			{"key13", "iron man"},
			{"key14", "spiderman"},
			{"key15", "catwoman"},
			{"key16", "avengers"},
			{"key17", "black widow"},
			{"key18", "doctor strange"},
			{"key19", "joker"},
			{"key20", "magneto"},
			{"key21", "thor"},
			{"key22", "wolverine"}
			
		};
		
		public Dictionary<string, string> travelDic = new Dictionary<string, string>
		{
			{"key1", "airplane"},
			{"key2", "airport"},
			{"key3", "amusement park"},
			{"key4", "cabin"},
			{"key5", "boat"},
			{"key6", "beach"},
			{"key7", "camping"},
			{"key8", "cruise"},
			{"key9", "ship"},
			{"key10", "plane"},
			{"key11", "departure"},
			{"key12", "arrival"},
			{"key13", "destination"},
			{"key14", "expedition"},
			{"key15", "fly"},
			{"key16", "tour"},
			{"key17", "holiday"},
			{"key18", "hotel"},
			{"key19", "hostel"},
			{"key20", "journey"},
			{"key21", "passport"},
			{"key22", "postcard"},
			{"key23", "resort"},
			{"key24", "safari"},
			{"key25", "sea"},
			{"key26", "ski"},
			{"key27", "swim"},
			{"key28", "tourist"},
			{"key29", "train"},
			{"key30", "vacation"},
			{"key31", "yacht"}

		};

		public Dictionary<string, string> workDic = new Dictionary<string, string>
		{
			{"key1", "nuclear power plant"},
			{"key2", "working"},
			{"key3", "overtime"},
			{"key4", "shift"},
			{"key5", "colleague"},
			{"key6", "occupation"},
			{"key7", "job"},
			{"key8", "payment check"},
			{"key9", "salary"}
		
		};
		
		public Dictionary<string, string> electionsDic = new Dictionary<string, string>
		{
			{"key1", "ballot"},
			{"key2", "poll"},
			{"key3", "vote"},
			{"key4", "voting"},
			{"key5", "president"},
			{"key6", "government"},
			{"key7", "parties"},
			{"key8", "democracy"},
			{"key9", "party"},
			{"key10", "democrats"},
			{"key11", "republicans"},
			{"key12", "presidential"}
			
		};

		public Dictionary<string, string> gun_controlDic = new Dictionary<string, string>
		{
			{"key1", "weapon"},
			{"key2", "license"},
			{"key3", "handgun"},
			{"key4", "gun"},
			{"key5", "security"},
			{"key6", "pistol"},
			{"key7", "ban"},
			{"key8", "safety"},
			{"key9", "mass shooting"},
			{"key10", "shooting"},
			{"key11", "law"},
			{"key12", "firearm"},
			{"key13", "arms"},
			{"key14", "rifle"},
			{"key15", "freedom"},
			{"key16", "revolver"},
			{"key17", "lobby"},
			{"key18", "self defense"}
		
		};

		public Dictionary<string, string> mobbingDic = new Dictionary<string, string>
		{
			{"key1", "bully"},
			{"key2", "abuse"},
			{"key3", "aggressive"},
			{"key4", "alone"},
			{"key5", "beat"},
			{"key6", "cruel"},
			{"key7", "child"},
			{"key8", "insult"},
			{"key9", "mean"},
			{"key10", "opress"},
			{"key11", "taunt"},
			{"key12", "rude"},
			{"key13", "cry"},
			{"key14", "tears"},
			{"key15", "trauma"},
			{"key16", "peers"}
			
		};

		public Dictionary<string, string> patriotismDic = new Dictionary<string, string>
		{
			{"key1", "anthem"},
			{"key2", "america"},
			{"key3", "usa"},
			{"key4", "u.s.a"},
			{"key5", "united states of america"},
			{"key6", "nation"},
			{"key7", "4th of july"},
			{"key8", "fourth of july"},
			{"key9", "pride"},
			{"key10", "proud"},
			{"key11", "homeland"},
			{"key12", "independence"},
			{"key13", "celebration"},
			{"key14", "patriot"},
			{"key15", "patriotic"}
			
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
            {"education", "t23" },
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
