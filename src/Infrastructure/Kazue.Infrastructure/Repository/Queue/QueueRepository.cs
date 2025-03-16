using Dapper;
using Kazue.Domain.Entities.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Request.Queue;
using Kazue.Infrastructure.Parameters.Queue;
using Kazue.Infrastructure.Queries.Queue;
using System.Data;

namespace Kazue.Infrastructure.Repository.Queue;

public class QueueRepository(
    IQueueParameter queueParameter,
    IKazueConnection connection) :

    ICreateQueueRepository,
    IDeleteQueueRepository,
    IReadQueueRepository,
    IUpdateQueueRepository
{
    private readonly IQueueParameter _queueParameter = queueParameter;
    private readonly IKazueConnection _connection = connection;

    public async Task<QueueEntity> CreateAsync(QueueRequest queueRequest)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _queueParameter.CreateParameters(queueRequest);

        var id = await connection.QueryFirstOrDefaultAsync<Guid>(
            sql: QueueQuery.QUEUE_SP_CREATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }

    public async Task<QueueEntity?> GetById(Guid id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _queueParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<QueueEntity>(
            sql: QueueQuery.QUEUE_SP_GET_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<QueueEntity?> GetByIdUser(Guid id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _queueParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<QueueEntity>(
            sql: QueueQuery.QUEUE_SP_GET_BY_ID_USER,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<List<QueueEntity>> GetAll(GetQueueRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _queueParameter.GetAllParameters(req);

        return [.. (await connection.QueryAsync<QueueEntity>(
            sql: QueueQuery.QUEUE_SP_GET,
            param: parameters,
            commandType: CommandType.StoredProcedure))];
    }

    public async Task DeleteAsync(QueueEntity queueEntity)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _queueParameter.DeleteParameters(queueEntity.ID_QUEUE);

        await connection.ExecuteAsync(
            sql: QueueQuery.QUEUE_SP_DELETE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task UpdateAsync(Guid id, QueueRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _queueParameter.UpdateParameters(id, req);

        await connection.ExecuteAsync(
            sql: QueueQuery.QUEUE_SP_UPDATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}
