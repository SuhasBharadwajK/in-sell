using InSell.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Services.Contracts
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(long userProfileId);

        void CreateUserProfile(UserProfile userProfile);

        void UpdateUserProfile(UserProfile userProfile);

        void DeleteUserProfile(long userProfileId);

    }
}
