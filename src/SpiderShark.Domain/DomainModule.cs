using Autofac;
using SpiderShark.Domain.Interfaces.UseCase;
using SpiderShark.Domain.UseCases;

namespace SpiderShark.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
        }
    }
}
