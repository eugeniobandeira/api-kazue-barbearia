using Dapper;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Service;
using Kazue.Infrastructure.Parameters.Service;
using Kazue.Infrastructure.Queries.Service;
using System.Data;

namespace Kazue.Infrastructure.Repository.Service;

public class ServiceRepository(
    IServiceParameter serviceParameter,
    IKazueConnection connection) :

    ICreateServiceRepository,
    IReadServiceRepository,
    IDeleteServiceRepository,
    IUpdateServiceRepository
{
    private readonly IServiceParameter _serviceParameter = serviceParameter;
    private readonly IKazueConnection _connection = connection;

    public async Task<ServiceEntity> Create(ServiceRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _serviceParameter.CreateParameters(req);

        var id = await connection.QueryFirstOrDefaultAsync<Guid>(
            sql: ServiceQuery.SERVICE_SP_CREATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }

    public async Task<ServiceEntity?> GetById(Guid id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _serviceParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<ServiceEntity>(
            sql: ServiceQuery.SERVICE_SP_GET_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<ServiceEntity?> GetByCodeOrDescription(ServiceRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _serviceParameter.GetByCodeOrDescriptionParameters(req);

        return (await connection.QueryAsync<ServiceEntity>(
            sql: ServiceQuery.SERVICE_SP_GET_BY_CODE_OR_DESCRIPTION,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<List<ServiceEntity>> GetAll(GetServiceRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _serviceParameter.GetAllParameters(req);

        return [.. (await connection.QueryAsync<ServiceEntity>(
            sql: ServiceQuery.SERVICE_SP_GET,
            param: parameters,
            commandType: CommandType.StoredProcedure))];
    }

    public async Task DeleteAsync(ServiceEntity serviceEntity)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _serviceParameter.DeleteParameters(serviceEntity.ID_SERVICE);

        await connection.ExecuteAsync(
            sql: ServiceQuery.SERVICE_SP_DELETE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task Update(Guid id, ServiceRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _serviceParameter.UpdateParameters(id, req);

        await connection.ExecuteAsync(
            sql: ServiceQuery.SERVICE_SP_UPDATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}
