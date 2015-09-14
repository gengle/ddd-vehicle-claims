using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Persistance.EntityFramework
{
    public class EFContext: DbContext
    {
        public DbSet<ClaimMemento> Claims { get; set; }

        public EFContext():base("name=ClaimConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Vehicle>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
