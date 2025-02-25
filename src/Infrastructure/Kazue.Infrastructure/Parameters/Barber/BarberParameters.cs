using Kazue.Domain.Request.Barber;
using Kazue.Infrastructure.Helpers;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kazue.Infrastructure.Parameters.Barber;

public class BarberParameters : 
    IBarberParameter
{
    public MySqlDynamicParameters CreateParameters(CreateBarberRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_DS_NAME", MySqlDbType.String, ParameterDirection.Input, req.Name);
        parameters.Add("P_DS_SURNAME", MySqlDbType.String, ParameterDirection.Input, req.Surname);
        parameters.Add("P_DS_NICKNAME", MySqlDbType.String, ParameterDirection.Input, req.Nickname);
        parameters.Add("P_DS_EMAIL", MySqlDbType.String, ParameterDirection.Input, req.Email);
        parameters.Add("P_DS_PHONE", MySqlDbType.String, ParameterDirection.Input, req.Phone);
        parameters.Add("P_DS_ROLE", MySqlDbType.String, ParameterDirection.Input, req.Role);

        parameters.Add("P_DS_PASSWORD", MySqlDbType.String, ParameterDirection.Input, req.Password);

        parameters.Add("P_DT_BIRTH", MySqlDbType.DateTime, direction: ParameterDirection.Input, req.DateOfBirth);

        return parameters;
    }

    public MySqlDynamicParameters GetByIdParameters(long id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_BARBER", MySqlDbType.Int32, ParameterDirection.Input, id);

        return parameters;
    }
}
