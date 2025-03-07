using FluentValidation;
using Kazue.Domain.Request.User;

namespace Kazue.Application.UseCases.User.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordValidator()
    {
        RuleFor(pass => pass.NewPassword)
            .SetValidator(new PasswordValidator<ChangePasswordRequest>());
    }
}
