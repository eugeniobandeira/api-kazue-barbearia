using Kazue.Domain.Request.User;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.User.Get;

public interface IGetUserUseCase
{
    Task<ListApiResponse<UserResponse>> ExecuteAsync(GetUserRequest req);
}
