using FluentValidation.Results;
using Kazue.Application.Adapter.Status;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Status;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Status.Update;

public class UpdateStatusUseCase : IUpdateStatusUseCase
{
    private readonly IUpdateStatusRepository _updateStatusRepository;
    private readonly IReadStatusRepository _readStatusRepository;

    public UpdateStatusUseCase(
        IUpdateStatusRepository updateStatusRepository,
        IReadStatusRepository readStatusRepository)
    {
        _updateStatusRepository = updateStatusRepository;
        _readStatusRepository = readStatusRepository;
    }

    public async Task<StatusResponse> ExecuteAsync(Guid id, StatusRequest req)
    {
        await Validate(id, req);

        await _updateStatusRepository.Update(id, req);

        var response = await _readStatusRepository.GetById(id);

        return StatusAdapter.FromEntityToResponse(response);
    }

    private async Task Validate(Guid id, StatusRequest req)
    {
        var result = new StatusValidator().Validate(req);

        var repositoryResponse = await _readStatusRepository.GetById(id);

        if (repositoryResponse is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        var entity = await _readStatusRepository.GetByCodeOrDescription(req);

        if (entity is not null && entity.ID_STATUS != id)
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
