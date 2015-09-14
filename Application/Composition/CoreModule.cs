using Application.Services;
using Autofac;
using Domain.Factories;
using Domain.Services;
using Infrastructure.Persistance.Repositories;

namespace Application.Composition
{
    public class CoreModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AcmeVehicleService>().As<IVehicleService>();
            builder.RegisterType<AcmePolicyService>().As<IPolicyService>();
            builder.RegisterType<AcmeUnderwritingService>().As<IUnderwritingService>();

            builder.RegisterType<ClaimFactory>().AsSelf();
            builder.RegisterType<ClaimRepository>().As<Domain.Repositories.IClaimRepository>();
        }
    }
}
