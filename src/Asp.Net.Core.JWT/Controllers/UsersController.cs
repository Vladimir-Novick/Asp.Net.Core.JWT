using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Asp.Net.Core.JWT.Services;
using Asp.Net.Core.JWT.Entities;
using Asp.Net.Core.JWT.Helpers;

namespace Asp.Net.Core.JWT.Controllers
{
  [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : JMTController
    {
        public UsersController(IUserService userService) : base(userService) { }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


    }
}
