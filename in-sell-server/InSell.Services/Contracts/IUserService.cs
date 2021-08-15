using InSell.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Services.Contracts
{
    public interface IUserService
    {
        User GetUser(long userId);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(long userId);
    }
}
