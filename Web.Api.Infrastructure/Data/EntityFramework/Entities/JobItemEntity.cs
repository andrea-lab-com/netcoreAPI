using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public class JobItemEntity: BaseEntity
    {

        public JobItemEntity(int id, int jobId, int status, string dataSourceUrl)
        {
            this.Id = id;
            JobId = jobId;
            Status = status;
            DataSourceUrl = dataSourceUrl;
        }

        public int JobId { get; set; }
        public int Status { get; set; }
        public string DataSourceUrl { get; set; }
    }

}
