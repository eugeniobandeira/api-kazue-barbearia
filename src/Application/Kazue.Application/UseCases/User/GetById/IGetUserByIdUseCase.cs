using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.User.GetById;

public interface IGetUserByIdUseCase
{
    Task<UserResponse> ExecuteAsync(Guid id);
}
