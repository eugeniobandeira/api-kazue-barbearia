using Kazue.Domain.Entities.Queue;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Response.Queue;
using Kazue.Domain.Response.Service;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.User;

namespace Kazue.Application.Adapter.Queue;

public static class QueueAdapter
{
    public static QueueResponse FromEntityToResponse(QueueEntity entity, List<ServiceEntity> services)
    {
        if (entity is null)
            throw new ArgumentNullException("Cannot adapt a null entity to response", nameof(entity));

        var response = new QueueResponse();

        response.Id = entity.ID_QUEUE;
        response.DtCheckinAt = entity.DT_CHECKIN_AT;
        response.DtCheckoutAt = entity.DT_CHECKOUT_AT;
        response.Amount = entity.VL_AMOUNT;

        response.Barber = new ShortUserResponse
        {
            Name = entity.DS_BARBER_NAME,
            Surname = entity.DS_BARBER_SURNAME,
            NickName = entity.DS_BARBER_NICKNAME
        };

        response.Customer = new ShortUserResponse
        {
            Name = entity.DS_CUSTOMER_NAME,
            Surname = entity.DS_CUSTOMER_SURNAME,
            NickName = entity.DS_CUSTOMER_NICKNAME
        };

        response.Status = new ItemResponse
        {
            Id = entity.ID_STATUS,
            Code = entity.CD_STATUS,
            Description = entity.DS_STATUS
        };

        foreach (var service in services)
        {
            var srv = new ServiceResponse
            {
                Id = service.ID_SERVICE,
                Code = service.CD_SERVICE,
                Description = service.DS_SERVICE,
                Price = service.VL_PRICE
            };

            response.Services.Add(srv);
        }

        return response;
    }

    public static IList<QueueResponse> FromEntityListToEntityResponse(IEnumerable<QueueEntity>? entityList, IEnumerable<ServiceEntity>? services)
    {
        if (entityList is null)
            throw new ArgumentNullException("Cannot adapt a null entity to response", nameof(entityList));

        List<QueueResponse> response = new();

        foreach (var entity in entityList)
        {
            response.Add(new QueueResponse
            {
                Id = entity.ID_QUEUE,
                DtCheckinAt = entity.DT_CHECKIN_AT,
                DtCheckoutAt = entity.DT_CHECKOUT_AT,
                Amount = entity.VL_AMOUNT,

                Barber = new ShortUserResponse
                {
                    Name = entity.DS_BARBER_NAME,
                    Surname = entity.DS_BARBER_SURNAME,
                    NickName = entity.DS_BARBER_NICKNAME
                },

                Customer = new ShortUserResponse
                {
                    Name = entity.DS_CUSTOMER_NAME,
                    Surname = entity.DS_CUSTOMER_SURNAME,
                    NickName = entity.DS_CUSTOMER_NICKNAME
                },

                Status = new ItemResponse
                {
                    Id = entity.ID_STATUS,
                    Code = entity.CD_STATUS,
                    Description = entity.DS_STATUS
                },


                Services = new List<ServiceResponse>() 
                {
                }
            });
        }

        return response;
    }
}
