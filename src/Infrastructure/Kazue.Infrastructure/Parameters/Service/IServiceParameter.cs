using Kazue.Domain.Request.Service;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Service;

public interface IServiceParameter
{
    MySqlDynamicParameters CreateParameters(ServiceRequest req);
    MySqlDynamicParameters UpdateParameters(Guid id, ServiceRequest req);
    MySqlDynamicParameters GetByIdParameters(Guid id);
    MySqlDynamicParameters GetByCodeOrDescriptionParameters(ServiceRequest req);
    MySqlDynamicParameters GetAllParameters(GetServiceRequest req);
    MySqlDynamicParameters DeleteParameters(Guid id);
}
