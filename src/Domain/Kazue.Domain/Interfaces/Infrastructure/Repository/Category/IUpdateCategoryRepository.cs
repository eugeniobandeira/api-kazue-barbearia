using Kazue.Domain.Request.Category;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Category;

public interface IUpdateCategoryRepository
{
    Task UpdateAsync(long id, CategoryRequest req);
}
