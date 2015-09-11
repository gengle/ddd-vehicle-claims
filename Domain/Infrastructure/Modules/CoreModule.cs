using System.IO;
using Autofac;
using Domain.Factories;
using Domain.Infrastructure.Acme;
using Domain.Infrastructure.Persistance;
using Domain.Infrastructure.Persistance.EntityFramework;
using Domain.Services;

namespace Domain.Infrastructure.Modules
{
    public class CoreModule: Module
    {
        public bool UseFakeWorkspace { get; set; }
        public string FakeWorkspaceFilePath { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AcmeVehicleService>()
                .As<IVehicleService>();
            builder.RegisterType<AcmePolicyService>()
                .As<IPolicyService>();
            builder.RegisterType<AcmeUnderwritingService>()
                .As<IUnderwritingService>();

            builder.RegisterType<ClaimFactory>().AsSelf();
            if (UseFakeWorkspace)
            {
                builder.Register(c => new FakeWorkspace(FakeWorkspaceFilePath ?? Path.GetTempFileName()))
                    .As<IWorkspace>()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.Register(c => new EFWorkspace(new EFContext()))
                    .As<IWorkspace>()
                    .InstancePerLifetimeScope();
            }
            
            builder.RegisterType<ClaimRepository>()
                .As<Repositories.IClaimRepository>();
        }
    }
}
