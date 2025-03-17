using Kazue.Application.Adapter.Queue;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Queue;
using Kazue.Domain.Response.Shared;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Queue.Get;

public class GetQueueUseCase(
    IReadQueueRepository readQueueRepository,
    IReadServiceRepository readServiceRepository) 
    : IGetQueueUseCase
{
    private readonly IReadQueueRepository _readQueueRepository = readQueueRepository;
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task<ListApiResponse<QueueResponse>> ExecuteAsync(GetQueueRequest req)
    {
        ListApiResponse<QueueResponse> apiResponse = new();

        var listApiResponse = await _readQueueRepository.GetAll(req);

        if (listApiResponse.Count != 0)
        {
            foreach (var entity in listApiResponse)
            {
                var servicesList = await GetServicesList(entity.IDS_SERVICES.Split());

                var queue = QueueAdapter.FromEntityToResponse(entity, servicesList);
                apiResponse.Response.Add(queue);
            }
        }

        apiResponse.ResultCount = listApiResponse.Count;

        return apiResponse;
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
