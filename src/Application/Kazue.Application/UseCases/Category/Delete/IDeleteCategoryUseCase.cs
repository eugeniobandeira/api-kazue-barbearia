namespace Kazue.Application.UseCases.Category.Delete;

public interface IDeleteCategoryUseCase
{
    Task ExecuteAsync(long id);
}
