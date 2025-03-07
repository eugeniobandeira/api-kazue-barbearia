using Kazue.Domain.Entities.Service;
using Kazue.Domain.Request.Service;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Service;

public interface IReadServiceRepository
{
    Task<ServiceEntity?> GetById(long id);
    Task<ServiceEntity?> GetByCodeOrDescription(ServiceRequest req);
    Task<List<ServiceEntity>> GetAll(GetServiceRequest req);
}
