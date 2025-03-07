using Kazue.Domain.Entities.Queue;
using Kazue.Domain.Request.Queue;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;

public interface ICreateQueueRepository
{
    Task<QueueEntity> CreateAsync(QueueRequest queueRequest);
}
