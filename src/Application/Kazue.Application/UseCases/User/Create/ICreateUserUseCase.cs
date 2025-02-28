using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.User.Create;
public interface ICreateUserUseCase
{
    Task<RegisteredUserResponse> ExecuteAsync(CreateUserRequest req);
}
