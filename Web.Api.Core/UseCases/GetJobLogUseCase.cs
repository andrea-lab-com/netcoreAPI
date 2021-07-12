using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class GetJobLogUseCase : IGetJobLogUseCase
    {
        private readonly IJobLogRepository _jobLogRepository;

        public GetJobLogUseCase(IJobLogRepository jobLogRepository)
        {
            _jobLogRepository = jobLogRepository;
        }

        public async Task<bool> Handle(GetJobLogUseCaseRequest message, IOutputPort<GetJobLogUseCaseResponse> outputPort)
        {

            var response = await _jobLogRepository.List(message.JobId);

            
            outputPort.Handle(response.Success ? new GetJobLogUseCaseResponse(response.Items, true) : new GetJobLogUseCaseResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
