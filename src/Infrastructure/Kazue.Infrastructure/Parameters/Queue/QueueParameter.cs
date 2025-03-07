using Kazue.Domain.Request.Queue;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Queue;

public class QueueParameter : IQueueParameter
{
    public MySqlDynamicParameters CreateParameters(QueueRequest req)
    {
        throw new NotImplementedException();
    }

    public MySqlDynamicParameters GetByIdParameters(long id)
    {
        throw new NotImplementedException();
    }

    public MySqlDynamicParameters UpdateParameters(long id, QueueRequest req)
    {
        throw new NotImplementedException();
    }
}
