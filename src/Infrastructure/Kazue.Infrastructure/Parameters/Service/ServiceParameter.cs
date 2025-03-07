using Kazue.Domain.Request.Service;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Service;

public class ServiceParameter : IServiceParameter
{
    public MySqlDynamicParameters CreateParameters(ServiceRequest req)
    {
        throw new NotImplementedException();
    }

    public MySqlDynamicParameters GetByIdParameters(long id)
    {
        throw new NotImplementedException();
    }

    public MySqlDynamicParameters UpdateParameters(ServiceRequest req)
    {
        throw new NotImplementedException();
    }
}
