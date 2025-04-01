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

        parameters.Add("P_ID_STATUS", MySqlDbType.Guid, ParameterDirection.Input, req.IdStatus);
        parameters.Add("P_DS_CUSTOMER", MySqlDbType.Guid, ParameterDirection.Input, req.IdCustomer);
        parameters.Add("P_ID_BARBER", MySqlDbType.Guid, ParameterDirection.Input, req.IdBarber);
        parameters.Add("P_ID_SERVICES", MySqlDbType.String, ParameterDirection.Input, req.IdServices);
        parameters.Add("P_VL_AMOUNT", MySqlDbType.Decimal, ParameterDirection.Input, req.Amount);

        return parameters;
    }

    public MySqlDynamicParameters GetByIdParameters(long id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_QUEUE", MySqlDbType.Int64, ParameterDirection.Input, id);

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
        parameters.Add("P_PAGE", MySqlDbType.Int64, ParameterDirection.Input, req.Page);
        parameters.Add("P_PAGE_SIZE", MySqlDbType.Int64, ParameterDirection.Input, req.PageSize);

        return parameters;
    }

    public MySqlDynamicParameters DeleteParameters(long id)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_QUEUE", MySqlDbType.Int64, ParameterDirection.Input, id);

        return parameters;
    }

    public MySqlDynamicParameters UpdateParameters(long id, QueueRequest req)
    {
        var parameters = new MySqlDynamicParameters();

        parameters.Add("P_ID_QUEUE", MySqlDbType.Int64, ParameterDirection.Input, id);
        parameters.Add("P_ID_STATUS", MySqlDbType.Int64, ParameterDirection.Input, req.IdStatus);
        parameters.Add("P_ID_BARBER", MySqlDbType.Guid, ParameterDirection.Input, req.IdBarber);
        parameters.Add("P_ID_CUSTOMER", MySqlDbType.Guid, ParameterDirection.Input, req.IdCustomer);
        parameters.Add("P_ID_SERVICES", MySqlDbType.String, ParameterDirection.Input, req.IdServices);
        parameters.Add("P_VL_AMOUNT", MySqlDbType.Decimal, ParameterDirection.Input, req.Amount);

        return parameters;
    }
}
