using Kazue.Domain.Response.Person;

namespace Kazue.Application.UseCases.User.GetById;

public interface IGetUserByIdUseCase
{
    Task<UserResponse> ExecuteAsync(long id);
}
