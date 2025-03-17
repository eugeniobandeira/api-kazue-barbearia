using Kazue.Application.Adapter.Status;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Response.Status;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Status.GetById;

public class GetStatusByIdUseCase(IReadStatusRepository readStatusRepository) 
    : IGetStatusByIdUseCase
{
    private readonly IReadStatusRepository _readStatusRepository = readStatusRepository;

    public async Task<StatusResponse> ExecuteAsync(long id)
    {
        var repositoryResponse = await _readStatusRepository.GetById(id);

        if (repositoryResponse is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        return StatusAdapter.FromEntityToResponse(repositoryResponse);
    }
}
