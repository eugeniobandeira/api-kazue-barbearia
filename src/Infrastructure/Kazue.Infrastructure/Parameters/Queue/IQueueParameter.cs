using Kazue.Domain.Request.Queue;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Queue;

public interface IQueueParameter
{
    MySqlDynamicParameters CreateParameters(QueueRequest req);
    MySqlDynamicParameters UpdateParameters(Guid id, QueueRequest req);
    MySqlDynamicParameters GetByIdParameters(Guid id);
    MySqlDynamicParameters GetUserByIdParameters(Guid id);
    MySqlDynamicParameters GetAllParameters(GetQueueRequest req);
    MySqlDynamicParameters DeleteParameters(Guid id);
}
