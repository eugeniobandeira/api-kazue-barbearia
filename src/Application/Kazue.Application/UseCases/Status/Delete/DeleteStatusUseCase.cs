using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Status.Delete;

public class DeleteStatusUseCase : IDeleteStatusUseCase
{
    private readonly IDeleteStatusRepository _deleteStatusRepository;
    private readonly IReadStatusRepository _readStatusRepository;

    public DeleteStatusUseCase(
        IDeleteStatusRepository deleteStatusRepository,
        IReadStatusRepository readStatusRepository)
    {
        _deleteStatusRepository = deleteStatusRepository;
        _readStatusRepository = readStatusRepository;
    }

    public async Task ExecuteAsync(long id)
    {
        var entity = await _readStatusRepository.GetById(id);

        if (entity is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        await _deleteStatusRepository.DeleteAsync(entity);
    }
}
