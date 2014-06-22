using System.Collections.Generic;

namespace AzureTest.Services.Contracts.Dtos
{
    public class TeamDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<long> Players { get; set; }

        public TeamDto()
        {
            Players = new List<long>();
        }
    }
}