using FluentValidation;
using Kazue.Domain.Request.Status;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Status;

public class StatusValidator : AbstractValidator<StatusRequest>
{
    public StatusValidator()
    {
        RuleFor(status => status.Code)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_CODE);
        
        RuleFor(status => status.Description)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_DESCRIPTION);
    }
}
