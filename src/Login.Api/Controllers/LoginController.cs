using Login.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase

    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
          var result = await  _userService.VerifyIfUserIsValid(email, password, CancellationToken.None);
            return Ok(result);
        }
    }
}
