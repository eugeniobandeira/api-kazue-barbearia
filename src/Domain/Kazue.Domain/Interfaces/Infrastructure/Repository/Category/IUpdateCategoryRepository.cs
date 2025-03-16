using Kazue.Domain.Request.Category;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Category;

public interface IUpdateCategoryRepository
{
    Task UpdateAsync(Guid id, CategoryRequest req);
}
