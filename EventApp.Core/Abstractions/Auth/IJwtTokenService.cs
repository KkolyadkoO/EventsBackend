namespace EventApp.Infrastructure;

public interface IJwtTokenService
{
    (string accessToken, string refreshToken) GenerateToken(Guid userId, string userName, string role);
    string GenerateRefreshToken();
}