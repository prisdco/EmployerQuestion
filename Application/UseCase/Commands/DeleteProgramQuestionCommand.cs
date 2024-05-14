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
    public class DeleteProgramQuestionCommand : IRequest<ResultViewModel>
    {
        public string ProgramId { get; set; }
        public string UserId { get; set; }

        public DeleteProgramQuestionCommand(string _UserId, string _ProgramId)
        {
            UserId = _UserId;
            ProgramId = _ProgramId;
        }

        public class DeleteProgramQuestionCommandHandler : IRequestHandler<DeleteProgramQuestionCommand, ResultViewModel>
        {
            private readonly ILogger<DeleteProgramQuestionCommandHandler> _logger;
            private readonly ICreateApp _ICreateApp;


            public DeleteProgramQuestionCommandHandler(ILogger<DeleteProgramQuestionCommandHandler> logger, ICreateApp ICreateApp)
            {
                _logger = logger;
                _ICreateApp = ICreateApp;
            }

            public async Task<ResultViewModel> Handle(DeleteProgramQuestionCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Start Program Questionaire Modification.");

                try
                {   // create program

                    var _Response = _ICreateApp.DeleteProgramQuestionAsync(request.ProgramId, request.UserId);
                    return ResultViewModel.Ok("Program Question Deleted Successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return ResultViewModel.Fail("Program Question Failed To Delete.");
                }
            }
        }
    }
}
