using Kazue.Domain.Entities.Queue;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;

public interface IDeleteQueueRepository
{
    Task DeleteAsync(QueueEntity queueEntity);
}
