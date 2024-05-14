using ServiceModel.Entities;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Interface
{
    public interface ICreateApp
    {
        Task<IEnumerable<CreateApp>> GetAllProgramQuestionAsync(string userId);
        Task<CreateApp> CreateProgramQuestionAsync(CreateApp createApp);
        Task DeleteProgramQuestionAsync(string ProgramId, string userId);
        Task<CreateApp> UpdateProgramQuestionAsync(CreateApp createApp);
        Task<CreateApp> GetProgramQuestionByIdAsync(string ProgramId, string userId);
        Task<CreateApp> UpdateProgramQuestionAsync(Question question);        
    }
}
