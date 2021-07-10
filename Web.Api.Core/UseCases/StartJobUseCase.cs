using System.Linq;
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

        public StartJobUseCase(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<bool> Handle(StartJobRequest message, IOutputPort<StartJobResponse> outputPort)
        {
            var response = await _jobRepository.Create(new Job(message.Type, message.Items));
            outputPort.Handle(response.Success ? new StartJobResponse(response.Id, true) : new StartJobResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
