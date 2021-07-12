using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
  public class StartJobUseCaseUnitTests
  {

    [Fact]
    public async void Can_Start_Job()
    {
      // arrange

      // 1. We need to store the user data somehow
      var mockJobRepository = new Mock<IJobRepository>();
            mockJobRepository
              .Setup(repo => repo.Create(It.IsAny<Job>()))
        .Returns(Task.FromResult(new CreateJobResponse(0, true)));

        var mockJobItemRepository = new Mock<IJobItemRepository>();
            mockJobItemRepository
                .Setup(repo => repo.Create(It.IsAny<JobItem>()))
         .Returns(Task.FromResult(new CreateItemJobResponse(0, true)));

            var mockFireForgetRepositoryHandler = new Mock<IFireForgetRepositoryHandler>();




            // 2. The use case and star of this test
            var useCase = new StartJobUseCase(mockJobRepository.Object, mockJobItemRepository.Object,null );

      // 3. The output port is the mechanism to pass response data from the use case to a Presenter 
      // for final preparation to deliver back to the UI/web page/api response etc.
      var mockOutputPort = new Mock<IOutputPort<StartJobUseCaseResponse>>();
      mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<StartJobUseCaseResponse>()));

            // act

            // 4. We need a request model to carry data into the use case from the upper layer (UI, Controller etc.)
            var items = new List<JobItem>();
            items.Add(new JobItem(0, "dataSourceURL1"));
            items.Add(new JobItem(0, "dataSourceURL2"));

            var response = await useCase.Handle(new StartJobUseCaseRequest(Domain.Enums.JobType.BULK, items), mockOutputPort.Object);

      // assert
      Assert.True(response);
    }
  }
}
