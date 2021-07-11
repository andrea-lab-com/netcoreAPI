using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class CheckStatusUseCase : ICheckStatusUseCase
    {
        private readonly IJobItemRepository _jobItemRepository;
        private readonly IJobRepository _jobRepository;

        public CheckStatusUseCase(IJobRepository jobRepository, IJobItemRepository jobItemRepository)
        {
            _jobItemRepository = jobItemRepository;
            _jobRepository = jobRepository;
        }

        public async Task<bool> Handle(CheckStatusUseCaseRequest message, IOutputPort<CheckStatusUseCaseResponse> outputPort)
        {
            var job = await _jobRepository.FindById(message.JobId);

            var response = await _jobItemRepository.List( job.Id);

            var totalItems = response.Items.Count;
            var processedItems = response.Items.Count(u => u.Status == Domain.Enums.JobItemStatus.PROCESSED);
            var failedItems = response.Items.Count(u => u.Status == Domain.Enums.JobItemStatus.FAILED);
            
            outputPort.Handle(response.Success ? new CheckStatusUseCaseResponse(job.Id, job.Type, totalItems, processedItems, failedItems, true) : new CheckStatusUseCaseResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
