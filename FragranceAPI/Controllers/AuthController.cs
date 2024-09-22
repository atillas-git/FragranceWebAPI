using Application.Dtos.Auth;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequestDto authRequest)
        {
            var result = await _authService.LoginAsync(authRequest);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequest)
        {
            var result = await _authService.RegisterAsync(registerRequest);
            if (result == false)
            {
                return BadRequest("User already exists.");
            }
            return Ok(result);
        }
    }

}
