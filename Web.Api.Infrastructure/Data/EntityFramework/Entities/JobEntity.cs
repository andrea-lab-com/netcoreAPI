using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public class JobEntity: BaseEntity
    {

        public JobEntity(int id, int type)
        {
            this.Id = id;
            Type = type;
        }

        public int Type { get; set; }
    }

}
