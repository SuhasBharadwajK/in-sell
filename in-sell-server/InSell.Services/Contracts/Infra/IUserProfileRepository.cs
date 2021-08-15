using InSell.Models;
using InSell.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Services.Contracts.Infra
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
    }
}
