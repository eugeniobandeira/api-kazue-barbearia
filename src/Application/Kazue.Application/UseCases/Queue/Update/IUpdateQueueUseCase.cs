using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Queue;

namespace Kazue.Application.UseCases.Queue.Update;

public interface IUpdateQueueUseCase
{
    Task<QueueResponse> ExecuteAsync(long id, QueueRequest req);
}
