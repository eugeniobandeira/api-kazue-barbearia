using Kazue.Domain.Entities.User;
using Kazue.Domain.Request.User;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.User;

public interface IReadUserRepository
{
    Task<UserEntity?> GetByEmail(string email);
    Task<UserEntity?> GetById(Guid id);
    Task<List<UserEntity>> GetAll(GetUserRequest req);
}
