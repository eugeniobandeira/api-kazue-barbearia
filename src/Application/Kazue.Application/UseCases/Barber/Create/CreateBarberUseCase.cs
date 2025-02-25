using Kazue.Application.Adapter.Barber;
using Kazue.Domain.Request.Barber;
using Kazue.Domain.Response.Person;
using Kazue.Infrastructure.Repository.Barber;

namespace Kazue.Application.UseCases.Barber.Create;

public class CreateBarberUseCase : ICreateBarberUseCase
{
    private readonly IBarberRepository _barberRepository;

    public CreateBarberUseCase(IBarberRepository barberRepository)
    {
        _barberRepository = barberRepository;
    }

    public async Task<RegisteredPersonResponse> ExecuteAsync(CreateBarberRequest req)
    {
        var repositoryResponse = await _barberRepository.Create(req);

        var response = BarberAdapter.FromEntityToResponse(repositoryResponse);

        return response;
    }
}
