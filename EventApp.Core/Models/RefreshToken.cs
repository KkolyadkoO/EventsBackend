namespace EventApp.Core.Models;

public class RefreshToken
{
    public RefreshToken(Guid id, Guid userId, string token, DateTime expires, bool revoked)
    {
        Id = id;
        UserId = userId;
        Token = token;
        Expires = expires;
        IsRevoked = revoked;
    }
    

    public Guid Id { get;  }
    public Guid UserId { get; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsRevoked { get; }
}
