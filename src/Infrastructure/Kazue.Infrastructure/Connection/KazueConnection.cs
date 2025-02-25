using Kazue.Domain.Interfaces.Connection;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Kazue.Infrastructure.Connection;

public class KazueConnection : IKazueConnection
{
    private readonly IConfiguration _config;
    private readonly string? _connectionString;

    public KazueConnection(IConfiguration configuration)
    {
        _config = configuration;
        _connectionString = _config.GetConnectionString("DefaultConnection");
    }
    public DbConnection GetConnection()
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
            throw new ArgumentNullException(nameof(_connectionString), "Connection string can not be null");

        return new MySqlConnection(_connectionString);
    }
}
