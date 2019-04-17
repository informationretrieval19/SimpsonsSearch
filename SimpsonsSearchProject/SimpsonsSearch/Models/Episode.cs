using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch.Models
{
	public class Episode
	{
		public string id { get; set; }
		public string title { get; set; }
		public string original_air_date { get; set; }
		public string production_code { get; set; }
		public string season { get; set; }
		public string number_in_season { get; set; }
		public string number_in_series { get; set; }
		public string us_viewers_in_millions { get; set; }
		public string views { get; set; }
		public string imdb_rating { get; set; }
		public string imdb_votes { get; set; }
		public string image_url { get; set; }
		public string video_url { get; set; }
	}
}
