using System.Data.Common;

namespace Kazue.Domain.Interfaces.Connection;
public interface IKazueConnection
{
    DbConnection GetConnection();
}
