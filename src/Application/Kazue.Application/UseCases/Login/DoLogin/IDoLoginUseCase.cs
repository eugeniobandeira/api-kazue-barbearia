using Kazue.Domain.Request.Login;
using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.Login.DoLogin;

public interface IDoLoginUseCase
{
    Task<RegisteredUserResponse> Execute(LoginRequest req);
}
