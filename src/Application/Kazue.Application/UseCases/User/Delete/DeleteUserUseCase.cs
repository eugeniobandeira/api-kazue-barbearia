
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Service.LoggedUser;

namespace Kazue.Application.UseCases.User.Delete;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IDeleteUserRepository _deleteUserRepository;

    public DeleteUserUseCase(ILoggedUser loggedUser, IDeleteUserRepository deleteUserRepository)
    {
        _loggedUser = loggedUser;
        _deleteUserRepository = deleteUserRepository;
    }

    public async Task ExecuteAsync()
    {
        var user = await _loggedUser.GetAsync();

        await _deleteUserRepository.DeleteAsync(user);
    }
}
