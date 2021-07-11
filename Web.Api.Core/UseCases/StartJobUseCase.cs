using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class StartJobUseCase : IStartJobUseCase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobItemRepository _jobItemRepository;
        private readonly IFireForgetRepositoryHandler _fireForgetRepositoryHandler;
        private readonly Random _random = new Random();

        public StartJobUseCase(IJobRepository jobRepository, IJobItemRepository jobItemRepository, IFireForgetRepositoryHandler fireForgetRepositoryHandler)
        {
            _jobRepository = jobRepository;
            _jobItemRepository = jobItemRepository;
            _fireForgetRepositoryHandler = fireForgetRepositoryHandler;
        }

        public async Task<bool> Handle(StartJobUseCaseRequest message, IOutputPort<StartJobUseCaseResponse> outputPort)
        {
            var response = await _jobRepository.Create(new Job(message.Type, message.Items));

            // Delegate the launch JobItem to another task on the threadpool
            _fireForgetRepositoryHandler.Execute(async repository =>
            {
                var listItems =  repository.List(response.Id).Result.Items;


                foreach (JobItem jobItem in listItems)
                {
                    int num = 200 + _random.Next(700);

                    // call external Service
                    Thread.Sleep(num);
                    Domain.Enums.JobItemStatus jobItemStatus = Domain.Enums.JobItemStatus.FAILED;
                    if (num < 650)
                    {
                        jobItemStatus = Domain.Enums.JobItemStatus.PROCESSED;
                    }


                    await repository.Update(jobItem, jobItemStatus);

                    if (jobItemStatus == Domain.Enums.JobItemStatus.FAILED && message.Type == Domain.Enums.JobType.BATCH)
                    {
                        break;
                    }
                }

            });


            outputPort.Handle(response.Success ? new StartJobUseCaseResponse(response.Id, true) : new StartJobUseCaseResponse(response.Errors.Select(e => e.Description)));
            
            

            return response.Success;
        }
    }
}
