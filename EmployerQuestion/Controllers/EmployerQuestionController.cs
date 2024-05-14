using Application.UseCase.Commands;
using Application.UseCase.Queries;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using ServiceModel.Entities;
using ServiceModel.Model;

namespace QuestionsTask.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmployerQuestionController : BaseController
    {
        private CosmosClient _cosmosClient;
        public EmployerQuestionController(CosmosClient cosmosClient) 
        {
            _cosmosClient = cosmosClient;
        }


        /// <summary>
        /// this endpoint is used to Create Program
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateProgramQuestion")]
        public async Task<ResultViewModel> CreateProgramQuestionAsync([FromBody] CreateProgramQuestionCommand model)
        {
            Logger.LogInformation($"Received request to create program application");
            var result = await this.Mediator.Send(model);
            Logger.LogInformation($"Finished creating program application");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used to Create Program
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateCandidateAnswerQuestion")]
        public async Task<ResultViewModel> CreateCandidateAnswerQuestionAsync([FromBody] CreateCandidateAnswerQuestionCommand model)
        {
            Logger.LogInformation($"Received request to create Candidate application");
            var result = await this.Mediator.Send(model);
            Logger.LogInformation($"Finished creating candidate application");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used to Update Program
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateProgramQuestion")]
        public async Task<ResultViewModel> UpdateProgramQuestionCommandAsync([FromBody] UpdateProgramQuestionCommand model)
        {
            Logger.LogInformation($"Received request to update program application");
            var result = await this.Mediator.Send(model);
            Logger.LogInformation($"Finished updating program application");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used to Update Sub Question
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateSubQuestion")]
        public async Task<ResultViewModel> UpdateSubQuestionCommandAsync([FromBody] QuestionModel _QuestionModel)
        {
            Logger.LogInformation($"Received request to update sub question");
            var command = new UpdateSubQuestionCommand(_QuestionModel.question[0]);
            var result = await this.Mediator.Send(command);
            Logger.LogInformation($"Finished updating sub question");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used fetch program application by UserId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProgramQuestionByUserId")]
        public async Task<ResultViewModel> GetAllProgramQuestionByUserIdAsync([FromQuery] string? userId = "")
        {
            Logger.LogInformation($"Received request to get all program application by UserId");
            var result = await this.Mediator.Send(new GetAllProgramQuestionByUserIdQuery(userId));
            Logger.LogInformation($"Finished getting all program application by UserId");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used fetch program application
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProgramQuestion")]
        public async Task<ResultViewModel> GetAllProgramQuestionAsync()
        {
            Logger.LogInformation($"Received request to get all program application");
            var result = await this.Mediator.Send(new GetAllProgramQuestionQuery());
            Logger.LogInformation($"Finished getting all program application");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used fetch program application
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCandidateAnswerQuestion")]
        public async Task<ResultViewModel> GetAllCandidateAnswerQuestionAsync()
        {
            Logger.LogInformation($"Received request to get all candidate application");
            var result = await this.Mediator.Send(new GetAllCandidateAnswerQuestionQuery());
            Logger.LogInformation($"Finished getting all candidate application");
            Logger.LogInformation("====================================================================================");
            return result;
        }

        /// <summary>
        /// this endpoint is used fetch question by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProgramQuestionById")]
        public async Task<ResultViewModel> GetProgramQuestionByIdAsync([FromQuery] string? userId = "", [FromQuery] string? ProgramId = "")
        {
            Logger.LogInformation($"Received request to get question by Id");
            var result = await this.Mediator.Send(new GetProgramQuestionByIdQuery(userId, ProgramId));
            Logger.LogInformation($"Finished getting question by Id");
            Logger.LogInformation("====================================================================================");
            return result;
        }
    }
}
