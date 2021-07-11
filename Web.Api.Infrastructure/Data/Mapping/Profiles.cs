using AutoMapper;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Domain.Enums;
using Web.Api.Infrastructure.Data.Entities;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {Id=u.Id, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash});
            CreateMap<AppUser, User>().ConstructUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));

            CreateMap<Job, JobEntity>().ConstructUsing(au => new JobEntity(au.Id, (int)au.Type));

            CreateMap<JobItem, JobItemEntity>().ConstructUsing(au => new JobItemEntity(au.Id, au.JobId, (int)au.Status, au.DataSourceUrl));
            CreateMap<JobItemEntity, JobItem>().ConstructUsing(au => new JobItem(au.JobId, au.DataSourceUrl, (JobItemStatus) au.Status, au.Id));

        }
    }
}
