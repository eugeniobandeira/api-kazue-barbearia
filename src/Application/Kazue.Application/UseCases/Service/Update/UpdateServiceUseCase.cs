using FluentValidation.Results;
using Kazue.Application.Adapter.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Service;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Service.Update;

public class UpdateServiceUseCase(
    IReadServiceRepository readServiceRepository,
    IUpdateServiceRepository updateServiceRepository) 
    : IUpdateServiceUseCase
{
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;
    private readonly IUpdateServiceRepository _updateServiceRepository = updateServiceRepository;

    public async Task<ServiceResponse> ExecuteAsync(long id, ServiceRequest req)
    {
        await Validate(id, req);

        await _updateServiceRepository.UpdateAsync(id, req);

        var response = await _readServiceRepository.GetById(id);

        return ServiceAdapter.FromEntityToResponse(response);
    }

    private async Task Validate(long id, ServiceRequest req)
    {
        var result = new ServiceValidator().Validate(req);

        var repositoryResponse = await _readServiceRepository.GetById(id) ?? 
                                 throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        var entity = await _readServiceRepository.GetByCodeOrDescription(req);

        if (entity is not null && entity.ID_SERVICE != id)
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
