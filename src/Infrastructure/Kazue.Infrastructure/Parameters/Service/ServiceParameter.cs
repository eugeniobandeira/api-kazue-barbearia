using Kazue.Domain.Request.Service;
using Kazue.Infrastructure.Helpers;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kazue.Infrastructure.Parameters.Service;

public class ServiceParameter : IServiceParameter
{
    public MySqlDynamicParameters CreateParameters(ServiceRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_CD_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Description);

        return parameters;
    }

    public MySqlDynamicParameters DeleteParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_SERVICE", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters GetAllParameters(GetServiceRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_CD_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Description);
        parameters.Add("P_PAGE", MySqlDbType.Int64, ParameterDirection.Input, req.Page);
        parameters.Add("P_PAGE_SIZE", MySqlDbType.Int64, ParameterDirection.Input, req.PageSize);

        return parameters;
    }

    public MySqlDynamicParameters GetByCodeOrDescriptionParameters(ServiceRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_CD_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Description);

        return parameters;
    }

    public MySqlDynamicParameters GetByIdParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_SERVICE", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters UpdateParameters(Guid id, ServiceRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_SERVICE", MySqlDbType.Guid, ParameterDirection.Input, id);
        parameters.Add("P_CD_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Code);
        parameters.Add("P_DS_SERVICE", MySqlDbType.String, ParameterDirection.Input, req.Description);

        return parameters;
    }
}
