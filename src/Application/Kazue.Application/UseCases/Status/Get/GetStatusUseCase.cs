using Kazue.Application.Adapter.Status;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.UseCases.Status.Get;

public class GetStatusUseCase : IGetStatusUseCase
{
    private readonly IReadStatusRepository _readStatusRepository;

    public GetStatusUseCase(IReadStatusRepository readStatusRepository)
    {
        _readStatusRepository = readStatusRepository;
    }

    public async Task<ListApiResponse<StatusResponse>> ExecuteAsync(GetStatusRequest req)
    {
        ListApiResponse<StatusResponse> apiResponse = new();

        var listApiResponse = await _readStatusRepository.GetAll(req);

        if (listApiResponse.Count != 0)
        {
            foreach (var response in listApiResponse)
            {
                var status = StatusAdapter.FromEntityToResponse(response);
                apiResponse.Response.Add(status);
            }
        }

        apiResponse.ResultCount = listApiResponse.First().QT_RECORDS;
        apiResponse.RowsCount = listApiResponse.First().QT_ROWS;

        return apiResponse;
    }
}
