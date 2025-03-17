using Kazue.Domain.Request.Status;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Status;

public interface IUpdateStatusRepository
{
    Task UpdateAsync(long id, StatusRequest req);
}
