namespace SimpsonsSearch.searchEngine
{
	public static class Settings
	{
		// Ort wo der Index gespeichert wird
		public static string IndexLocation { get; set; } = @"C:\Temp\Index";
		// Ort wo die Datei liegt die eingelesen wird
		public static string ScriptLineJsonFile { get; set; } = @"C:\repos\uni\SimpsonsSearch\SimpsonsSearchProject\SimpsonsSearch\scriptlines.json";
	}
}
