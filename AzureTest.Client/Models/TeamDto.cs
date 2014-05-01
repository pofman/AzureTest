using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AzureTest.Client.Models
{
    public class TeamDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<long> Players { get; set; }

        public TeamDto()
        {
            Players = new List<long>();
        }
    }
}