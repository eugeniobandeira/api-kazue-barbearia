using System.Data.Common;

namespace Kazue.Domain.Interfaces.Infrastructure.Connection;
public interface IKazueConnection
{
    DbConnection GetConnection();
}
