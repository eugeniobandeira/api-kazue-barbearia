using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.UseCases.Status.Update;

public interface IUpdateStatusUseCase
{
    Task<StatusResponse> ExecuteAsync(long id, StatusRequest req);
}
