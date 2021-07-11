
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Core.Domain.Entities
{
    public class JobItem
    {
        public int Id { get; }
        public int JobId { get; }
        public string DataSourceUrl { get; }
        public JobItemStatus Status { get; }
        public JobItem(int jobId, string dataSourceUrl, JobItemStatus status = JobItemStatus.CREATED, int id=0)
        {
            Id = id;
            JobId = jobId;
            DataSourceUrl = dataSourceUrl;
            Status = status;
        }
    }
}
