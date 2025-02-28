using Kazue.Domain.Entities.User;

namespace Kazue.Domain.Interfaces.Security.Token;

public interface IJwtTokenGenerator
{
    string Generate(UserEntity userEntity);
}