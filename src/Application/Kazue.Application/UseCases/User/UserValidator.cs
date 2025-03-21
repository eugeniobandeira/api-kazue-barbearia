using FluentValidation;
using Kazue.Domain.Request.User;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.User;

public class UserValidator : AbstractValidator<CreateUserRequest>
{
    public UserValidator()
    {
        RuleFor(user => user.Fullname)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_NAME);

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_EMAIL)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ErrorMessageResource.INVALID_EMAIL);

        RuleFor(user => user.Password)
            .SetValidator(new PasswordValidator<CreateUserRequest>());
    }
}
