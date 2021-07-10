
using Web.Api.Core.Domain.Enums;

namespace Web.Api.Core.Domain.Entities
{
    public class Job
    {
        public int Id { get; }
        public JobType Type { get; }
        public int Items { get; }
        internal Job(JobType type, int items, int id=0)
        {
            Id = id;
            Type = type;
            Items = items;
        }
    }
}
