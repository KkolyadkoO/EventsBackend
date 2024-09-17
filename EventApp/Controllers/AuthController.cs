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
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUserService _userService;
    private readonly IRefreshTokenService _refreshTokenService;

    public AuthController(IJwtTokenService jwtTokenService, IUserService userService, IRefreshTokenService refreshTokenService)
    {
        _jwtTokenService = jwtTokenService;
        _userService = userService;
        _refreshTokenService = refreshTokenService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
    {
        try
        {
            var user = await _userService.Login(model.Username, model.Password);
            var tokens = await _jwtTokenService.GenerateToken( user.Id, model.Username, user.Role);
            HttpContext.Response.Cookies.Append("token", tokens.Item1);
            HttpContext.Response.Cookies.Append("refresh_token", tokens.Item2);
            var tokensResponse = new TokensResponse(tokens.Item1, tokens.Item2);
            return Ok(tokensResponse);

        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
    {
        var tokens = await _refreshTokenService.RefreshToken(refreshToken);
        HttpContext.Response.Cookies.Append("token", tokens.Item1);
        HttpContext.Response.Cookies.Append("refresh_token", tokens.Item2);
        var tokensResponse = new TokensResponse(tokens.Item1, tokens.Item2);
        
        return Ok(tokensResponse);
    }
}