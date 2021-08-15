using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InSell.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public User GetUser([FromRoute] long userId)
        {
            return _userService.GetUser(userId);
        }

        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            _userService.CreateUser(user);
        }

        [HttpPut]
        public void UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
        }

        [HttpDelete("{userId}")]
        public void DeleteUser(long userId)
        {
            _userService.DeleteUser(userId);
        }

    }
}