using Microsoft.AspNetCore.Http;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Entities
{
    public class FileQuestion : Question
    {
        public string QuestionTitle { get; set; }
        public IFormFile formFile {  get; set; }

        public override Task<CreateApp> ProcessQuestion()
        {
            //Implement logic here
            throw new NotImplementedException();
        }
    }
}
