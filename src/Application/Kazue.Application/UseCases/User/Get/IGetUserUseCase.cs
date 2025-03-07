using Kazue.Domain.Request.User;
using Kazue.Domain.Response.Person;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.User.Get;

public interface IGetUserUseCase
{
    Task<ListApiResponse<UserResponse>> ExecuteAsync(GetUserRequest req);
}
