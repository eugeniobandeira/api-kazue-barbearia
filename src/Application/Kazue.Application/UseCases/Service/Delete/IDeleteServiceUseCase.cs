namespace Kazue.Application.UseCases.Service.Delete;

public interface IDeleteServiceUseCase
{
    Task ExecuteAsync(long id);
}
