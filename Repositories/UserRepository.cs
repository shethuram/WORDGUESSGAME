using Npgsql;
using WordGuessGame.Data;
using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Repositories
{
    public class UserRepository
        : IUserRepository
    {
        public void Register(User user)
        {
            using var connection =
                DbConnectionFactory.CreateConnection();

            connection.Open();

            string query = @"
            INSERT INTO users
            (
                username,
                password
            )
            VALUES
            (
                @username,
                @password
            );";

            using var command =
                new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@username",
                user.Username);

            command.Parameters.AddWithValue(
                "@password",
                user.Password);

            command.ExecuteNonQuery();
        }

        public User? Login(
            string username,
            string password)
        {
            using var connection =
                DbConnectionFactory.CreateConnection();

            connection.Open();

            string query = @"
            SELECT
                id,
                username,
                password
            FROM users
            WHERE username = @username
            AND password = @password;";

            using var command =
                new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@username",
                username);

            command.Parameters.AddWithValue(
                "@password",
                password);

            using var reader =
                command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2)
                };
            }

            return null;
        }
    }
}