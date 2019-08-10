using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch.Services
{
    public class JsonBuilder
    {
        public void BuildJsonFile()
        {
            var json = new JObject(
           new JProperty("Topic_Id", "1"),
           new JProperty("SceneId", "2"),
           new JProperty("Relevance", "good"));

            using (var file = File.CreateText(@"evaluation.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, json);
            }
        }

    }
}


