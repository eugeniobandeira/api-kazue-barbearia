using Kazue.Application.Adapter.Barber;
using Kazue.Domain.Response.Person;
using Kazue.Infrastructure.Repository.Barber;

namespace Kazue.Application.UseCases.Barber.GetById;

public class GetBarberByIdUseCase : IGetBarberByIdUseCase
{
    private readonly IBarberRepository _barberRepository;

    public GetBarberByIdUseCase(IBarberRepository barberRepository)
    {
        _barberRepository = barberRepository;
    }

    public async Task<RegisteredPersonResponse> ExecuteAsync(long id)
    {
        var repositoryResponse = await _barberRepository.GetById(id);

        var response = BarberAdapter.FromEntityToResponse(repositoryResponse);

        return response;
    }
}
