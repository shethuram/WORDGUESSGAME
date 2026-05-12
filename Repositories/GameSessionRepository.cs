
using Npgsql;
using WordGuessGame.Data;
using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Repositories
{
    public class GameSessionRepository
        : IGameSessionRepository
    {
        public void SaveGameSession(
            GameSession session)
        {
            using var connection =
                DbConnectionFactory.CreateConnection();

            connection.Open();

            string query = @"
            INSERT INTO game_sessions
            (
                user_id,
                difficulty,
                attempts_used,
                score,
                time_taken,
                is_won
            )
            VALUES
            (
                @user_id,
                @difficulty,
                @attempts_used,
                @score,
                @time_taken,
                @is_won
            );";

            using var command =
                new NpgsqlCommand(
                    query,
                    connection);

            command.Parameters.AddWithValue(
                "@user_id",
                session.UserId);

            command.Parameters.AddWithValue(
                "@difficulty",
                session.Difficulty);

            command.Parameters.AddWithValue(
                "@attempts_used",
                session.AttemptsUsed);

            command.Parameters.AddWithValue(
                "@score",
                session.Score);

            command.Parameters.AddWithValue(
                "@time_taken",
                session.TimeTaken);

            command.Parameters.AddWithValue(
                "@is_won",
                session.IsWon);

            command.ExecuteNonQuery();
        }
    }
}

