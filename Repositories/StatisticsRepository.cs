using Npgsql;
using WordGuessGame.Data;
using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Repositories
{
    public class StatisticsRepository
        : IStatisticsRepository
    {
        public void UpdateStatistics(
            bool isWon,
            int attemptsUsed)
        {
            using var connection =
                DbConnectionFactory.CreateConnection();

            connection.Open();

            string query = @"
            UPDATE player_statistics
            SET
                games_played = games_played + 1,

                games_won = games_won + @won,

                games_lost = games_lost + @lost,

                total_attempts =
                    total_attempts + @attempts;";

            using var command =
                new NpgsqlCommand(
                    query,
                    connection);

            command.Parameters.AddWithValue(
                "@won",
                isWon ? 1 : 0);

            command.Parameters.AddWithValue(
                "@lost",
                isWon ? 0 : 1);

            command.Parameters.AddWithValue(
                "@attempts",
                attemptsUsed);

            command.ExecuteNonQuery();
        }

        public PlayerStatistics GetStatistics()
        {
            using var connection =
                DbConnectionFactory.CreateConnection();

            connection.Open();

            string query = @"
            SELECT
                games_played,
                games_won,
                games_lost,
                total_attempts
            FROM player_statistics
            LIMIT 1;";

            using var command =
                new NpgsqlCommand(
                    query,
                    connection);

            using var reader =
                command.ExecuteReader();

            PlayerStatistics statistics =
                new();

            if (reader.Read())
            {
                statistics.GamesPlayed =
                    reader.GetInt32(0);

                statistics.GamesWon =
                    reader.GetInt32(1);

                statistics.GamesLost =
                    reader.GetInt32(2);

                statistics.TotalAttempts =
                    reader.GetInt32(3);
            }

            return statistics;
        }
    }
}

