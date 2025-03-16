namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Category;

public interface IDeleteCategoryRepository
{
    Task DeleteAsync(Guid id);
}
