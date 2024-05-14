using MediatR;
using Microsoft.Extensions.Logging;
using ServiceModel.Entities;
using ServiceModel.Interface;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Commands
{
    public class CreateCandidateAnswerQuestionCommand : IRequest<ResultViewModel>
    {
        public CandidateData candidateData { get; set; }

        public class CreateCandidateAnswerQuestionCommandHandler : IRequestHandler<CreateCandidateAnswerQuestionCommand, ResultViewModel>
        {
            private readonly ILogger<CreateCandidateAnswerQuestionCommandHandler> _logger;
            private readonly ICandidateApp _ICandidateApp;


            public CreateCandidateAnswerQuestionCommandHandler(ILogger<CreateCandidateAnswerQuestionCommandHandler> logger, ICandidateApp ICandidateApp)
            {
                _logger = logger;
                _ICandidateApp = ICandidateApp;
            }

            public async Task<ResultViewModel> Handle(CreateCandidateAnswerQuestionCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start Candidate AnswerQuestion Submission.");

                try
                {   // create program

                    var _Response = await _ICandidateApp.CreateCandidateAnswerQuestionAsync(request.candidateData);
                    return ResultViewModel.Ok(_Response);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return ResultViewModel.Fail("Candidate Answers Failed To Submit.");
                }
            }
        }
    }
}
