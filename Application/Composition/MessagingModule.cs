using Autofac;

namespace Application.Composition
{
    public class MessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (MessagingModule).Assembly)
                .AsClosedTypesOf(typeof (Infrastructure.Services.ICommandHandler<>));
               
            builder.RegisterType<Infrastructure.Services.AutofacCommandDispatcher>()
                .As<Infrastructure.Services.ICommandDispatcher>();
            
        }
    }
}