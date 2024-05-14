using Application.UseCase.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServiceModel.Interface;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.UseCase.Commands.UpdateSubQuestionCommand;

namespace Application.UseCase.Queries
{
    public class GetAllProgramQuestionQuery : IRequest<ResultViewModel>
    {
        

        public GetAllProgramQuestionQuery()
        {
            
        }

        public class GetAllProgramQuestionQueryCommandHandler : IRequestHandler<GetAllProgramQuestionQuery, ResultViewModel>
        {
            private readonly ILogger<GetAllProgramQuestionQueryCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public GetAllProgramQuestionQueryCommandHandler(ILogger<GetAllProgramQuestionQueryCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(GetAllProgramQuestionQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start GetAllProgramQuestion Query.");

                try
                {   // create program

                    var _Response = await _ICreateApp.GetAllProgramQuestionAsync();
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
