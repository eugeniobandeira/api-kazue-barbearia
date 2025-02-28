using Kazue.Application.Adapter.User;
using Kazue.Domain.Response.Person;
using Kazue.Infrastructure.Repository.User;

namespace Kazue.Application.UseCases.User.GetById;

public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> ExecuteAsync(long id)
    {
        var repositoryResponse = await _userRepository.GetById(id);

        var response = UserAdapter.FromEntityToResponse(repositoryResponse);

        return response;
    }
}
