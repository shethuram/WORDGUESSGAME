using Npgsql;

namespace WordGuessGame.Data
{
    public static class DbConnectionFactory
    {
        private static readonly string _connectionString =
            "Host=localhost;Port=5432;Database=wordguessdb;Username=postgres;Password=Shethu@2128";

        public static NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}