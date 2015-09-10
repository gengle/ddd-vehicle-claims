using Autofac;
using Domain.Infrastructure.Acme;
using Domain.Infrastructure.Data;
using Domain.Services;

namespace Domain.Infrastructure.Modules
{
    public class CoreModule: Module
    {
        public bool UseMemoryMode { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AcmeVehicleService>()
                .As<IVehicleService>();
            builder.RegisterType<AcmePolicyService>()
                .As<IPolicyService>();
            builder.RegisterType<AcmeUnderwritingService>()
                .As<IUnderwritingService>();

            if (UseMemoryMode)
            {
                builder.RegisterType<MemoryClaimRepository>()
                    .As<Repositories.IClaimRepository>()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<SqlClaimRepository>()
                    .As<Repositories.IClaimRepository>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}
