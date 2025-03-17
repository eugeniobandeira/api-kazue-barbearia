using Kazue.Application.Adapter.Category;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Category;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.Category.Get;

public class GetCategoryUseCase(IReadCategoryRepository readCategoryRepository) 
    : IGetCategoryUseCase
{
    private readonly IReadCategoryRepository _readCategoryRepository = readCategoryRepository;

    public async Task<ListApiResponse<CategoryResponse>> ExecuteAsync(GetCategoryRequest req)
    {
        ListApiResponse<CategoryResponse> apiResponse = new();

        var listApiResponse = await _readCategoryRepository.GetAll(req);

        if (listApiResponse.Count != 0)
        {
            foreach (var entity in listApiResponse)
            {
                var categoryResponse = CategoryAdapter.FromEntityToResponse(entity);
                apiResponse.Response.Add(categoryResponse);
            }
        }

        apiResponse.ResultCount = listApiResponse.First().QT_RECORDS;
        apiResponse.RowsCount = listApiResponse.First().QT_ROWS;

        return apiResponse;
    }
}
