using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;

namespace SimpsonsSearch.Services
{
	public interface IConversionService
	{
		string ConvertMillisecondsToMinutes(double milliseconds);
		IEnumerable<ScriptLine> ConvertCsVtoScriptLines();
		IEnumerable<Episode> ConvertCsvToEpisodes();
	}
}
