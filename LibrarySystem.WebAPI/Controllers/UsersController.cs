using LibrarySystem.Common.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        return Ok(new List<UserDto>());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        return Ok(new UserDto(id, "username@mail.com", "username"));
    }
    
    [HttpPut]
    public async Task<ActionResult> Update(Guid id, [FromBody] UserDto user)
    {
        var userEntity = new UserDto(id, user.Email, user.Username);
        return Ok(userEntity);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return NoContent();
    }
}