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
        public async Task<IActionResult> Register([FromForm] RegisterUserDto user)
        {
            var result = await _userService.RegisterUserAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.LoginUserAsync(request.Email ?? "", request.Password ?? "");

            if (user == null)
                return Unauthorized("Invalid email or password.");

            return Ok("Login successful");
        }
    }
}
