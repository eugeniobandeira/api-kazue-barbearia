using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Queue.Delete;

public class DeleteQueueUseCase : IDeleteQueueUseCase
{
    private readonly IDeleteQueueRepository _deleteQueueRepository;
    private readonly IReadQueueRepository _readQueueRepository;

    public DeleteQueueUseCase(
        IDeleteQueueRepository deleteQueueRepository,
        IReadQueueRepository readQueueRepository)
    {
        _deleteQueueRepository = deleteQueueRepository;
        _readQueueRepository = readQueueRepository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        var entity = await _readQueueRepository.GetById(id);

        if (entity is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        await _deleteQueueRepository.DeleteAsync(entity);
    }
}
