using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Domain.Enums;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IJobItemRepository
    {

        Task<ListJobItemResponse> List(int jobId);

        Task<CreateItemJobResponse> Create(JobItem jobItem);
        Task<UpdateJobItemResponse> Update(JobItem jobItem, JobItemStatus jobItemStatus);
        Task<CreateJobLogResponse> Log(JobItem jobItem, JobType jobType);

    }
}
