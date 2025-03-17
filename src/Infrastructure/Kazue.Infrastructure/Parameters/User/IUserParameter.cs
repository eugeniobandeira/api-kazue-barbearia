using Kazue.Domain.Request.User;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.User;
public interface IUserParameter
{
    MySqlDynamicParameters CreateParameters(CreateUserRequest req, Guid id);
    MySqlDynamicParameters GetByIdParameters(Guid id);
    MySqlDynamicParameters GetByEmailParameters(string email);
    MySqlDynamicParameters GetAllParameters(GetUserRequest req);
    MySqlDynamicParameters UpdateParameters(Guid id, UpdateUserRequest req);
    MySqlDynamicParameters ChangePasswordParameters(Guid id, ChangePasswordRequest req);
    MySqlDynamicParameters DeleteParameters(Guid id);
}
