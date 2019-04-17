using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SimpsonsSearch.Helper;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
	public class SearchEngine : ISearchEngine
	{
		private readonly SimpsonsIndex _index;
		private const string IndexLocation = @"C:/Temp/Index";
		private readonly IConversionService _conversionService;

		public SearchEngine(IConversionService conversionService, SimpsonsIndex index)
		{
			_index = index;
			_conversionService = conversionService;
		}

		public void BuildIndex()
		{
			_index.BuildIndex(_conversionService.ConvertCsVtoScriptLines());
		} 

		public SearchResults Search(string query)
		{
			var searchResults = _index.Search(query);
			return searchResults;
		} 
	}
}