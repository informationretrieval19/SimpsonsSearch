using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpsonsSearchProject.searchEngine;
using SimpsonsSearchProject.ViewModels;

namespace SimpsonsSearchProject
{
	public class SearchController : Controller
	{
		public IActionResult Index()
		{
			var model = new IndexViewModel();
			model.ScriptLines = new List<ScriptLine>()
			{
				new ScriptLine()
				{
					Id = 1,
					Text = "hey homer"
				},
				new ScriptLine()
				{
					Id = 2,
					Text = "ups"
				}
			};
			return View(model);
		}
	}
}
