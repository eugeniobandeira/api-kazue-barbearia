using FluentValidation.Results;
using Kazue.Application.Adapter.Queue;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Request.Queue;
using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Queue;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.Queue.Create;

public class CreateQueueUseCase : ICreateQueueUseCase
{
    private readonly ICreateQueueRepository _createQueueRepository;
    private readonly IReadQueueRepository _readQueueRepository;
    private readonly IReadServiceRepository _readServiceRepository;

    public CreateQueueUseCase(
        ICreateQueueRepository createQueueRepository,
        IReadQueueRepository readQueueRepository,
        IReadServiceRepository readServiceRepository)
    {
        _createQueueRepository = createQueueRepository;
        _readQueueRepository = readQueueRepository;
        _readServiceRepository = readServiceRepository;
    }

    public async Task<QueueResponse> ExecuteAsync(QueueRequest req)
    {
        await Validate(req);

        // criar logica para o total do serviço

        var repositoryResponse = await _createQueueRepository.CreateAsync(req);

        var servicesCode = repositoryResponse.IDS_SERVICES.Split(',');

        var servicesList = new List<ServiceEntity>();

        var request = new ServiceRequest();

        foreach (var service in servicesCode)
        {
            request.Code = service;

            var srv = await _readServiceRepository.GetByCodeOrDescription(request);

            if (srv is null)
                throw new NotFoundException(ErrorMessageResource.NOT_FOUND_EXCEPTION);

            servicesList.Add(srv);
        }

        return QueueAdapter.FromEntityToResponse(repositoryResponse, servicesList);
    }

    private async Task Validate(QueueRequest req)
    {
        var result = new QueueValidator().Validate(req);

        var entity = await _readQueueRepository.GetByIdUser(req.IdCustomer);

        if (entity is not null)
        {
            var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            var dateOfBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasiliaTimeZone);
            var dateOfCheckin = TimeZoneInfo.ConvertTimeFromUtc(entity.DT_CHECKIN_AT, brasiliaTimeZone);

            if (dateOfBrasilia.Date.Day == dateOfCheckin.Date.Day && entity.DT_CHECKOUT_AT is null)
                result.Errors.Add(new ValidationFailure(string.Empty, ErrorMessageResource.CUSTOMER_ALREADY_WAITING));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
