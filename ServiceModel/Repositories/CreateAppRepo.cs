using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using ServiceModel.Interface;
using ServiceModel.Entities;
using ServiceModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ServiceModel.Repositories
{
    public class CreateAppRepo : ICreateApp
    {
        private readonly Container _programContainer;
        private readonly ILogger<CreateAppRepo> _logger;

        public CreateAppRepo(CosmosClient cosmosClient, IConfiguration configuration, ILogger<CreateAppRepo> logger)
        {
            _logger = logger;
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
            string databaseName = _configuration.GetValue<string>("CosmoDbSetting:DatabaseName");
            string ContainerName = _configuration.GetValue<string>("CosmoDbSetting:ContainerName");
            _programContainer = cosmosClient.GetContainer(databaseName, ContainerName);
            _logger = logger;
        }

        public async Task<CreateApp> CreateProgramQuestionAsync(CreateApp createApp)
        {
            try
            {
                Guid newGuid = Guid.NewGuid();
                createApp.id = newGuid.ToString();
                createApp.UserId = newGuid.ToString();
                var response = await _programContainer.CreateItemAsync(createApp);
                return response.Resource;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at CreateProgramQuestionAsync with a message: {ex.Message}");
                return null;
            }
        }

        public async Task DeleteProgramQuestionAsync(string ProgramId, string userId)
        {
            try
            {
                await _programContainer.DeleteItemAsync<CreateApp>(ProgramId, new PartitionKey(userId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at DeleteProgramQuestionAsync with a message: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<CreateApp>> GetAllProgramQuestionAsync(string userId)
        {
            try
            {
                var sqlQueryText = $"SELECT * FROM c WHERE c.UserId='{userId}'";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                FeedIterator<CreateApp> queryResultSetIterator = _programContainer.GetItemQueryIterator<CreateApp>(queryDefinition);

                List<CreateApp> results = new List<CreateApp>();
                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<CreateApp> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (var GetResp in currentResultSet.Resource)
                    {
                        results.Add(GetResp);
                    }
                }
                return results;
            }
            catch   (Exception ex)
            {
                _logger.LogError($"Error occured at GetAllProgramQuestionAsync with a message: {ex.Message}");
                return new List<CreateApp>();
            }
        }

        public async Task<CreateApp> GetProgramQuestionByIdAsync(string ProgramId, string userId)
        {
            try
            {
                var _Query = _programContainer.GetItemLinqQueryable<CreateApp>()
                .Where(t => t.id == ProgramId && t.UserId == userId)
                .Take(1)
                .ToQueryDefinition();

                var sqlQuery = _Query.QueryText; // Retrieve the SQL query

                var Response = await _programContainer.GetItemQueryIterator<CreateApp>(_Query).ReadNextAsync();
                return Response.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at GetProgramQuestionByIdAsync with a message: {ex.Message}");
                return null;
            }
        }

        public async Task<CreateApp> UpdateProgramQuestionAsync(CreateApp createApp)
        {
            try
            {
                var Response = await _programContainer.ReplaceItemAsync(createApp, createApp.id);
                return Response.Resource;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at UpdateProgramQuestionAsync for CreateApp with a message: {ex.Message}");
                return null;
            }
        }

        public async Task<CreateApp> UpdateProgramQuestionAsync(Question _Question)
        {
            try
            {
                var Response = await _Question.ProcessQuestion();
                return Response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at UpdateProgramQuestionAsync for Question with a message: {ex.Message}");
                return null;
            }
        }
                
    }
}
