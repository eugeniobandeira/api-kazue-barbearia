﻿using Dapper;
using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Request.User;
using Kazue.Infrastructure.Parameters.User;
using Kazue.Infrastructure.Queries.User;
using System.Data;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Response.Shared;

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


    public async Task<UserEntity?> GetByEmail(string email)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.GetByEmailParameters(email);

        return (await connection.QueryAsync<UserEntity>(
            sql: UserQuery.USER_SP_GET_BY_EMAIL,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
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

    public async Task<List<UserEntity>> GetAll(GetUserRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _userParameter.GetAllParameters(req);

        return (await connection.QueryAsync<UserEntity>(
            sql: UserQuery.USER_SP_GET,
            param: parameters,
            commandType: CommandType.StoredProcedure)).ToList();
    }
}
