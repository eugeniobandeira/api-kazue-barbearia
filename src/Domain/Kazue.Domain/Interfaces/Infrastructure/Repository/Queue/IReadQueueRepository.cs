using Kazue.Domain.Entities.Queue;
using Kazue.Domain.Request.Queue;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;

public interface IReadQueueRepository
{
    Task<QueueEntity?> GetById(long id);
    Task<QueueEntity?> GetByIdUser(Guid id);
    Task<List<QueueEntity>> GetAll(GetQueueRequest req);
}
