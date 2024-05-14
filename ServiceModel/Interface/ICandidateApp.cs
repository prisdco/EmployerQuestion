using ServiceModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Interface
{
    public interface ICandidateApp
    {
        Task<CandidateData> CreateCandidateAnswerQuestionAsync(CandidateData candidateData);
    }
}
