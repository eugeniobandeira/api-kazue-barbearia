using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Security.Token;
using Microsoft.IdentityModel.Tokens;

namespace Kazue.Infrastructure.Security.Token;

internal class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;

    public JwtTokenGenerator(uint expirationTimeMinutes, string signingKey)
    {
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;
    }

    public string Generate(UserEntity userEntity)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, userEntity.DS_NAME),
            new(ClaimTypes.Sid, userEntity.ID_USER.ToString()),
            new(ClaimTypes.Role, userEntity.DS_ROLE),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);

        return new SymmetricSecurityKey(key);
    }
}
