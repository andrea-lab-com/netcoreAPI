using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IJobItemRepository
    {

        Task<ListJobItemResponse> List(int jobId);

        Task<UpdateJobItemResponse> Update(JobItem jobItem, JobItemStatus jobItemStatus);

    }
}
