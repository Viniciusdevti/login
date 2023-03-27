using Login.Api.Dtos.Inputs;
using Login.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(UserInput user)
        {
            await _userService.CreateUser(user, CancellationToken.None);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> Get(string email)
        {
             await _userService.VerifyIfUserExisting(email, CancellationToken.None);
            return Ok();
        }
    }
};
