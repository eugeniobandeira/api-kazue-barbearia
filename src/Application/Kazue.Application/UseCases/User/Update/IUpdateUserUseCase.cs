using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.User.Update;

public interface IUpdateUserUseCase
{
    Task<UserProfileResponse> ExecuteAsync(UpdateUserRequest req);
}
