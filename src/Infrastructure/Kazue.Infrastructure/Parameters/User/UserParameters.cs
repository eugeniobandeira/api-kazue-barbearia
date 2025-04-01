using Kazue.Domain.Request.User;
using Kazue.Infrastructure.Helpers;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kazue.Infrastructure.Parameters.User;

public class UserParameters : IUserParameter
{
    public MySqlDynamicParameters CreateParameters(CreateUserRequest req, Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_USER", MySqlDbType.Guid, ParameterDirection.Input, id.ToString());
        parameters.Add("P_DS_FULLNAME", MySqlDbType.String, ParameterDirection.Input, req.Fullname);
        parameters.Add("P_DS_NICKNAME", MySqlDbType.String, ParameterDirection.Input, req.Nickname);
        parameters.Add("P_CK_NICKNAME_PREFERENCE", MySqlDbType.Binary, ParameterDirection.Input, req.NicknamePreference == true ? 1 : 0);
        parameters.Add("P_DS_EMAIL", MySqlDbType.String, ParameterDirection.Input, req.Email);
        parameters.Add("P_DS_PHONE", MySqlDbType.String, ParameterDirection.Input, req.Phone);
        parameters.Add("P_DS_ROLE", MySqlDbType.String, ParameterDirection.Input, req.Role);
        parameters.Add("P_DS_PASSWORD", MySqlDbType.String, ParameterDirection.Input, req.Password);
        parameters.Add("P_DT_BIRTH", MySqlDbType.DateTime, ParameterDirection.Input, req.DateOfBirth);

        return parameters;
    }

    public MySqlDynamicParameters GetByIdParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_USER", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters GetByEmailParameters(string email)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_DS_EMAIL", MySqlDbType.String, ParameterDirection.Input, email);

        return parameters;
    }

    public MySqlDynamicParameters UpdateParameters(Guid id, UpdateUserRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_USER", MySqlDbType.Guid, ParameterDirection.Input, id);
        parameters.Add("P_DS_FULLNAME", MySqlDbType.String, ParameterDirection.Input, req.Fullname);
        parameters.Add("P_DS_NICKNAME", MySqlDbType.String, ParameterDirection.Input, req.Nickname);
        parameters.Add("P_CK_NICKNAME_PREFERENCE", MySqlDbType.Binary, ParameterDirection.Input, req.NicknamePreference);
        parameters.Add("P_DS_EMAIL", MySqlDbType.String, ParameterDirection.Input, req.Email);
        parameters.Add("P_DS_PHONE", MySqlDbType.String, ParameterDirection.Input, req.Phone);

        return parameters;
    }

    public MySqlDynamicParameters GetAllParameters(GetUserRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_DS_FULLNAME", MySqlDbType.String, ParameterDirection.Input, req.Fullname);
        parameters.Add("P_DS_NICKNAME", MySqlDbType.String, ParameterDirection.Input, req.Nickname);
        parameters.Add("P_DS_EMAIL", MySqlDbType.String, ParameterDirection.Input, req.Email);
        parameters.Add("P_DS_PHONE", MySqlDbType.String, ParameterDirection.Input, req.Phone);
        parameters.Add("P_PAGE", MySqlDbType.Int64, ParameterDirection.Input, req.Page);
        parameters.Add("P_PAGE_SIZE", MySqlDbType.Int64, ParameterDirection.Input, req.PageSize);

        return parameters;
    }

    public MySqlDynamicParameters DeleteParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_USER", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters ChangePasswordParameters(Guid id, ChangePasswordRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_USER", MySqlDbType.Guid, ParameterDirection.Input, id);
        parameters.Add("P_DS_PASSWORD", MySqlDbType.String, ParameterDirection.Input, req.NewPassword);

        return parameters;
    }
}
