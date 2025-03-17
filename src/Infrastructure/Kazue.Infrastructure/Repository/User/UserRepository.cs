using Dapper;
using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Request.User;
using Kazue.Infrastructure.Parameters.User;
using Kazue.Infrastructure.Queries.User;
using System.Data;

namespace Kazue.Infrastructure.Repository.User;

public class UserRepository(
    IUserParameter userParameter, 
    IKazueConnection connection) : 

    ICreateUserRepository,
    IReadUserRepository,
    IUpdateUserRepository,
    IDeleteUserRepository
{
    private readonly IUserParameter _userParameter = userParameter;
    private readonly IKazueConnection _connection = connection;

    public async Task<UserEntity> Create(CreateUserRequest req)
    {
        await using var connection = _connection.GetConnection();

        var id = Guid.NewGuid();

        var parameters = _userParameter.CreateParameters(req, id);

        await connection.ExecuteAsync(
            sql: UserQuery.USER_SP_CREATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }


    public async Task<UserEntity?> GetByEmail(string email)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.GetByEmailParameters(email);

        return (await connection.QueryAsync<UserEntity>(
            sql: UserQuery.USER_SP_GET_BY_EMAIL,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<UserEntity?> GetById(Guid id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<UserEntity>(
            sql: UserQuery.USER_SP_GET_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.DeleteParameters(id);

        await connection.ExecuteAsync(
            sql: UserQuery.USER_SP_DELETE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<List<UserEntity>> GetAll(GetUserRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.GetAllParameters(req);

        return [.. (await connection.QueryAsync<UserEntity>(
            sql: UserQuery.USER_SP_GET,
            param: parameters,
            commandType: CommandType.StoredProcedure))];
    }

    public async Task UpdateAsync(Guid id, UpdateUserRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.UpdateParameters(id, req);

        await connection.ExecuteAsync(
            sql: UserQuery.USER_SP_UPDATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task ChangePasswordAsync(Guid id, ChangePasswordRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.ChangePasswordParameters(id, req);

        await connection.ExecuteAsync(
            sql: UserQuery.USER_SP_UPDATE_PASSWORD,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}
