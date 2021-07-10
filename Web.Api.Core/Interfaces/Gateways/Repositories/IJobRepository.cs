using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IJobRepository
    {

        Task<CreateJobResponse> Create(Job job);
        Task<Job> FindById(int id);
    }
}
