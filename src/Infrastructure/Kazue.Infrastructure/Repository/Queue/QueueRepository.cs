using Kazue.Domain.Entities.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Request.Queue;

namespace Kazue.Infrastructure.Repository.Queue;

public class QueueRepository :
    ICreateQueueRepository,
    IDeleteQueueRepository,
    IReadQueueRepository,
    IUpdateQueueRepository
{
    public Task UpdateAsync(long id, QueueRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<QueueEntity> CreateAsync(QueueRequest queueRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(QueueEntity queueEntity)
    {
        throw new NotImplementedException();
    }

    public Task<QueueEntity?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<QueueEntity?> GetByIdUser(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<QueueEntity>> GetAll(GetQueueRequest req)
    {
        throw new NotImplementedException();
    }
}
