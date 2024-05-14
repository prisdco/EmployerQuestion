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
                Guid newGuid = Guid.NewGuid();
                candidateData.id = newGuid.ToString();
                candidateData.CandidateId = newGuid.ToString();
                var response = await _programContainer.CreateItemAsync(candidateData);
                return response.Resource;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured at CreateCandidateAnswerQuestionAsync with a message: {ex.Message}");
                return null;
            }
        }
    }
}
