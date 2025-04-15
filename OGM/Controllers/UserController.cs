using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OGM.Repository.Interface;
using OGM.Domain.Entities;
using System.Threading.Tasks;
using OGM.Application.Interface;

namespace OGM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result = await _userService.RegisterUserAsync(user);

            if (!result)
                return BadRequest("Registration failed. Email might already exist or an error occurred.");

            return Ok("User registered successfully.");
        }
    }
}
