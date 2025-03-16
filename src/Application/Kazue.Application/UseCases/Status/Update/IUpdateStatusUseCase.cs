using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.UseCases.Status.Update;

public interface IUpdateStatusUseCase
{
    Task<StatusResponse> ExecuteAsync(Guid id, StatusRequest req);
}
