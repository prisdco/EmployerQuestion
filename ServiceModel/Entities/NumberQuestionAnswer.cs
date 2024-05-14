using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Entities
{
    public class NumberQuestionAnswer : Question
    {
        public string QuestionTitle { get; set; }
        public string QuestionTitleAnswer { get; set; }

        public override Task<CreateApp> ProcessQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
