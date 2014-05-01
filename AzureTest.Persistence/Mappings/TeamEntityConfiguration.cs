using AzureTest.Model;

namespace AzureTest.Persistence.Mappings
{
    public class TeamEntityConfiguration : BaseEntityConfiguration<Team>
    {
        public TeamEntityConfiguration()
        {
            Property(x => x.Name);
            HasMany(x => x.Players).WithMany(x => x.Teams);
        }
    }
}