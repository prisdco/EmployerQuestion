using ServiceModel.Enums;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Entities
{
    public class DropdownQuestionAnswer : Question
    {
        public string QuestionTitle { get; set; }
        public List<string> ChoiceAnswer { get; set; }
        public EnableOption enableOption { get; set; }
        public string? AnswerToOtherOption { get; set; } = "";

        public override Task<CreateApp> ProcessQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
