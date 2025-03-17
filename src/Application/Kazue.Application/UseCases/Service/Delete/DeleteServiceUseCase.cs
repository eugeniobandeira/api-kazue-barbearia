using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Service.Delete;

public class DeleteServiceUseCase(
    IDeleteServiceRepository deleteServiceRepository,
    IReadServiceRepository readServiceRepository) 
    : IDeleteServiceUseCase
{
    private readonly IDeleteServiceRepository _deleteServiceRepository = deleteServiceRepository;
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task ExecuteAsync(long id)
    {
        var entity = await _readServiceRepository.GetById(id) ?? 
                     throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        await _deleteServiceRepository.DeleteAsync(entity);
    }
}
