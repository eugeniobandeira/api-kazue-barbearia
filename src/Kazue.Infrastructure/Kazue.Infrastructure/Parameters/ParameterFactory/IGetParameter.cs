using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.ParameterFactory;
public interface IGetParameter
{
    MySqlDynamicParameters IGetParameters<TRequest>(TRequest req);
}
