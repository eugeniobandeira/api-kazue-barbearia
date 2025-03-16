using FluentValidation.Results;
using Kazue.Application.Adapter.Status;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Status;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Status.Create;

public class CreateStatusUseCase(
    ICreateStatusRepository createStatusRepository,
    IReadStatusRepository readStatusRepository) 
    : ICreateStatusUseCase
{
    private readonly ICreateStatusRepository _createStatusRepository = createStatusRepository;
    private readonly IReadStatusRepository _readStatusRepository = readStatusRepository;

    public async Task<StatusResponse> ExecuteAsync(StatusRequest req)
    {
        await Validate(req);

        var repository = await _createStatusRepository.Create(req);

        return StatusAdapter.FromEntityToResponse(repository);
    }

    private async Task Validate(StatusRequest req)
    {
        var result = new StatusValidator().Validate(req);

        var entity = await _readStatusRepository.GetByCodeOrDescription(req);
        
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
