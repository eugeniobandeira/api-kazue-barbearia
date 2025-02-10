using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.ParameterFactory;
public interface IUpdateParametercs
{
    MySqlDynamicParameters UpdateParameters<TRequest>(TRequest req);
}
