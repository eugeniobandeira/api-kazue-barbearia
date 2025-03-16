using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Category.Delete;

public class DeleteCategoryUseCase(
    IReadCategoryRepository readCategoryRepository,
    IDeleteCategoryRepository deleteCategoryRepository) 
    : IDeleteCategoryUseCase
{
    private readonly IReadCategoryRepository _readCategoryRepository = readCategoryRepository;
    private readonly IDeleteCategoryRepository _deleteCategoryRepository = deleteCategoryRepository;

    public async Task ExecuteAsync(Guid id)
    {
        var entity = await _readCategoryRepository.GetById(id) ?? 
                     throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        await _deleteCategoryRepository.DeleteAsync(entity.ID_CATEGORY);
    }
}
