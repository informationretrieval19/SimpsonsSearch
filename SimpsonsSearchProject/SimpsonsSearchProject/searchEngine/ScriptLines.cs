using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SimpsonsSearchProject.searchEngine
{
	public class ScriptLines
	{
		public int Id { get; set; }
		public int EpisodeId { get; set; }
		public int Number { get; set; }
		public string Text { get; set; }
		public long Timestamp { get; set; }
		public bool IsSpeakingLine { get; set; }
		public int CharacterId { get; set; }
		public int LocationId { get; set; }
		public string CharacterText{ get; set; }
		public string LocationText{ get; set; }
		public int SpokenWords { get; set; }
		public string NormalizedText { get; set; }
		public int WordCount { get; set; }

	}
}
