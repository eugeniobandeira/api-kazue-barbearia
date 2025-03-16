using Kazue.Domain.Request.Queue;
using Kazue.Infrastructure.Helpers;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kazue.Infrastructure.Parameters.Queue;

public class QueueParameter : IQueueParameter
{
    public MySqlDynamicParameters CreateParameters(QueueRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_BARBER", MySqlDbType.Guid, ParameterDirection.Input, req.IdBarber);
        parameters.Add("P_DS_CUSTOMER", MySqlDbType.Guid, ParameterDirection.Input, req.IdCustomer);
        parameters.Add("P_ID_SERVICES", MySqlDbType.String, ParameterDirection.Input, req.IdServices);

        return parameters;
    }

    public MySqlDynamicParameters GetByIdParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_QUEUE", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters GetUserByIdParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_USER", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters GetAllParameters(GetQueueRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_BARBER", MySqlDbType.Guid, ParameterDirection.Input, req.IdBarber);
        parameters.Add("P_ID_CUSTOMER", MySqlDbType.Guid, ParameterDirection.Input, req.IdCustomer);
        parameters.Add("P_CD_SERVICES", MySqlDbType.String, ParameterDirection.Input, req.CdService);
        parameters.Add("P_PAGE", MySqlDbType.Int64, ParameterDirection.Input, req.Page);
        parameters.Add("P_PAGE_SIZE", MySqlDbType.Int64, ParameterDirection.Input, req.PageSize);

        return parameters;
    }

    public MySqlDynamicParameters DeleteParameters(Guid id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_QUEUE", MySqlDbType.Guid, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters UpdateParameters(Guid id, QueueRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_QUEUE", MySqlDbType.Guid, ParameterDirection.Input, id);
        parameters.Add("P_ID_BARBER", MySqlDbType.Guid, ParameterDirection.Input, req.IdBarber);
        parameters.Add("P_DS_CUSTOMER", MySqlDbType.Guid, ParameterDirection.Input, req.IdCustomer);
        parameters.Add("P_ID_SERVICES", MySqlDbType.String, ParameterDirection.Input, req.IdServices);

        return parameters;
    }
}
