using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Service;

namespace Kazue.Application.UseCases.Service.Update;

public interface IUpdateServiceUseCase
{
    Task<ServiceResponse> ExecuteAsync(long id, ServiceRequest req);
}
