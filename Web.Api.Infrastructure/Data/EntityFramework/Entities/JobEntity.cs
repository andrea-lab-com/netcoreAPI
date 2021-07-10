using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public class JobEntity: BaseEntity
    {

        public JobEntity(int id, int type, int items)
        {
            this.Id = id;
            Type = type;
            Items = items;
        }

        public int Type { get; set; }
        public int Items { get; set; }
    }

}
