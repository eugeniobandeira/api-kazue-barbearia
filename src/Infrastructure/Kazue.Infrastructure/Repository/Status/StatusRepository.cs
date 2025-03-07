using Kazue.Domain.Entities.Status;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Request.Status;

namespace Kazue.Infrastructure.Repository.Status;

public class StatusRepository :
    ICreateStatusRepository,
    IReadStatusRepository,
    IUpdateStatusRepository,
    IDeleteStatusRepository
{
    public Task<StatusEntity> Create(StatusRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<StatusEntity?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<StatusEntity?> GetByCodeOrDescription(StatusRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<List<StatusEntity>> GetAll(GetStatusRequest req)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(StatusEntity statusEntity)
    {
        throw new NotImplementedException();
    }

    public Task Update(long id, StatusRequest req)
    {
        throw new NotImplementedException();
    }
}
