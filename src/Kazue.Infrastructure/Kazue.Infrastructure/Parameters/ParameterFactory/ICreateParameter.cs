using Kazue.Infrastructure.Helpers;

namespace Kazue.Infrastructure.Parameters.ParameterFactory;
public interface ICreateParameter
{
    MySqlDynamicParameters CreateParameters<TRequest>(TRequest req);
}
