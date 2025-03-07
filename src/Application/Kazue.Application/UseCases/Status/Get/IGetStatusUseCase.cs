using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.UseCases.Status.Get;

public interface IGetStatusUseCase
{
    Task<ListApiResponse<StatusResponse>> ExecuteAsync(GetStatusRequest req);
}
