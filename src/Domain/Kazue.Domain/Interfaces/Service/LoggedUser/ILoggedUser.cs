using Kazue.Domain.Entities.User;

namespace Kazue.Domain.Interfaces.Service.LoggedUser;

public interface ILoggedUser
{
    Task<UserEntity> GetAsync();
}
