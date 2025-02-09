using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.ParameterFactory;
public interface IGetByIdParameter
{
    MySqlDynamicParameters IGetByIdParameters<TRequest>(TRequest req);
}
