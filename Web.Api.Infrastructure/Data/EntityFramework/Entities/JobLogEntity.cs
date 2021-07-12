using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public class JobLogEntity: BaseEntity
    {

        public JobLogEntity(int id, int jobId, int jobItemId, int status, string dataSourceUrl, int jobType, string error)
        {
            this.Id = id;
            JobId = jobId;
            JobItemId = jobItemId;
            Status = status;
            DataSourceUrl = dataSourceUrl;
            JobType = jobType;
            Error = error;
        }

        public int JobId { get; set; }

        public int JobType { get; set; }

        public int JobItemId { get; set; }

        public string DataSourceUrl { get; set; }
        
        public string Error { get; set; }

        public int Status { get; set; }
    }

}
