using Kazue.Domain.Response.Status;

namespace Kazue.Application.UseCases.Status.GetById;

public interface IGetStatusByIdUseCase
{
    Task<StatusResponse> ExecuteAsync(long id);
}
