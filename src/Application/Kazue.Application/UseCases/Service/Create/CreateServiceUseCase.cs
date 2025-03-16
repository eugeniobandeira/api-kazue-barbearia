using FluentValidation.Results;
using Kazue.Application.Adapter.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Service;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Service.Create;

public class CreateServiceUseCase(
    ICreateServiceRepository createServiceRepository,
    IReadServiceRepository readServiceRepository) 
    : ICreateServiceUseCase
{
    private readonly ICreateServiceRepository _createServiceRepository = createServiceRepository;
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task<ServiceResponse> ExecuteAsync(ServiceRequest req)
    {
        await Validate(req);

        var repositoryResponse = await _createServiceRepository.Create(req);

        return ServiceAdapter.FromEntityToResponse(repositoryResponse);
    }

    private async Task Validate(ServiceRequest req)
    {
        var result = new ServiceValidator().Validate(req);

        var entity = await _readServiceRepository.GetByCodeOrDescription(req);

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
