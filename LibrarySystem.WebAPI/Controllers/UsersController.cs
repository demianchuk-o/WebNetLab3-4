using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var user = _userService.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update(Guid id, [FromBody] UserDto user)
    {
        await _userService.UpdateAsync(id, _mapper.Map<UserModel>(user));
        var userEntity = _mapper.Map<UserDto>(await _userService.GetByIdAsync(id));
        return Ok(userEntity);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _userService.DeleteByIdAsync(id);
        return NoContent();
    }
}