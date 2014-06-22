using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AzureTest.Model;
using AzureTest.Persistence.Queries;
using AzureTest.Services.Contracts.Dtos;
using AzureTest.Services.Contracts.Services;
using NailsFramework.IoC;
using NailsFramework.Persistence;
using NailsFramework.UserInterface;

namespace AzureTest.Client.Controllers
{
    public class TeamController : NailsApiController, ITeamsService
    {
        [Inject]
        public IBag<Team> Teams { private get; set; }

        [Inject]
        public IBag<Player> Players { private get; set; }

        // GET api/values
        public IEnumerable<TeamDto> Get()
        {
            return Teams.Select(x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
                Players = x.Players.Select(p => p.Id)
            });
        }

        // GET api/values/5
        public TeamDto Get(long id)
        {
            return Teams.ById(id, x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
                Players = x.Players.Select(p => p.Id)
            });
        }

        // POST api/values
        public void Post([FromBody]TeamDto value)
        {
            if (ModelState.IsValid)
            {
                Teams.Put(new Team(value.Name)
                    .Add(Players.IdIn(value.Players)));
            }
        }

        // PUT api/values/5
        public void Put(long id, [FromBody]TeamDto value)
        {
            if (ModelState.IsValid)
            {
                var team = Teams.GetById(id);

                var playersToRemove = Players.InTeam(id).Where(x => !value.Players.Contains(x.Id));
                var playersToAdd = Players.Where(x => !playersToRemove.Contains(x));

                team.Update(value.Name)
                    .Remove(playersToRemove)
                    .Add(playersToAdd);
            }
        }

        // DELETE api/values/5
        public void Delete(long id)
        {
            Teams.Remove(Teams.GetById(id));
        }
    }
}
