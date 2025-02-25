using Kazue.Domain.Request.Barber;
using Kazue.Domain.Response.Person;

namespace Kazue.Application.UseCases.Barber.Create;
public interface ICreateBarberUseCase
{
    Task<RegisteredPersonResponse> ExecuteAsync(CreateBarberRequest req);
}
