using System.Data.Entity;

namespace AzureTest.Persistence.Contexts
{
    public class EfContext : DbContext
    {
        public EfContext(string connectionStringnameOrConnectionString)
            : base(connectionStringnameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
