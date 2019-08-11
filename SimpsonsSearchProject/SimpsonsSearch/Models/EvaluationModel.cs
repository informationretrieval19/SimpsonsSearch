using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch.Models
{
    public class EvaluationModel
    {
        public string TopicId { get; set; }
        public string SceneId { get; set; }
        public int Relevance { get; set; }
    }
}
