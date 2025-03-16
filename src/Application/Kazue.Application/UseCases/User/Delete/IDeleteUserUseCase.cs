namespace Kazue.Application.UseCases.User.Delete;

public interface IDeleteUserUseCase
{
    Task ExecuteAsync(Guid id);
}
