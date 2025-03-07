using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Queue;

namespace Kazue.Application.UseCases.Queue.Create;

public interface ICreateQueueUseCase
{
    Task<QueueResponse> ExecuteAsync(QueueRequest req);
}
