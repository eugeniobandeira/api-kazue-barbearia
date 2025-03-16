using Kazue.Domain.Request.Status;
using Kazue.Infrastructure.Helpers;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kazue.Infrastructure.Parameters.Status;

public class StatusParameter : IStatusParameter
{
    public MySqlDynamicParameters CreateParameters(StatusRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_CD_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Description);

        return parameters;
    }

    public MySqlDynamicParameters GetByIdParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_STATUS", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters UpdateParameters(Guid id, StatusRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_STATUS", MySqlDbType.Guid, ParameterDirection.Input, id);
        parameters.Add("P_CD_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Description);

        return parameters;
    }

    public MySqlDynamicParameters GetByCodeOrDescriptionParameters(StatusRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_CD_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Description);

        return parameters;
    }

    public MySqlDynamicParameters GetAllParameters(GetStatusRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_CD_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_STATUS", MySqlDbType.String, ParameterDirection.Input, req.Description);
        parameters.Add("P_PAGE", MySqlDbType.Int64, ParameterDirection.Input, req.Page);
        parameters.Add("P_PAGE_SIZE", MySqlDbType.Int64, ParameterDirection.Input, req.PageSize);

        return parameters;
    }

    public MySqlDynamicParameters DeleteParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_STATUS", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }
}
