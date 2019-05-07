using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.Helper
{
	public class ConversionService : IConversionService
	{
		public IEnumerable<ScriptLine> _scriptLineRecords;
		public IEnumerable<Episode> _episodeRecords;
		
		public double ConvertMillisecondsToMinutes(double milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
		}

		public IEnumerable<ScriptLine> ConvertCsVtoScriptLines()
		{
			IList<string> _badRecords = new List<string>();

			using (var reader = new StreamReader(@"data/simpsons_script_lines.csv"))
			using (var csv = new CsvReader(reader))
			{
				csv.Configuration.Delimiter = ",";
				//csv.Configuration.IgnoreQuotes = true;
				csv.Configuration.MissingFieldFound = null;
			

				csv.Configuration.BadDataFound = context =>
				{
					_badRecords.Add(context.RawRecord);
				};

				_scriptLineRecords = csv.GetRecords<ScriptLine>().ToList();
				return _scriptLineRecords;
			}
		}

		public IEnumerable<Episode> ConvertCsvToEpisodes()
		{
			IList<string> _badRecords = new List<string>();

			using (var reader = new StreamReader(@"Data\simpsons_episodes.csv"))
			using (var csv = new CsvReader(reader))
			{
				csv.Configuration.Delimiter = ",";
				//csv.Configuration.IgnoreQuotes = true;


				csv.Configuration.BadDataFound = context =>
				{
					_badRecords.Add(context.RawRecord);
				};
				
					_episodeRecords = csv.GetRecords<Episode>().ToList();
				
				
				return _episodeRecords;
			}
		}
	}
}
