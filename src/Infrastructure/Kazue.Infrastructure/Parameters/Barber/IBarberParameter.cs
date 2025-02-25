using Kazue.Domain.Request.Barber;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Barber;
public interface IBarberParameter
{
    MySqlDynamicParameters CreateParameters(CreateBarberRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
}
