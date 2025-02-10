using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kazue.Infrastructure.Helpers;

public class MySqlDynamicParameters : SqlMapper.IDynamicParameters
{
    private readonly DynamicParameters _dynamicParameters = new DynamicParameters();
    private readonly List<MySqlParameter> _mySqlParameters = new List<MySqlParameter>();

    public void Add(string name, MySqlDbType mySqlDbType, ParameterDirection direction, object value = null,
        int? size = null)
    {
        MySqlParameter mySqlParameter;
        if (size.HasValue)
        {
            mySqlParameter = new MySqlParameter(name, mySqlDbType, size.Value)
            {
                Value = value,
                Direction = direction
            };
        }
        else
        {
            mySqlParameter = new MySqlParameter(name, mySqlDbType)
            {
                Value = value,
                Direction = direction
            };
        }

        _mySqlParameters.Add(mySqlParameter);
    }

    public void Add(string name, MySqlDbType mySqlDbType, ParameterDirection direction)
    {
        var mySqlParameter = new MySqlParameter(name, mySqlDbType)
        {
            Direction = direction
        };

        _mySqlParameters.Add(mySqlParameter);
    }

    public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
    {
        ((SqlMapper.IDynamicParameters)_dynamicParameters).AddParameters(command, identity);

        var mySqlCommand = command as MySqlCommand;
        if (mySqlCommand is not null)
            mySqlCommand.Parameters.AddRange(_mySqlParameters.ToArray());
    }

    public string GetParameter(int index)
        => _mySqlParameters[index].Value?.ToString();

    public int GetCountParameter()
        => _mySqlParameters.Count;
}
