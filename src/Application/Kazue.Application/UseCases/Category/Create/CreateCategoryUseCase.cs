using FluentValidation.Results;
using Kazue.Application.Adapter.Category;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Category;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Category.Create;

public class CreateCategoryUseCase(
    ICreateCategoryRepository createCategoryRepository,
    IReadCategoryRepository readCategoryRepository) : ICreateCategoryUseCase
{
    private readonly ICreateCategoryRepository _createCategoryRepository = createCategoryRepository;
    private readonly IReadCategoryRepository _readCategoryRepository = readCategoryRepository;

    public async Task<CategoryResponse> ExecuteAsync(CategoryRequest req)
    {
        await Validate(req);

        var repositoryResponse = await _createCategoryRepository.CreateAsync(req);

        return CategoryAdapter.FromEntityToResponse(repositoryResponse);
    }

    private async Task Validate(CategoryRequest req)
    {
        var result = new CategoryValidator().Validate(req);

        var entity = await _readCategoryRepository.GetByCodeOrDescription(req);

        if (entity is not null)
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
