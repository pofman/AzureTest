using AzureTest.Model;

namespace AzureTest.Persistence.Mappings
{
    public class PlayerEntityConfiguration : BaseEntityConfiguration<Player>
    {
        public PlayerEntityConfiguration()
        {
            Property(x => x.Name);
            Property(x => x.Number);
        }
    }
}
