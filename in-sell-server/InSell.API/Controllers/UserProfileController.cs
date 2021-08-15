using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InSell.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet("{UserProfileId}")]
        public UserProfile GetUserProfile([FromRoute] long userProfileId)
        {
            return _userProfileService.GetUserProfile(userProfileId);
        }

        [HttpPost]
        public void CreateUserProfile([FromBody] UserProfile userProfile)
        {
            _userProfileService.CreateUserProfile(userProfile);
        }

        [HttpPut]
        public void UpdateUserProfile([FromBody] UserProfile userProfile)
        {
            _userProfileService.UpdateUserProfile(userProfile);
        }

        [HttpDelete("{UserProfileId}")]
        public void DeleteUserProfile(long userProfileId)
        {
            _userProfileService.DeleteUserProfile(userProfileId);
        }

    }
}