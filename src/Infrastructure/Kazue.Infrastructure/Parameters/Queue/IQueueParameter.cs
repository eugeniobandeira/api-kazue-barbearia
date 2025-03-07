using Kazue.Domain.Request.Queue;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Queue;

public interface IQueueParameter
{
    MySqlDynamicParameters CreateParameters(QueueRequest req);
    MySqlDynamicParameters UpdateParameters(long id, QueueRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
}
