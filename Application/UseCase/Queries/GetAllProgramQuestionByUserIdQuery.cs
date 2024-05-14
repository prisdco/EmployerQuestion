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
    public class GetAllProgramQuestionByUserIdQuery : IRequest<ResultViewModel>
    {
        private string UserId { get; set; }

        public GetAllProgramQuestionByUserIdQuery(string _UserId)
        {
            UserId = _UserId;
        }

        public class GetAllProgramQuestionByUserIdQueryCommandHandler : IRequestHandler<GetAllProgramQuestionByUserIdQuery, ResultViewModel>
        {
            private readonly ILogger<GetAllProgramQuestionByUserIdQueryCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public GetAllProgramQuestionByUserIdQueryCommandHandler(ILogger<GetAllProgramQuestionByUserIdQueryCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(GetAllProgramQuestionByUserIdQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start GetAllProgramQuestionByUserIdQuery Query.");

                try
                {   // create program

                    var _Response = await _ICreateApp.GetAllProgramQuestionByUserIdAsync(request.UserId);
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
