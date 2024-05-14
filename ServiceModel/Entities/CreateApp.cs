using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModel.Model;

namespace ServiceModel.Entities
{
    public class CreateApp
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public List<NumberQuestion> NumberQuestion { get; set; }
        public List<MultiChoiceQuestion> MultiChoiceQuestions { get; set; }
        public List<DateQuestion> DateQuestion { get; set; }
        public List<ParagraphQuestion> ParagraphQuestion { get; set; }
        public List<DropdownQuestion> DropdownQuestion { get; set; }
        public List<YesNoQuestion> YesNoQuestion { get; set; }
    }
}
