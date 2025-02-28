using Kazue.Domain.Entities.User;

namespace Kazue.Infrastructure.Repository.User;

public interface IDeleteUserRepository
{
    Task DeleteAsync(UserEntity userEntity);
}