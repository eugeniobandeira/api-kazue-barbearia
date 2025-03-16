using Kazue.Domain.Entities.Category;
using Kazue.Domain.Request.Category;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Category;

public interface ICreateCategoryRepository
{
    Task<CategoryEntity> CreateAsync(CategoryRequest req);
}
