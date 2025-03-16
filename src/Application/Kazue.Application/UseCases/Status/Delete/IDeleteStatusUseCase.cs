namespace Kazue.Application.UseCases.Status.Delete;

public interface IDeleteStatusUseCase
{
    Task ExecuteAsync(Guid id);
}
