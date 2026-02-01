using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;


        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto loginRequestDto)
        {
            var result = _authService.Login(loginRequestDto.EMail, loginRequestDto.Password);

            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
