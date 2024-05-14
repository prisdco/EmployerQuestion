using Newtonsoft.Json;
using ServiceModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Model
{
    public abstract class Question
    {
        [JsonProperty()]
        public string QuestionId { get; set; }
        [JsonProperty()]
        public string ProgramId { get; set; }
        [JsonProperty()]
        public string type { get; set; }

        public abstract Task<CreateApp> ProcessQuestion();
    }
}
