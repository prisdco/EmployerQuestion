﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using ServiceModel.Enums;
using ServiceModel.Model;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace ServiceModel.Entities
{
    public class NumberQuestion : Question
    {
        public string QuestionTitle { get; set; }

        private readonly Microsoft.Azure.Cosmos.Container _programContainer;

        public NumberQuestion()
        {
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
            string databaseName = _configuration.GetValue<string>("CosmoDbSetting:DatabaseName");
            string EndPointUrl = _configuration.GetValue<string>("CosmoDbSetting:EndPointUrl");
            string PrimaryKey = _configuration.GetValue<string>("CosmoDbSetting:PrimaryKey");
            string ContainerName = _configuration.GetValue<string>("CosmoDbSetting:ContainerName");
            var _cosmosClient = new CosmosClient(EndPointUrl, PrimaryKey);
            _programContainer = _cosmosClient.GetContainer(databaseName, ContainerName);
        }

        public override async Task<CreateApp> ProcessQuestion()
        {
            var _Query = _programContainer.GetItemLinqQueryable<CreateApp>()
                .Where(t => t.id == ProgramId)
                .Take(1)
                .ToFeedIterator();

            var _Response = await _Query.ReadNextAsync();
            var _ProgramQuestion = _Response.FirstOrDefault();

            if (_ProgramQuestion == null)
            {
                return null;
            }

            var subQuestion = _ProgramQuestion.NumberQuestion.FirstOrDefault(s => s.QuestionId == QuestionId);
            if (subQuestion == null)
            {
                return null;
            }

            subQuestion.QuestionTitle = QuestionTitle;

            await _programContainer.ReplaceItemAsync(_ProgramQuestion, _ProgramQuestion.id);

            return _ProgramQuestion;
        }
    }
}
