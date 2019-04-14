using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace luceneTest
{
	public class Repository
	{
		public static IEnumerable<Movie> GetMoviesFromFile() => JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(Settings.MovieJsonFile));
	}
}
