using Kazue.Domain.Request.User;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.User;
public interface IUserParameter
{
    MySqlDynamicParameters CreateParameters(CreateUserRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
}
