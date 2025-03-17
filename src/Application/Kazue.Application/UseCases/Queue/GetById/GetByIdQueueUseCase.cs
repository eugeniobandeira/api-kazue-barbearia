using Kazue.Application.Adapter.Queue;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Response.Queue;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Queue.GetById;

public class GetByIdQueueUseCase(
    IReadQueueRepository readQueueRepository,
    IReadServiceRepository readServiceRepository) 
    : IGetByIdQueueUseCase
{
    private readonly IReadQueueRepository _readQueueRepository = readQueueRepository;
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task<QueueResponse> ExecuteAsync(long id)
    {
        var repositoryResponse = await _readQueueRepository.GetById(id) ?? 
                                 throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);
        var serviceList = new List<ServiceEntity>();

        return QueueAdapter.FromEntityToResponse(repositoryResponse, serviceList);
    }
}
