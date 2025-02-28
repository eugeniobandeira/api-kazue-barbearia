using Kazue.Domain.Entities.User;
using Kazue.Domain.Request.User;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.User;

public interface ICreateUserRepository
{
    Task<UserEntity> Create(CreateUserRequest req);
}

