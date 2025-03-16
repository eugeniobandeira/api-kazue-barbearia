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
            foreach (var response in listApiResponse)
            {
                var status = CategoryAdapter.FromEntityToResponse(response);
                apiResponse.Response.Add(status);
            }
        }

        apiResponse.ResultCount = listApiResponse.Count;

        return apiResponse;
    }
}
