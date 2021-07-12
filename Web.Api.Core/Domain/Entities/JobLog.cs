
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Core.Domain.Entities
{
    public class JobLog
    {
        public int Id { get; }
        public int JobId { get; }
        public JobType JobType { get; }
        public int JobItemId { get; }
        public string DataSourceUrl { get; }
        public string Error { get; }
        public JobItemStatus JobItemStatus { get; }
        internal JobLog(int jobId, JobType jobType, int jobItemId, string dataSourceUrl, string error, JobItemStatus jobItemStatus, int id = 0)
        {
            Id = id;
            JobId = jobId;
            JobType = jobType;
            JobItemId = jobItemId;
            DataSourceUrl = dataSourceUrl;
            Error = error;
            JobItemStatus = jobItemStatus;
        }
    }
}
