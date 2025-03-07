using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.UseCases.Status.Create;

public interface ICreateStatusUseCase
{
    Task<StatusResponse> ExecuteAsync(StatusRequest req);
}
