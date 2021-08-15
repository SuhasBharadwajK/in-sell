using InSell.Models;
using InSell.Services.Contracts.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Services.Infra.Repositories
{
    public class UserProfileRepository : CosmosRepository<UserProfile>, IUserProfileRepository
    {

        public UserProfileRepository(CosmosConfig cosmosConfig) : base(cosmosConfig)
        {

        }
    }
}
