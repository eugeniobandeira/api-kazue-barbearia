using Kazue.Domain.Entities.User;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.User;

public interface IDeleteUserRepository
{
    Task DeleteAsync(UserEntity userEntity);
}