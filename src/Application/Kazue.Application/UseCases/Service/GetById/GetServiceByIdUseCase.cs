using Kazue.Application.Adapter.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Response.Service;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Service.GetById;

public class GetServiceByIdUseCase(IReadServiceRepository readServiceRepository) 
    : IGetServiceByIdUseCase
{
    private readonly IReadServiceRepository _readServiceRepository = readServiceRepository;

    public async Task<ServiceResponse> ExecuteAsync(Guid id)
    {
        var repositoryResponse = await _readServiceRepository.GetById(id) ?? 
                                 throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

        return ServiceAdapter.FromEntityToResponse(repositoryResponse);
    }
}
