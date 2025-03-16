using Kazue.Domain.Response.Category;

namespace Kazue.Application.UseCases.Category.GetById;

public interface IGetCategoryByIdUseCase
{
    Task<CategoryResponse?> ExecuteAsync(Guid id);
}
