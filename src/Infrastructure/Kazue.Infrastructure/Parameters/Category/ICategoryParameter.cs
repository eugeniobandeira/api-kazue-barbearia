using Kazue.Domain.Request.Category;
using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.Category;

public interface ICategoryParameter
{
    MySqlDynamicParameters CreateParameters(CategoryRequest req);
    MySqlDynamicParameters UpdateParameters(long id, CategoryRequest req);
    MySqlDynamicParameters GetByIdParameters(long id);
    MySqlDynamicParameters GetByCodeOrDescriptionParameters(CategoryRequest req);
    MySqlDynamicParameters GetAllParameters(GetCategoryRequest req);
    MySqlDynamicParameters DeleteParameters(long id);
}
