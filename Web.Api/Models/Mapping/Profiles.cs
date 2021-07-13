using AutoMapper;
using Web.Api.Core.Domain.Entities;
using Web.Api.Models.Request;

namespace Web.Api.Models.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<JobItemRequest, JobItem>().ConstructUsing(u => new JobItem(0, u.DataSourceUrl));

        }
    }
}
