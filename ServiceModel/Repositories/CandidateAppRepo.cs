using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceModel.Entities;
using ServiceModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Repositories
{
    public class CandidateAppRepo : ICandidateApp
    {
        private readonly Container _programContainer;
        private readonly ILogger<CandidateAppRepo> _logger;

        public CandidateAppRepo(CosmosClient cosmosClient, IConfiguration configuration, ILogger<CandidateAppRepo> logger)
        {
            _logger = logger;
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
            string databaseName = _configuration.GetValue<string>("CosmoDbSetting:DatabaseName");
            string ContainerName = _configuration.GetValue<string>("CosmoDbSetting:CandidateContainerName");
            _programContainer = cosmosClient.GetContainer(databaseName, ContainerName);
            _logger = logger;
        }

        public async Task<CandidateData> CreateCandidateAnswerQuestionAsync(CandidateData candidateData)
        {
            try
            {
                Guid IdGuid = Guid.NewGuid();
                Guid CandidateGuid = Guid.NewGuid();
                candidateData.id = IdGuid.ToString().Substring(0, 5); ;
                candidateData.CandidateId = CandidateGuid.ToString().Substring(0, 6);

                var response = await _programContainer.CreateItemAsync(candidateData);
                return response.Resource;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at CreateCandidateAnswerQuestionAsync with a message: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<CandidateData>> GetAllCandidateAnswerQuestionAsync()
        {
            try
            {
                var sqlQueryText = $"SELECT * FROM c";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                FeedIterator<CandidateData> queryResultSetIterator = _programContainer.GetItemQueryIterator<CandidateData>(queryDefinition);

                List<CandidateData> results = new List<CandidateData>();
                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<CandidateData> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (var GetResp in currentResultSet.Resource)
                    {
                        results.Add(GetResp);
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at GetAllProgramQuestionAsync with a message: {ex.Message}");
                return new List<CandidateData>();
            }
        }
    }
}
