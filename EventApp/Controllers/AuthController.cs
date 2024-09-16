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

    public AuthController(IJwtTokenService jwtTokenService, IUserService userService)
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
            HttpContext.Response.Cookies.Append("token", token.Item1);
            return Ok(token);

        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
    {
        var storedRefreshToken = await _unitOfWork.RefreshTokenRepository.GetToken(refreshToken);

        if (storedRefreshToken == null || storedRefreshToken.IsRevoked || storedRefreshToken.Expires < DateTime.Now)
        {
            return Unauthorized("Invalid or expired refresh token");
        }

        var user = await _unitOfWork.UserRepository.GetUserById(storedRefreshToken.UserId);
        var tokens = _jwtTokenService.GenerateTokens(user.Id, user.UserName, user.Role);

        // Обновить refreshToken
        storedRefreshToken.Token = tokens.refreshToken;
        storedRefreshToken.Expires = DateTime.Now.AddDays(7);
        await _unitOfWork.CompleteAsync();

        return Ok(new { accessToken = tokens.accessToken, refreshToken = tokens.refreshToken });
    }
}