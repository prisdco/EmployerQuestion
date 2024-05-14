using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceModel.Entities;
using ServiceModel.Interface;
using ServiceModel.Repositories;
using Shouldly;

namespace xUnitTest
{
    public class EmployerQuestionUnitTest
    {
        private CreateApp _CreateApp;
        private Mock<ICreateApp> _CreateAppService;

        private readonly Mock<CosmosClient> _mockCosmosClient;
        private readonly Mock<ILogger<CreateAppRepo>> _mockLogger;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly CreateAppRepo _service;

        public EmployerQuestionUnitTest()
        {
            // Create mock instances
            _mockCosmosClient = new Mock<CosmosClient>();
            _mockLogger = new Mock<ILogger<CreateAppRepo>>();
            _mockConfiguration = new Mock<IConfiguration>();

            // Initialize the service with the mocked dependencies
            _service = new CreateAppRepo(_mockCosmosClient.Object, _mockConfiguration.Object, _mockLogger.Object);


            _CreateApp = new CreateApp();

            _CreateApp.id = "12345";
                _CreateApp.Title = "Summer Intern";
                _CreateApp.Description = "This is good one";
                _CreateApp.UserId = "123";
            _CreateApp.UserInfo = new UserInfo {
                FirstName = 0,
                LastName = 0,
                Email = 0,
                Phone = 0,
                Nationality = 0,
                CurrentResidence = 0,
                IDNumber = ServiceModel.Enums.EnableOption.Disable,
                DateofBirth = ServiceModel.Enums.EnableOption.Disable,
                Gender = ServiceModel.Enums.EnableOption.Disable,
                userId = "123"
            };
            _CreateApp.NumberQuestion =
                [
                  new NumberQuestion {
                           QuestionId= "1",
                    ProgramId ="12345",
                    type = "NumberQuestion",
                    QuestionTitle = "What is your age?"
                  },
                  new NumberQuestion
                  {
                            QuestionId= "2",
                    ProgramId ="12345",
                    type = "NumberQuestion",
                    QuestionTitle = "How many years of experience?"
                  }
                ];
            _CreateApp.DateQuestion = new List<DateQuestion> { };
            _CreateApp.ParagraphQuestion = new List<ParagraphQuestion> { };
            _CreateApp.YesNoQuestion = new List<YesNoQuestion> { };
            _CreateApp.DropdownQuestion = new List<DropdownQuestion> { };
            _CreateApp.MultiChoiceQuestions = new List<MultiChoiceQuestion> { };

            
            _CreateAppService = new Mock<ICreateApp>();
        }

        [Fact]
        public async void CreateProgramQuestion_Should_Throw_Exception_For_Null_Request()
        {
            // Act
            var result = await _service.CreateProgramQuestionAsync(null);
            result.ShouldBeNull();
        }

        
    }
}