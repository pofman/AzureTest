﻿using System.Collections.Generic;
using AzureTest.Services.Contracts.Dtos;
using AzureTest.Support.Services;

namespace AzureTest.Services.Contracts.Services
{
    public interface ITeamsService : IService
    {
        IEnumerable<TeamDto> Get();
        TeamDto Get(long id);
        void Post(TeamDto value);
        void Put(long id, TeamDto value);
        void Delete(long id);
    }
}
