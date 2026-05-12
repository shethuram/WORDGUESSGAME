using WordGuessGame.Data;

namespace WordGuessGame.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var connection =
                DbConnectionFactory.CreateConnection();

            connection.Open();

            string createGameSessionsTable = @"
            CREATE TABLE IF NOT EXISTS game_sessions
            (
                id SERIAL PRIMARY KEY,
                player_name VARCHAR(50),
                difficulty VARCHAR(20),
                attempts_used INT,
                score INT,
                time_taken INT,
                is_won BOOLEAN,
                played_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
            );";

            string createStatisticsTable = @"
            CREATE TABLE IF NOT EXISTS player_statistics
            (
                id SERIAL PRIMARY KEY,
                games_played INT DEFAULT 0,
                games_won INT DEFAULT 0,
                games_lost INT DEFAULT 0,
                total_attempts INT DEFAULT 0
            );";

            string insertDefaultRow = @"
            INSERT INTO player_statistics
            (
                games_played,
                games_won,
                games_lost,
                total_attempts
            )
            SELECT 0,0,0,0
            WHERE NOT EXISTS
            (
                SELECT 1 FROM player_statistics
            );";

            using var command1 =
                new Npgsql.NpgsqlCommand(
                    createGameSessionsTable,
                    connection);

            command1.ExecuteNonQuery();

            using var command2 =
                new Npgsql.NpgsqlCommand(
                    createStatisticsTable,
                    connection);

            command2.ExecuteNonQuery();

            using var command3 =
                new Npgsql.NpgsqlCommand(
                    insertDefaultRow,
                    connection);

            command3.ExecuteNonQuery();
        }
    }
}