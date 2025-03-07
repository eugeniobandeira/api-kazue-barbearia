using Kazue.Domain.Request.Status;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Status;

public interface IStatusParameter
{
    MySqlDynamicParameters CreateParameters(StatusRequest req);
    MySqlDynamicParameters UpdateParameters(StatusRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
}
