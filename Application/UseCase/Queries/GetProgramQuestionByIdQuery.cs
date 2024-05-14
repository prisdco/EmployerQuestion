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
    public class GetProgramQuestionByIdQuery : IRequest<ResultViewModel>
    {
        private string UserId { get; set; }
        private string ProgramId { get; set; }

        public GetProgramQuestionByIdQuery(string _UserId, string _ProgramId)
        {
            UserId = _UserId;
            ProgramId = _ProgramId;
        }

        public class GetProgramQuestionByIdQueryCommandHandler : IRequestHandler<GetProgramQuestionByIdQuery, ResultViewModel>
        {
            private readonly ILogger<GetProgramQuestionByIdQueryCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public GetProgramQuestionByIdQueryCommandHandler(ILogger<GetProgramQuestionByIdQueryCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(GetProgramQuestionByIdQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start GetProgramQuestionByIdQuery Query.");

                try
                {   // Query for Getting Program Question

                    var _Response = await _ICreateApp.GetProgramQuestionByIdAsync(request.ProgramId, request.UserId);
                    return ResultViewModel.Ok(_Response);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return ResultViewModel.Fail("Program Question Failed To GetProgramQuestionByIdQuery.");
                }
            }
        }
    }
}