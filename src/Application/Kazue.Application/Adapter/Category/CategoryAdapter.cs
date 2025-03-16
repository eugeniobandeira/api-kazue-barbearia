using Kazue.Domain.Entities.Category;
using Kazue.Domain.Response.Category;

namespace Kazue.Application.Adapter.Category;

public static class CategoryAdapter
{
    public static CategoryResponse FromEntityToResponse(CategoryEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), "Cannot adapt a null entity to response");

        return new CategoryResponse
        {
            Id = entity.ID_CATEGORY,
            Code = entity.CD_CATEGORY,
            Description = entity.DS_CATEGORY
        };
    }
}
