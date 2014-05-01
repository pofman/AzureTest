using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AzureTest.Foundations;

namespace AzureTest.Model
{
    public class Team : Entity<Team>, INamedEntity
    {
        private ICollection<Player> _players;

        [Required]
        [MaxLength(250)]
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

        public Team Add(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                if (!QueryCollection(x => x.Players).Any(x => x.Id == player.Id))
                    Players.Add(player);
            }
            return this;
        }

        public Team Update(string name)
        {
            Name = name;
            return this;
        }

        public Team Remove(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                if (QueryCollection(x => x.Players).Any(x => x.Id == player.Id))
                    Players.Remove(player);
            }
            return this;
        }
    }
}
