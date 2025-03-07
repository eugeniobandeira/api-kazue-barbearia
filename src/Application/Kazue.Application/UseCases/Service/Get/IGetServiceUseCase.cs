using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Service;
using Kazue.Domain.Response.Shared;

namespace Kazue.Application.UseCases.Service.Get;

public interface IGetServiceUseCase
{
    Task<ListApiResponse<ServiceResponse>> ExecuteAsync(GetServiceRequest req);
}
