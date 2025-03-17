using Kazue.Domain.Entities.Status;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.Status;

namespace Kazue.Application.Adapter.Status;

public static class StatusAdapter
{
    public static StatusResponse FromEntityToResponse(StatusEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), "Cannot adapt a null entity to response");

        return new StatusResponse
        {
            Id = entity.ID_STATUS,
            Code = entity.CD_STATUS,
            Description = entity.DS_STATUS,

            Category = new ItemResponse()
            {
                Id = entity.ID_CATEGORY,
                Code = entity.CD_CATEGORY,
                Description = entity.DS_CATEGORY
            }
        };
    }
}
