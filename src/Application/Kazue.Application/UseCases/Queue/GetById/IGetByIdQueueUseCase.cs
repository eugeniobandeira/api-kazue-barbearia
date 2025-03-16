using Kazue.Domain.Response.Queue;

namespace Kazue.Application.UseCases.Queue.GetById;

public interface IGetByIdQueueUseCase
{
    Task<QueueResponse> ExecuteAsync(Guid id);
}
