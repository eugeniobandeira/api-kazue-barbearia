using Kazue.Domain.Request.Status;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Status;

public class StatusParameter : IStatusParameter
{
    public MySqlDynamicParameters CreateParameters(StatusRequest req)
    {
        throw new NotImplementedException();
    }

    public MySqlDynamicParameters UpdateParameters(StatusRequest req)
    {
        throw new NotImplementedException();
    }

    public MySqlDynamicParameters GetByIdParameters(long id)
    {
        throw new NotImplementedException();
    }
}
