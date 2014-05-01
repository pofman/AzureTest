using System.Linq;
using AzureTest.Model;

namespace AzureTest.Persistence.Queries
{
    public static class PlayerQueries
    {
        public static IQueryable<Player> InTeam(this IQueryable<Player> repository, long teamId)
        {
            return repository.Where(x => x.Teams.Any(t => t.Id == teamId));
        }
    }
}
