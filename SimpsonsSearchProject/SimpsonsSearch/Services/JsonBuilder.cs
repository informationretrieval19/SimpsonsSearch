using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpsonsSearch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch.Services
{
    public class JsonBuilder
    {
        public void BuildJsonFile(EvaluationModel model)
        {
            var dateTime = new DateTime().ToString();
            dateTime = DateTime.Now.ToString("HHmmss tt");

            try {
                using (var file = File.CreateText($@"EvaluationFiles/{model.TopicId}{model.Relevance}{model.SceneId}evaluation.json"))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, model);
                }
            } catch { }
            
        }

    }
}


