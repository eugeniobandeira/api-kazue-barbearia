using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.ParameterFactory;
public interface IDeleteParameter
{
    MySqlDynamicParameters DeleteParameters<TRequest>(TRequest req);
}
