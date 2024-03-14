using Npgsql;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Extensions.Configuration;

namespace RestieAPI.Configs
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MyDatabase");
        }

        public void ExecuteNonQuery(string sql)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        public NpgsqlDataReader ExecuteQuery(string sql)
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            var cmd = new NpgsqlCommand(sql, connection);
            return cmd.ExecuteReader();
        }

        internal Task ExecuteQueryAsync(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
