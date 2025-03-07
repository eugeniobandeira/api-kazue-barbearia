using Kazue.Domain.Request.Status;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Status;

public interface IUpdateStatusRepository
{
    Task Update(long id, StatusRequest req);
}
