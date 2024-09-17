namespace EventApp.Application;

public interface IRefreshTokenService
{
    Task<(string, string)> RefreshToken(string refreshToken);
}