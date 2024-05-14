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
    public class UpdateProgramQuestionCommand : IRequest<ResultViewModel>
    {
        public CreateApp CreateApp { get; set; }

        public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramQuestionCommand, ResultViewModel>
        {
            private readonly ILogger<UpdateProgramCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public UpdateProgramCommandHandler(ILogger<UpdateProgramCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(UpdateProgramQuestionCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start Program Questionaire Modification.");

                try
                {   // create program

                    var _Response = await _ICreateApp.UpdateProgramQuestionAsync(request.CreateApp);
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
