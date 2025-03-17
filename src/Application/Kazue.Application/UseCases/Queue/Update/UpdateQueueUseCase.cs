using Kazue.Application.Adapter.Queue;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Queue;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Queue.Update;

public class UpdateQueueUseCase(
    IUpdateQueueRepository updateQueueRepository,
    IReadQueueRepository readQueueRepository,
    IReadServiceRepository readServiceRepository) 
    : IUpdateQueueUseCase
{
    private readonly IUpdateQueueRepository _updateQueueRepository = updateQueueRepository;
    private readonly IReadQueueRepository _readQueueRepository = readQueueRepository;
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task<QueueResponse> ExecuteAsync(long id, QueueRequest req)
    {
        await Validate(id, req);

        await _updateQueueRepository.UpdateAsync(id, req);

        var queueEntity = await _readQueueRepository.GetById(id);

        var servicesList = await GetServicesList(queueEntity.IDS_SERVICES.Split());

        return QueueAdapter.FromEntityToResponse(queueEntity, servicesList);
    }

    private async Task Validate(long id, QueueRequest req)
    {
        var result = new QueueValidator().Validate(req);

        var entity = await _readQueueRepository.GetById(id) ?? 
                     throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    private async Task<IList<ServiceEntity>> GetServicesList(string[] idServiceList)
    {
        IList<ServiceEntity>? servicesList = [];

        foreach (var idService in idServiceList)
        {
            var repositoryResponse = await _readServiceRepository.GetById(long.Parse(idService));

            if (repositoryResponse is not null)
            {
                servicesList.Add(repositoryResponse);
            }
            else
            {
                throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);
            }
        }

        return servicesList;
    }
}
