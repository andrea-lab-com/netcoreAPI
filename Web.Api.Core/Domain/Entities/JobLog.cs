
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Core.Domain.Entities
{
    public class JobLog
    {
        public int Id { get; }
        public int JobId { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public JobType JobType { get; }
        public int JobItemId { get; }
        public string DataSourceUrl { get; }
        public string Error { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public JobItemStatus JobItemStatus { get; }
        public DateTime Date { get; }
        internal JobLog(int jobId, JobType jobType, int jobItemId, string dataSourceUrl, string error, JobItemStatus jobItemStatus, DateTime date, int id = 0)
        {
            Id = id;
            JobId = jobId;
            JobType = jobType;
            JobItemId = jobItemId;
            DataSourceUrl = dataSourceUrl;
            Error = error;
            JobItemStatus = jobItemStatus;
            Date = date;
        }
    }
}
