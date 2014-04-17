using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AzureTest.Foundations;

namespace AzureTest.Model
{
    public class Team : Entity<Team>, INamedEntity
    {
        private ICollection<Player> _players;
       
        [Required]
        public string Name { get; protected set; }

        public virtual ICollection<Player> Players
        {
            get
            {
                if (_players == null)
                    _players = new List<Player>();
                return _players;
            }
            protected set { _players = value; }
        }

        public Team(string name)
        {
            Name = name;
        }
    }
}
