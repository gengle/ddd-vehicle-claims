using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Infrastructure.Persistance.EntityFramework;
using Infrastructure.Persistance.Fakes;
using Infrastructure.Services;

namespace Infrastructure.Persistance
{
    public class PersistenceModule: Autofac.Module
    {
        public bool UseFakeWorkspace { get; set; } = false;
        public string ConnectionStringOrName { get; set; } = "name=ClaimConnectionString";

        protected override void Load(ContainerBuilder builder)
        {
            if (UseFakeWorkspace)
            {
                builder.Register(c => new FakeWorkspace(ConnectionStringOrName ?? Path.GetTempFileName()))
                    .As<IWorkspace>()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.Register(c => new EFWorkspace(new EFContext(ConnectionStringOrName)))
                    .As<IWorkspace>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}
