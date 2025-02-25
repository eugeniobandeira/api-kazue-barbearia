using Kazue.Domain.Request.Barber;
using Kazue.Domain.Response.Person;

namespace Kazue.Application.UseCases.Barber.GetById;

public interface IGetBarberByIdUseCase
{
    Task<RegisteredPersonResponse> ExecuteAsync(long id);
}
