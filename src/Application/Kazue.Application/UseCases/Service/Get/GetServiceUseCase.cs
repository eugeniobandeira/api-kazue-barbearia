using Kazue.Application.Adapter.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Service;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.Service.Get;

public class GetServiceUseCase(IReadServiceRepository readServiceRepository) 
    : IGetServiceUseCase
{
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task<ListApiResponse<ServiceResponse>> ExecuteAsync(GetServiceRequest req)
    {
        ListApiResponse<ServiceResponse> apiResponse = new();

        var listApiResponse = await _readServiceRepository.GetAll(req);

        if (listApiResponse.Count != 0)
        {
            foreach (var service in listApiResponse)
            {
                var srv = ServiceAdapter.FromEntityToResponse(service);
                apiResponse.Response.Add(srv);
            }
        }

        apiResponse.ResultCount = listApiResponse.First().QT_RECORDS;
        apiResponse.RowsCount = listApiResponse.First().QT_ROWS;

        return apiResponse;
    }
}
