using Dapper;
using Kazue.Domain.Entities.Category;
using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Domain.Request.Category;
using Kazue.Infrastructure.Parameters.Category;
using Kazue.Infrastructure.Queries.Category;
using System.Data;

namespace Kazue.Infrastructure.Repository.Category;

public class CategoryRepository(
    ICategoryParameter categoryParameter,
    IKazueConnection kazueConnection) :

    ICreateCategoryRepository,
    IDeleteCategoryRepository,
    IUpdateCategoryRepository,
    IReadCategoryRepository
{
    private readonly ICategoryParameter _categoryParameter = categoryParameter;
    private readonly IKazueConnection _connection = kazueConnection;

    public async Task<CategoryEntity> CreateAsync(CategoryRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _categoryParameter.CreateParameters(req);

        var id = await connection.QueryFirstOrDefaultAsync<int>(
            sql: CategoryQuery.CATEGORY_SP_CREATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );

        return await GetById(id);
    }

    public async Task DeleteAsync(long id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _categoryParameter.DeleteParameters(id);

        await connection.ExecuteAsync(
            sql: CategoryQuery.CATEGORY_SP_DELETE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task UpdateAsync(long id, CategoryRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _categoryParameter.UpdateParameters(id, req);

        await connection.ExecuteAsync(
            sql: CategoryQuery.CATEGORY_SP_UPDATE,
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<CategoryEntity?> GetById(long id)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _categoryParameter.GetByIdParameters(id);

        return (await connection.QueryAsync<CategoryEntity>(
            sql: CategoryQuery.CATEGORY_SP_GET_BY_ID,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<CategoryEntity?> GetByCodeOrDescription(CategoryRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _categoryParameter.GetByCodeOrDescriptionParameters(req);

        return (await connection.QueryAsync<CategoryEntity>(
            sql: CategoryQuery.CATEGORY_SP_GET_BY_CODE_OR_DESCRIPTION,
            param: parameters,
            commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<List<CategoryEntity>> GetAll(GetCategoryRequest req)
    {
        await using var connection = _connection.GetConnection();

        var parameters = _categoryParameter.GetAllParameters(req);

        return [.. (await connection.QueryAsync<CategoryEntity>(
            sql: CategoryQuery.CATEGORY_SP_GET,
            param: parameters,
            commandType: CommandType.StoredProcedure))];
    }
}
