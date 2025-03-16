namespace Kazue.Application.UseCases.Category.Delete;

public interface IDeleteCategoryUseCase
{
    Task ExecuteAsync(Guid id);
}
