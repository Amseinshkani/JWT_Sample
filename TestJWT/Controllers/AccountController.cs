using Core.Models;
using Core.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route(nameof(Login))]
        public IActionResult Login([FromForm] LoginRequest loginRequest)
        {
            var JwtAuthorizationManager = new JWTAuthorizationManager();
            var result = JwtAuthorizationManager.Authenticate(loginRequest.UserName, loginRequest.Password);
            if (result == null)
                return Unauthorized();
            else
                return Ok(result);
        }
    }
}
