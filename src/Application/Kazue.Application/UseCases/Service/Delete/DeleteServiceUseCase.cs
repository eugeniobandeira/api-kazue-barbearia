using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Service.Delete;

public class DeleteServiceUseCase : IDeleteServiceUseCase
{
    private readonly IDeleteServiceRepository _deleteServiceRepository;
    private readonly IReadServiceRepository _readServiceRepository;

    public DeleteServiceUseCase(
        IDeleteServiceRepository deleteServiceRepository,
        IReadServiceRepository readServiceRepository)
    {
        _deleteServiceRepository = deleteServiceRepository;
        _readServiceRepository = readServiceRepository;
    }
    public async Task ExecuteAsync(long id)
    {
        var entity = await _readServiceRepository.GetById(id);

        if (entity is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        await _deleteServiceRepository.DeleteAsync(entity);
    }
}
