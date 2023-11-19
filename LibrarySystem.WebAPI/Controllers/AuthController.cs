using LibrarySystem.Common.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterDto user)
    {
        return CreatedAtAction(nameof(Register), new { id = Guid.NewGuid() }, user);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDto user)
    {
        var userEntity = new UserDto(Guid.NewGuid(), user.Email, "username");
        return Ok(userEntity);
    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        return NoContent();
    }
}