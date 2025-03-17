using Kazue.Domain.Request.Service;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Service;

public interface IUpdateServiceRepository
{
    Task UpdateAsync(long id, ServiceRequest req);
}
