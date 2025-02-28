using Kazue.Domain.Entities.User;

namespace Kazue.Infrastructure.Repository.User;

public interface IUpdateUserRepository
{
    void Update(UserEntity req);
}
