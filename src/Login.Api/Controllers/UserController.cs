using Login.Application.Services;
using Login.Domain;
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
        public async Task<IActionResult> Post(User user)
        {
            await _userService.CreateUser(user, CancellationToken.None);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _userService.VerifyUser(email, CancellationToken.None);
            return Ok();
        }
    }
};
