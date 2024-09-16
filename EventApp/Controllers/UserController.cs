using EventApp.Application;
using EventApp.Contracts;
using EventApp.Core.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register")]
    public async Task<IResult> RegisterUser([FromBody] UserRegisterRequest request)
    {
        try
        {
            await _userService.Register(request.Username,request.UserEmail, request.Password, request.Role);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
        
    }
    
    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsers();
        var response = users.Select(u => new UsersResponse(u.Id,
            u.UserName, u.UserEmail, u.Role));
        return Ok(response);
    }
}