using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Interfaces.Service.LoggedUser;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Kazue.Infrastructure.Service.LoggedUser;

internal class LoggedUser : ILoggedUser
{
    private readonly IKazueConnection _connection;
    private readonly IReadUserRepository _readUserRepository;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(IKazueConnection connection, IReadUserRepository readUserRepository, ITokenProvider tokenProvider)
    {
        _connection = connection;
        _readUserRepository = readUserRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<UserEntity> GetAsync()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        var identifierClaim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

        if (string.IsNullOrEmpty(identifierClaim) || !int.TryParse(identifierClaim, out int userId))
            return null;

        await using var connection = _connection.GetConnection();

        var loggedUser = await _readUserRepository.GetById(userId);

        return loggedUser;

    }
}