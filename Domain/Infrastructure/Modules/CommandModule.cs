using Autofac;
using Domain.Services;
using Domain.Shared;

namespace Domain.Infrastructure.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (CommandModule).Assembly)
                .AsClosedTypesOf(typeof (ICommandHandler<>));
               

            builder.RegisterType<AutofacCommandDispatcher>()
                .As<ICommandDispatcher>();
            
        }
    }
}