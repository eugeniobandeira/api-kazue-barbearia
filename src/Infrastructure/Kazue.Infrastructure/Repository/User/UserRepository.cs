using Dapper;
using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Request.User;
using Kazue.Infrastructure.Parameters.User;
using Kazue.Infrastructure.Queries.User;
using System.Data;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;

namespace Kazue.Infrastructure.Repository.User;

public class UserRepository : 
    ICreateUserRepository,
    IReadUserRepository,
    IUpdateUserRepository,
    IDeleteUserRepository
{
    private readonly IUserParameter _userParameter;
    private readonly IKazueConnection _connection;

    public UserRepository(IUserParameter userParameter, IKazueConnection connection)
    {
        _userParameter = userParameter;
        _connection = connection;
    }

    public async Task<UserEntity> Create(CreateUserRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.CreateParameters(req);

        var id = await connection.QueryFirstOrDefaultAsync<int>(
            sql: UserQuery.USER_SP_CREATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }

    public Task<bool> ExistUserWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity?> GetById(long id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<UserEntity>(
            sql: UserQuery.USER_SP_GET_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public void Update(UserEntity req)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserEntity userEntity)
    {
        throw new NotImplementedException();
    }
}
