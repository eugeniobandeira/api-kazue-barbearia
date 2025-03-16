using Kazue.Domain.Request.User;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.User;

public interface IUpdateUserRepository
{
    Task UpdateAsync(Guid id, UpdateUserRequest req);
    Task ChangePasswordAsync(Guid id, ChangePasswordRequest req);
}
