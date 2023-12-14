using AutoMapper;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterDto user)
    {
        await _userService.RegisterAsync(_mapper.Map<UserModel>(user), user.Password);
        var userRegistered = await _userService.GetByEmailAsync(user.Email);
        return CreatedAtAction(nameof(Register), new { id = userRegistered.Id }, userRegistered);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDto user)
    {
        var token = await _userService.AuthenticateAsync(user.Email, user.Password);
        var userEntity = await _userService.GetByEmailAsync(user.Email);

        if (token is not null)
        {
            Response.Headers.Add("Authorization", $"Bearer {token}");
            
            return Ok(_mapper.Map<UserDto>(userEntity));
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        return Ok(new { message = "Logged out successfully" });
    }
}