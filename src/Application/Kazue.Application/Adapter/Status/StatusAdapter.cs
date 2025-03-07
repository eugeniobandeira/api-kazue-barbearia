using Kazue.Domain.Entities.Status;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.Adapter.Status;

public static class StatusAdapter
{
    public static StatusResponse FromEntityToResponse(StatusEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException("Cannot adapt a null entity to response", nameof(entity));

        return new StatusResponse
        {
            Id = entity.ID_STATUS,
            Code = entity.CD_STATUS,
            Description = entity.DS_STATUS
        };
    }
}
