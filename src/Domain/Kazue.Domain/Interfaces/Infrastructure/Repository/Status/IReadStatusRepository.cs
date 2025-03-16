using Kazue.Domain.Entities.Status;
using Kazue.Domain.Request.Status;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Status;

public interface IReadStatusRepository
{
    Task<StatusEntity?> GetById(Guid id);
    Task<StatusEntity?> GetByCodeOrDescription(StatusRequest req);
    Task<List<StatusEntity>> GetAll(GetStatusRequest req);
}
