using Kazue.Domain.Request.Status;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Status;

public interface IStatusParameter
{
    MySqlDynamicParameters CreateParameters(StatusRequest req);
    MySqlDynamicParameters UpdateParameters(long id, StatusRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
    MySqlDynamicParameters GetByCodeOrDescriptionParameters(StatusRequest req);
    MySqlDynamicParameters GetAllParameters(GetStatusRequest req);
    MySqlDynamicParameters DeleteParameters(long id);
}
