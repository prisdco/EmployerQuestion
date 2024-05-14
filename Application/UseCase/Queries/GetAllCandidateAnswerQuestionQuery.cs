using MediatR;
using Microsoft.Extensions.Logging;
using ServiceModel.Interface;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Queries
{
    public class GetAllCandidateAnswerQuestionQuery : IRequest<ResultViewModel>
    {
        public GetAllCandidateAnswerQuestionQuery()
        {

        }

        public class GetAllCandidateAnswerQuestionQueryHandler : IRequestHandler<GetAllCandidateAnswerQuestionQuery, ResultViewModel>
        {
            private readonly ILogger<GetAllCandidateAnswerQuestionQueryHandler> _logger;
            private readonly ICandidateApp _ICandidateApp;


            public GetAllCandidateAnswerQuestionQueryHandler(ILogger<GetAllCandidateAnswerQuestionQueryHandler> logger, ICandidateApp ICandidateApp)
            {
                _logger = logger;
                _ICandidateApp = ICandidateApp;
            }

            public async Task<ResultViewModel> Handle(GetAllCandidateAnswerQuestionQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start GetAllProgramQuestion Query.");

                try
                {   // create program

                    var _Response = await _ICandidateApp.GetAllCandidateAnswerQuestionAsync();
                    return ResultViewModel.Ok(_Response);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return ResultViewModel.Fail("Program Question Failed To Modify.");
                }
            }
        }
    }
}
