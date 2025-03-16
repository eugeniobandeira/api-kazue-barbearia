using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Interfaces.Service.LoggedUser;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Kazue.Infrastructure.Service.LoggedUser;

internal class LoggedUser(
    IKazueConnection connection,
    IReadUserRepository readUserRepository,
    ITokenProvider tokenProvider) : ILoggedUser
{
    private readonly IKazueConnection _connection = connection;
    private readonly IReadUserRepository _readUserRepository = readUserRepository;
    private readonly ITokenProvider _tokenProvider = tokenProvider;

    public async Task<UserEntity> GetAsync()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        var identifierClaim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

        if (string.IsNullOrEmpty(identifierClaim) || !Guid.TryParse(identifierClaim, out Guid userId))
            return null;

        await using var connection = _connection.GetConnection();

        var loggedUser = await _readUserRepository.GetById(userId);

        return loggedUser;

    }
}