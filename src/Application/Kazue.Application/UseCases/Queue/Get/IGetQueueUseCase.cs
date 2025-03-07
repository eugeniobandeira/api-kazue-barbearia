using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Queue;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.Queue.Get;

public interface IGetQueueUseCase
{
    Task<ListApiResponse<QueueResponse>> ExecuteAsync(GetQueueRequest req);
}
