using Kazue.Application.Adapter.User;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Response.User;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.User.GetById;

public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IReadUserRepository _readUserRepository;

    public GetUserByIdUseCase(IReadUserRepository readUserRepository)
    {
        _readUserRepository = readUserRepository;
    }

    public async Task<UserResponse> ExecuteAsync(Guid id)
    {
        var repositoryResponse = await _readUserRepository.GetById(id);

        if (repositoryResponse is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        var response = UserAdapter.FromEntityToResponse(repositoryResponse);

        return response;
    }
}
