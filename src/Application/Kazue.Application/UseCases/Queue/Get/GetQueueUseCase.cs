using Kazue.Application.Adapter.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Queue;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.Queue.Get;

public class GetQueueUseCase : IGetQueueUseCase
{
    private readonly IReadQueueRepository _readQueueRepository;

    public GetQueueUseCase(IReadQueueRepository readQueueRepository)
    {
        _readQueueRepository = readQueueRepository;
    }

    public async Task<ListApiResponse<QueueResponse>> ExecuteAsync(GetQueueRequest req)
    {
        ListApiResponse<QueueResponse> apiResponse = new();

        var listApiResponse = await _readQueueRepository.GetAll(req);

        if (listApiResponse.Count != 0)
        {
            //foreach (var response in listApiResponse)
            //{
            //    var queue = QueueAdapter.FromEntityToResponse(response);
            //    apiResponse.Response.Add(queue);
            //}
        }

        apiResponse.ResultCount = listApiResponse.Count();
        //apiResponse.RowsCount = listApiResponse.First().QT_REGISTRY;

        return apiResponse;
    }
}
