using FluentValidation.Results;
using Kazue.Application.Adapter.Category;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Category;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Category.Update;

public class UpdateCategoryUseCase(
    IUpdateCategoryRepository updateCategoryRepository,
    IReadCategoryRepository readCategoryRepository) 
    : IUpdateCategoryUseCase
{
    private readonly IUpdateCategoryRepository _updateCategoryRepository = updateCategoryRepository;
    private readonly IReadCategoryRepository _readCategoryRepository = readCategoryRepository;

    public async Task<CategoryResponse> ExecuteAsync(Guid id, CategoryRequest req)
    {
        await Validate(id, req);

        await _updateCategoryRepository.UpdateAsync(id, req);

        var response = await _readCategoryRepository.GetById(id);

        return CategoryAdapter.FromEntityToResponse(response);
    }

    private async Task Validate(Guid id, CategoryRequest req)
    {
        var result = new CategoryValidator().Validate(req);

        var repositoryResponse = await _readCategoryRepository.GetById(id) ?? 
                                 throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        var entity = await _readCategoryRepository.GetByCodeOrDescription(req);

        if (entity is not null && entity.ID_CATEGORY != id)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ErrorMessageResource.CODE_DESCRIPTION_EXCEPTION));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
