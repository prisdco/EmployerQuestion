using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public class CreateProgramQuestionCommand : IRequest<ResultViewModel>
    {
        public CreateApp CreateApp { get; set; }

        public class ProgramCommandHandler : IRequestHandler<CreateProgramQuestionCommand, ResultViewModel>
        {
            private readonly ILogger<ProgramCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public ProgramCommandHandler( ILogger<ProgramCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(CreateProgramQuestionCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start Questionaire Registration.");

                try
                {   // create program

                    var _Response = await _ICreateApp.CreateProgramQuestionAsync(request.CreateApp);
                    return ResultViewModel.Ok(_Response);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return ResultViewModel.Fail("Program Question Failed To Submit.");
                }
            }
        }
    }
}
