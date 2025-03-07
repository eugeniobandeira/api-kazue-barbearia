using Kazue.Domain.Entities.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Service;

namespace Kazue.Infrastructure.Repository.Service;

public class ServiceRepository :
    ICreateServiceRepository,
    IReadServiceRepository,
    IDeleteServiceRepository,
    IUpdateServiceRepository
{
    public Task<ServiceEntity> Create(ServiceRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceEntity?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceEntity?> GetByCodeOrDescription(ServiceRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceEntity>> GetAll(GetServiceRequest req)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(ServiceEntity serviceEntity)
    {
        throw new NotImplementedException();
    }

    public Task Update(long id, ServiceRequest req)
    {
        throw new NotImplementedException();
    }
}
