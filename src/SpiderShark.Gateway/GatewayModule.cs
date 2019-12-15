using Autofac;
using SpiderShark.Domain.Interfaces.Gateways.Repositories;
using SpiderShark.Domain.Interfaces.Services;
using SpiderShark.Gateway.Auth;
using SpiderShark.Gateway.Data.EntityFramework.Repositories;

namespace SpiderShark.Gateway
{
    public class GatewayModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
