using ServiceModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServiceModel.Entities
{
    public class CandidateData
    {
        [JsonIgnore]
        public string? id { get; set; } = "";
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IDNumber { get; set; }
        public string? DateofBirth { get; set; }
        public Gender Gender { get; set; }
        [JsonIgnore]
        public string? CandidateId { get; set; } = "";
        public List<NumberQuestionAnswer> NumberQuestionAnswer { get; set; }
        public List<MultichoiceAnswer> MultichoiceAnswers { get; set; }
        public List<DateQuestionAnswer> DateQuestionAnswer { get; set; }
        public List<ParagraphQuestionAnswer> ParagraphQuestionAnswer { get; set; }
        public List<DropdownQuestionAnswer> DropdownQuestionAnswer { get; set; }
        public List<YesNoQuestionAnswer> YesNoQuestionAnswer { get; set; }
    }
}
