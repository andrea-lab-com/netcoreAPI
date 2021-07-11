
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Core.Domain.Entities
{
    public class JobItemLog
    {
        public int Id { get; }
        public int JobId { get; }
        public int JobItemId { get; }
        public string DataSourceUrl { get; }
        public string Description { get; }
        public JobItemStatus JobItemStatus { get; }
        internal JobItemLog(int jobId, int jobItemId, string dataSourceUrl, string description, JobItemStatus jobItemStatus, int id = 0)
        {
            Id = id;
            JobId = jobId;
            JobItemId = jobItemId;
            DataSourceUrl = dataSourceUrl;
            Description = description;
            JobItemStatus = jobItemStatus;
        }
    }
}
