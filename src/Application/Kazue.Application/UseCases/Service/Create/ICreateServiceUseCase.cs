using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Service;

namespace Kazue.Application.UseCases.Service.Create;

public interface ICreateServiceUseCase
{
    Task<ServiceResponse> ExecuteAsync(ServiceRequest req);
}
