using Autofac;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.Services;
using Web.Api.Infrastructure.Auth;
using Web.Api.Infrastructure.Data.EntityFramework.Repositories;
using Web.Api.Infrastructure.Data.ExternalRepository;

namespace Web.Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<FireForgetRepositoryHandler>().As<IFireForgetRepositoryHandler>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JobRepository>().As<IJobRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JobItemRepository>().As<IJobItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JobLogRepository>().As<IJobLogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
