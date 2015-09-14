using System.Data.Entity;
using Domain;

namespace Infrastructure.Persistance.EntityFramework
{
    public class EFContext: DbContext
    {
        public DbSet<ClaimMemento> Claims { get; set; }

        public EFContext():this("name=ClaimConnectionString")
        {
            
        }

        public EFContext(string connectionStringOrName): base(connectionStringOrName)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Vehicle>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
