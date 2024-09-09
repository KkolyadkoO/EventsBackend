namespace EventApp.Infrastructure;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string userName, string role);
}