using Kazue.Domain.Request.Service;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Service;

public interface IServiceParameter
{
    MySqlDynamicParameters CreateParameters(ServiceRequest req);
    MySqlDynamicParameters UpdateParameters(ServiceRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
}
