
namespace Web.Api.Core.Domain.Entities
{
    public class Job
    {
        public string Id { get; }
        public string Type { get; }
        public int Items { get; }
        internal Job(string type, int items, string id=null)
        {
            Id = id;
            Type = type;
            Items = items;
        }
    }
}
