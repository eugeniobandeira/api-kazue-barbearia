using FluentValidation;
using Kazue.Domain.Request.User;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.User.Update;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.Fullname).NotEmpty().WithMessage(ErrorMessageResource.EMPTY_NAME);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_EMAIL)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ErrorMessageResource.INVALID_EMAIL);
    }
}
