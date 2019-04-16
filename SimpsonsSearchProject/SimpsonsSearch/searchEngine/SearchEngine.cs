using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SimpsonsSearch.searchEngine
{
	public class SearchEngine : ISearchEngine
	{
		private readonly SimpsonsIndex index;

		public SearchEngine()
		{
			index = new SimpsonsIndex(Settings.IndexLocation);
		}

		public void BuildIndex() => index.BuildIndex(GetDataFromFile());

		public IEnumerable<ScriptLine> GetDataFromFile() =>
			JsonConvert.DeserializeObject<List<ScriptLine>>(File.ReadAllText(Settings.ScriptLineJsonFile),
				settings: new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });


		public SearchResults Search(string query) => index.Search(query);
	}
}