using System.ComponentModel.DataAnnotations;
using AzureTest.Foundations;

namespace AzureTest.Model
{
    public class Player : Entity<Player>, INamedEntity
    {
        [Required]
        public string Name { get; protected set; }

        public int? Number { get; protected set; }

        public Player(string name)
        {
            Name = name;
        }

        public virtual Player UpdateNumber(int number)
        {
            Number = number;
            return this;
        }
    }
}