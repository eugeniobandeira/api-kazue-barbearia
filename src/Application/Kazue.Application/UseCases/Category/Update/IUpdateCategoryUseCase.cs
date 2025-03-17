using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Category;

namespace Kazue.Application.UseCases.Category.Update;

public interface IUpdateCategoryUseCase
{
    Task<CategoryResponse> ExecuteAsync(long id, CategoryRequest req);
}
