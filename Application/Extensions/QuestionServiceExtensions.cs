using Microsoft.Extensions.DependencyInjection;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class QuestionServiceExtensions
    {
        //Adding a new class of Question
        //Check the ServiceModel for OptionQuestion as an example
        public static void AddQuestionType<T>(this IServiceCollection services) where T : Question
        {
            // For example, registering it in a factory or updating some list
            services.AddScoped(typeof(T));
        }
    }
}
