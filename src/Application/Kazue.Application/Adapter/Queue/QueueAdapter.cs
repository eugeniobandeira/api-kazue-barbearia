using Kazue.Domain.Entities.Queue;
using Kazue.Domain.Entities.Service;
using Kazue.Domain.Response.Queue;
using Kazue.Domain.Response.Service;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.User;

namespace Kazue.Application.Adapter.Queue;

public static class QueueAdapter
{
    public static QueueResponse FromEntityToResponse(QueueEntity entity, IList<ServiceEntity> services)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), "Cannot adapt a null entity to response");

        var response = new QueueResponse();

        response.Id = entity.ID_QUEUE;
        response.DtCheckinAt = entity.DT_CHECKIN_AT;
        response.DtCheckoutAt = entity.DT_CHECKOUT_AT;
        response.Amount = entity.VL_AMOUNT;

        response.Barber = new ShortUserResponse
        {
            Fullname = entity.DS_BARBER_FULLNAME,
            Nickname = entity.DS_BARBER_NICKNAME,
            NicknamePreference = entity.CK_BARBER_NICKNAME_PREFERENCE
        };

        response.Customer = new ShortUserResponse
        {
            Fullname = entity.DS_CUSTOMER_FULLNAME,
            Nickname = entity.DS_CUSTOMER_NICKNAME,
            NicknamePreference = entity.CK_CUSTOMER_NICKNAME_PREFERENCE
        };

        response.Status = new ItemResponse
        {
            Id = entity.ID_STATUS,
            Code = entity.CD_STATUS,
            Description = entity.DS_STATUS
        };

        var serviceResponseList = new List<ServiceResponse>();

        foreach (var service in services)
        {
            var srv = new ServiceResponse
            {
                Id = service.ID_SERVICE,
                Code = service.CD_SERVICE,
                Description = service.DS_SERVICE,
                Price = service.VL_PRICE
            };

            serviceResponseList.Add(srv);
        }

        response.Services = serviceResponseList;

        return response;
    }
}
