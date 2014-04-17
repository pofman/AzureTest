using System.CodeDom;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AzureTest.Foundations;

namespace AzureTest.Persistence
{
    public class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : Entity<T>
    {
        public BaseEntityConfiguration()
        {
            MapId();
        }

        protected virtual void MapCreationDate()
        {
            Property(x => x.CreationDate);
        }

        protected virtual void MapId()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
