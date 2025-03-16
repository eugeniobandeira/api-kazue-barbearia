using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Category;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.Category.Get;

public interface IGetCategoryUseCase
{
    Task<ListApiResponse<CategoryResponse>> ExecuteAsync(GetCategoryRequest req);
}
