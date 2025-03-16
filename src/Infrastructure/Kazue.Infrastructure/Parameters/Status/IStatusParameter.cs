using Kazue.Domain.Request.Status;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Status;

public interface IStatusParameter
{
    MySqlDynamicParameters CreateParameters(StatusRequest req);
    MySqlDynamicParameters UpdateParameters(Guid id, StatusRequest req);
    MySqlDynamicParameters GetByIdParameters(Guid id);
    MySqlDynamicParameters GetByCodeOrDescriptionParameters(StatusRequest req);
    MySqlDynamicParameters GetAllParameters(GetStatusRequest req);
    MySqlDynamicParameters DeleteParameters(Guid id);
}
