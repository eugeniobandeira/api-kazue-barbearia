using Dapper;
using Kazue.Domain.Entities.Barber;
using Kazue.Domain.Interfaces.Connection;
using Kazue.Domain.Request.Barber;
using Kazue.Infrastructure.Parameters.Barber;
using Kazue.Infrastructure.Queries.Barber;
using System.Data;

namespace Kazue.Infrastructure.Repository.Barber;

public class BarberRepository : IBarberRepository
{
    private readonly IBarberParameter _barberParameter;
    private readonly IKazueConnection _connection;

    public BarberRepository(IBarberParameter barberParameter, IKazueConnection connection)
    {
        _barberParameter = barberParameter;
        _connection = connection;
    }

    public async Task<BarberEntity> Create(CreateBarberRequest req)
    {
        using var connection = _connection.GetConnection();

        var parameters = _barberParameter.CreateParameters(req);

        var id = await connection.QueryFirstOrDefaultAsync<int>(
            sql: BarberQuery.SP_CREATE_BARBER,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }

    public async Task<BarberEntity?> GetById(long id)
    {
        using var connection = _connection.GetConnection();

        var parameters = _barberParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<BarberEntity>(
            sql: BarberQuery.SP_GET_BARBER_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
}
