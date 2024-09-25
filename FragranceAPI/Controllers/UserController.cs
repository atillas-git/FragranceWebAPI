using Microsoft.AspNetCore.Mvc;
using Application.Dtos.User;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("admin/email/{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [HttpGet("/admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("/admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddUser([FromBody] UserCreateUpdateDto userDto)
        {
            await _userService.AddUserAsync(userDto);
            return Ok();
        }

        [HttpPut("shared/{id}")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateUpdateDto userDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && id.ToString() != userIdClaim.Value && User.IsInRole("User")){
                return Forbid();
            }
            await _userService.UpdateUserAsync(id, userDto);
            return Ok();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var users = await _userService.GetByNameAsync(name);
            return Ok(users);
        }
    }
}

