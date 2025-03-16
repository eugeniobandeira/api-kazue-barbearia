using Kazue.Application.Adapter.Category;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Domain.Response.Category;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Category.GetById;

public class GetCategoryByIdUseCase(IReadCategoryRepository readCategoryRepository) 
    : IGetCategoryByIdUseCase
{
    private readonly IReadCategoryRepository _readCategoryRepository = readCategoryRepository;

    public async Task<CategoryResponse?> ExecuteAsync(Guid id)
    {
        var repositoryResponse = await _readCategoryRepository.GetById(id) ?? 
                                 throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        return CategoryAdapter.FromEntityToResponse(repositoryResponse);
    }
}
