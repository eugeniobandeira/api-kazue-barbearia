
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Service.LoggedUser;

namespace Kazue.Application.UseCases.User.Delete;

public class DeleteUserUseCase(
    ILoggedUser loggedUser, 
    IDeleteUserRepository deleteUserRepository) 
    : IDeleteUserUseCase
{
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IDeleteUserRepository _deleteUserRepository = deleteUserRepository;

    public async Task ExecuteAsync(Guid id)
    {
        var user = await _loggedUser.GetAsync();

        await _deleteUserRepository.DeleteAsync(user.ID_USER);
    }
}
