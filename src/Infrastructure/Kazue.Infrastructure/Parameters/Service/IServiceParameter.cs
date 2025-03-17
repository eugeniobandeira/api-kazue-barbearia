using Kazue.Domain.Request.Service;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Service;

public interface IServiceParameter
{
    MySqlDynamicParameters CreateParameters(ServiceRequest req);
    MySqlDynamicParameters UpdateParameters(long id, ServiceRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
    MySqlDynamicParameters GetByCodeOrDescriptionParameters(ServiceRequest req);
    MySqlDynamicParameters GetAllParameters(GetServiceRequest req);
    MySqlDynamicParameters DeleteParameters(long id);
}
