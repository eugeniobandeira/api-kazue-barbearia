namespace Kazue.Application.UseCases.Queue.Delete;

public interface IDeleteQueueUseCase
{
    Task ExecuteAsync(long id);
}
