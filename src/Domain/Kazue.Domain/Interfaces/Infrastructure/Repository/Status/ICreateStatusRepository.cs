using Kazue.Domain.Entities.Status;
using Kazue.Domain.Request.Status;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Status;

public interface ICreateStatusRepository
{
    Task<StatusEntity> Create(StatusRequest req);
}
