using Kazue.Domain.Request.User;

namespace Kazue.Application.UseCases.User.ChangePassword;

public interface IChangePasswordUserUseCase
{
    Task ExecuteAsync(Guid id, ChangePasswordRequest req);
}
