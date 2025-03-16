using Kazue.Domain.Request.Queue;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;

public interface IUpdateQueueRepository
{
    Task UpdateAsync(Guid id, QueueRequest req);
}
