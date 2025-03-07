using Kazue.Domain.Response.Service;

namespace Kazue.Application.UseCases.Service.GetById;

public interface IGetServiceByIdUseCase
{
    Task<ServiceResponse> ExecuteAsync(long id);
}
