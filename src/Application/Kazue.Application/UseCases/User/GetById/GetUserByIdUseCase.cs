using Kazue.Application.Adapter.User;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Response.Person;

namespace Kazue.Application.UseCases.User.GetById;

public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IReadUserRepository _readUserRepository;

    public GetUserByIdUseCase(IReadUserRepository readUserRepository)
    {
        _readUserRepository = readUserRepository;
    }

    public async Task<UserResponse> ExecuteAsync(long id)
    {
        var repositoryResponse = await _readUserRepository.GetById(id);

        var response = UserAdapter.FromEntityToResponse(repositoryResponse);

        return response;
    }
}
