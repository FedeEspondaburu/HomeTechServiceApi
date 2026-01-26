using Application.DTO;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateUserRequestDto userRequestDto)
        {
            try
            {
                _userService.CreateUser(userRequestDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error while creating the User: " + ex.Message);
            }
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<UserResponseDto>> GetUserByEmail([FromQuery] string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Email cannot be null or empty.");
                }
                var user = await _userService.GetUserByEMail(email);
                return Ok(user);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("technicians")]
        public async Task<List<TechnicianListItemDto>> GetTechnicians()
        {
            return await (_userService.GetTechnicians());
        }

        [HttpGet("by-role")]
        public async Task<ActionResult<List<UserResponseDto>>> GetUsersByRole([FromQuery] UserRole userRole)
        {
            var users = await _userService.GetUsersByRoleAsync(userRole);
            return Ok(users);
        }
    }
}
