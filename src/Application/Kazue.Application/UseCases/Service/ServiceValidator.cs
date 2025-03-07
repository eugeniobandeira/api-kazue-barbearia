using FluentValidation;
using Kazue.Domain.Request.Service;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Service;

public class ServiceValidator : AbstractValidator<ServiceRequest>
{
    public ServiceValidator()
    {
        RuleFor(service => service.Code)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_CODE);
        
        RuleFor(service => service.Description)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_DESCRIPTION);

        RuleFor(service => service.Price)
            .GreaterThan(0)
            .WithMessage(ErrorMessageResource.PRICE_NOT_GREATER_THAN_ZERO);
    }
}
