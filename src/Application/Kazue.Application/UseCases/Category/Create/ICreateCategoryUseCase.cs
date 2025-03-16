using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Category;

namespace Kazue.Application.UseCases.Category.Create;

public interface ICreateCategoryUseCase
{
    Task<CategoryResponse> ExecuteAsync(CategoryRequest req);
}
