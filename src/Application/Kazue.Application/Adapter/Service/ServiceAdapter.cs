using Kazue.Domain.Entities.Service;
using Kazue.Domain.Response.Service;

namespace Kazue.Application.Adapter.Service;

public static class ServiceAdapter
{
    public static ServiceResponse FromEntityToResponse(ServiceEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), "Cannot adapt a null entity to response");

        return new ServiceResponse
        {
            Id = entity.ID_SERVICE,
            Code = entity.CD_SERVICE,
            Description = entity.DS_SERVICE,
            Price = entity.VL_PRICE
        };
    }
}
