using Dapper;
using Kazue.Domain.Entities.Status;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Request.Status;
using Kazue.Infrastructure.Parameters.Status;
using Kazue.Infrastructure.Queries.Status;
using System.Data;

namespace Kazue.Infrastructure.Repository.Status;

public class StatusRepository(
    IStatusParameter statusParameter,
    IKazueConnection connection) :

    ICreateStatusRepository,
    IReadStatusRepository,
    IUpdateStatusRepository,
    IDeleteStatusRepository
{
    private readonly IStatusParameter _statusParameter = statusParameter;
    private readonly IKazueConnection _connection = connection;

    public async Task<StatusEntity> Create(StatusRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _statusParameter.CreateParameters(req);

        var id = await connection.QueryFirstOrDefaultAsync<long>(
            sql: StatusQuery.STATUS_SP_CREATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }

    public async Task<StatusEntity?> GetById(long id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _statusParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<StatusEntity>(
            sql: StatusQuery.STATUS_SP_GET_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<StatusEntity?> GetByCodeOrDescription(StatusRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _statusParameter.GetByCodeOrDescriptionParameters(req);

        return (await connection.QueryAsync<StatusEntity>(
            sql: StatusQuery.STATUS_SP_GET_BY_CODE_OR_DESCRIPTION,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<List<StatusEntity>> GetAll(GetStatusRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _statusParameter.GetAllParameters(req);

        return [.. (await connection.QueryAsync<StatusEntity>(
            sql: StatusQuery.STATUS_SP_GET,
            param: parameters,
            commandType: CommandType.StoredProcedure))];
    }

    public async Task DeleteAsync(StatusEntity statusEntity)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _statusParameter.DeleteParameters(statusEntity.ID_STATUS);

        await connection.ExecuteAsync(
            sql: StatusQuery.STATUS_SP_DELETE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

    }

    public async Task UpdateAsync(long id, StatusRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _statusParameter.UpdateParameters(id, req);

        await connection.ExecuteAsync(
            sql: StatusQuery.STATUS_SP_UPDATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}
