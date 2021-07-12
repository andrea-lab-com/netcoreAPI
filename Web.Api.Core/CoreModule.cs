using Autofac;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;

namespace Web.Api.Core
{
  public class CoreModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<StartJobUseCase>().As<IStartJobUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<CheckStatusUseCase>().As<ICheckStatusUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<GetJobLogUseCase>().As<IGetJobLogUseCase>().InstancePerLifetimeScope();
        }
  }
}
