using Kazue.Domain.Entities.Category;
using Kazue.Domain.Request.Category;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Category;

public interface IReadCategoryRepository
{
    Task<CategoryEntity?> GetById(long id);
    Task<CategoryEntity?> GetByCodeOrDescription(CategoryRequest req);
    Task<List<CategoryEntity>> GetAll(GetCategoryRequest req);
}
