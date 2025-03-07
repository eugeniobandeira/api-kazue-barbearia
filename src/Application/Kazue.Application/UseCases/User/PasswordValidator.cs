using FluentValidation;
using FluentValidation.Validators;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.User;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.INVALID_PASSWORD_NULL_OR_WHITE_SPACE);
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.INVALID_PASSWORD_LENGTH);
            return false;
        }

        return true;
    }
}
