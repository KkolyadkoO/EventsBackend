using AutoMapper;
using EventApp.Core.Exceptions;
using EventApp.Core.Models;
using EventApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApp.DataAccess.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly EventAppDBContext _dbContex;
    private readonly IMapper _mapper;

    public RefreshTokenRepository(EventAppDBContext dbContext, IMapper mapper)
    {
        _dbContex = dbContext;
        _mapper = mapper;
    }


    public async Task<Guid> Create(Guid userId, string token, DateTime expires, bool isRevoked)
    {
        var rt = new RefreshTokenEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Token = token,
            Expires = expires,
            IsRevoked = isRevoked
        };
        await _dbContex.RefreshTokenEntities.AddAsync(rt);
        return rt.Id;
    }

    public async Task<RefreshToken> Get(string refreshToken)
    {
        var token = await _dbContex.RefreshTokenEntities
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Token == refreshToken)
                    ?? throw new RefreshTokenNotFound("Refresh token not found");
        return _mapper.Map<RefreshToken>(token);
    }

    public async Task<Guid> Update(Guid tokenId, Guid userId, string token, DateTime expires, bool isRevoked)
    {
        await _dbContex.RefreshTokenEntities
            .Where(rt => rt.Id == tokenId)
            .ExecuteUpdateAsync(rt =>
                rt.SetProperty(r => r.Expires, expires)
                    .SetProperty(r => r.IsRevoked, isRevoked)
                    .SetProperty(r => r.Token, token));
        return tokenId;
    }
}