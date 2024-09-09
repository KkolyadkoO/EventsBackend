using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventApp.Application;
using EventApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace EventApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;
    private readonly IUserService _userService;

    public AuthController(JwtTokenService jwtTokenService, IUserService userService)
    {
        _jwtTokenService = jwtTokenService;
        _userService = userService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
    {
        try
        {
            var user = await _userService.Login(model.Username, model.Password);
            var token = _jwtTokenService.GenerateToken( user.Id, model.Username, user.Role);
            return Ok(new { Token = token });

        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
}