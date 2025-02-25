using Kazue.Domain.Entities.Barber;
using Kazue.Domain.Request.Barber;

namespace Kazue.Infrastructure.Repository.Barber;

public interface IBarberRepository
{
    Task<BarberEntity> Create(CreateBarberRequest req);
    Task<BarberEntity?> GetById(long id);
}
