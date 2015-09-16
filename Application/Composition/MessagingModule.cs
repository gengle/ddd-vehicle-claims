using Application.Services;
using Autofac;

namespace Application.Composition
{
    public class MessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (MessagingModule).Assembly)
                .AsClosedTypesOf(typeof (ICommandHandler<>));
               
            builder.RegisterType<AutofacCommandDispatcher>()
                .As<ICommandDispatcher>();

            builder.RegisterType<Services.RoutingRelationService>().AsSelf();

        }
    }
}