using Kazue.Domain.Entities.Service;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Service;

public interface IDeleteServiceRepository
{
    Task DeleteAsync(ServiceEntity serviceEntity);
}
