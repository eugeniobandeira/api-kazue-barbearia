using FluentValidation;
using Kazue.Domain.Request.Queue;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Queue;

public class QueueValidator : AbstractValidator<QueueRequest>
{
    public QueueValidator()
    {
        RuleFor(queue => queue.IdCustomer)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_CUSTOMER);
        
        RuleFor(queue => queue.IdServices)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_SERVICE);
    }
}
