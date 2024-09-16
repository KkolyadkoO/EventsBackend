using EventApp.Core.Models;

namespace EventApp.DataAccess.Repositories;

public interface IRefreshTokenRepository
{
    Task<Guid> Create(Guid userId, string token, DateTime expires, bool isRevoked);
    Task<RefreshToken> Get(string refreshToken);
    Task<Guid> Update(Guid tokenId, Guid userId, string token, DateTime expires, bool isRevoked);
}