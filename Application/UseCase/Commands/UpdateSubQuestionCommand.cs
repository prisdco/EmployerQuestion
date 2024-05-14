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
    public class UpdateSubQuestionCommand : IRequest<ResultViewModel>
    {
        public Question _Question { get; set; }

        public UpdateSubQuestionCommand(Question Question)
        {
            _Question = Question;
        }

        public class UpdateSubQuestionCommandHandler : IRequestHandler<UpdateSubQuestionCommand, ResultViewModel>
        {
            private readonly ILogger<UpdateSubQuestionCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public UpdateSubQuestionCommandHandler(ILogger<UpdateSubQuestionCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(UpdateSubQuestionCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start Program Questionaire Modification.");

                try
                {   // create program

                    var _Response = await _ICreateApp.UpdateProgramQuestionAsync(request._Question);
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
