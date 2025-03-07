using Kazue.Domain.Entities.Service;
using Kazue.Domain.Request.Service;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Service;

public interface ICreateServiceRepository
{
    Task<ServiceEntity> Create(ServiceRequest req);
}
