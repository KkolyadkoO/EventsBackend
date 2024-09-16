using EventApp.Core.Abstractions;
using EventApp.Core.Exceptions;
using EventApp.Infrastructure;

namespace EventApp.Application;

public class RefreshTokenService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenService _jwtTokenService;

    public RefreshTokenService(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<string> RefreshToken(string refreshToken)
    {
        try
        {
            var storedRefreshToken = await _unitOfWork.RefreshTokens.Get(refreshToken);
            if ( storedRefreshToken.IsRevoked || storedRefreshToken.Expires < DateTime.Now)
            {
                throw new InvalidRefreshToken("Invalid or expired refresh token");
            }
            var user = await _unitOfWork.Users.GetById(storedRefreshToken.UserId);
            var tokens = _jwtTokenService.GenerateToken(user.Id, user.UserName, user.Role);
            // Обновить refreshToken
            _unitOfWork.RefreshTokens.Update(storedRefreshToken.Id, user.Id,
                tokens.refreshToken, DateTime.Now.AddDays(7), false
                );
            await _unitOfWork.Complete();

            return Ok(new { accessToken = tokens.accessToken, refreshToken = tokens.refreshToken });
        }
        catch (Exception e)
        {
            throw new RefreshTokenNotFound(e.Message);
        }
                          




       
    }
}