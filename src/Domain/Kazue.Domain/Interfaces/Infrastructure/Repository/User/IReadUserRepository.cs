using Kazue.Domain.Entities.User;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.User;

public interface IReadUserRepository
{
    //Task<bool> ExistUserWithEmail(string email);
    Task<UserEntity?> GetByEmail(string email);
    Task<UserEntity?> GetById(long id);
}
