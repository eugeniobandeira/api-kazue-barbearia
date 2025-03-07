using Kazue.Domain.Entities.Status;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Status;

public interface IDeleteStatusRepository
{
    Task DeleteAsync(StatusEntity statusEntity);
}
