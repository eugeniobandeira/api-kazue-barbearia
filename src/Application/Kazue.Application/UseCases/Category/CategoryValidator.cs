using FluentValidation;
using Kazue.Domain.Request.Category;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Category;

public class CategoryValidator : AbstractValidator<CategoryRequest>
{
    public CategoryValidator()
    {
        RuleFor(service => service.Code)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_CODE);

        RuleFor(service => service.Description)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_DESCRIPTION);
    }
}
