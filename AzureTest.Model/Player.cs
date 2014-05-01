using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AzureTest.Foundations;

namespace AzureTest.Model
{
    public class Player : Entity<Player>, INamedEntity
    {
        private ICollection<Team> _teams;

        [Required]
        public string Name { get; protected set; }

        public int? Number { get; protected set; }

        public ICollection<Team> Teams  
        {
            get
            {
                if (_teams == null)
                    _teams = new List<Team>();
                return _teams;
            }
            protected set { _teams = value; }
        }

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