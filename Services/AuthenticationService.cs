using WordGuessGame.Interfaces;
using WordGuessGame.Models;

namespace WordGuessGame.Services
{
    public class AuthenticationService
        : IAuthenticationService
    {
        private readonly IUserRepository
            _userRepository;

        public AuthenticationService(
            IUserRepository userRepository)
        {
            _userRepository =
                userRepository;
        }

        public void Register()
        {
            Console.Clear();

            Console.WriteLine("===== REGISTER =====");

            Console.Write("Username: ");

            string username =
                Console.ReadLine() ?? "";

            Console.Write("Password: ");

            string password =
                Console.ReadLine() ?? "";

            User user = new()
            {
                Username = username,
                Password = password
            };

            _userRepository.Register(user);

            Console.WriteLine(
                "\nRegistration Successful!");

            Console.WriteLine(
                "Press any key to continue...");

            Console.ReadKey(true);
        }

        public User Login()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== LOGIN =====");

                Console.Write("Username: ");

                string username =
                    Console.ReadLine() ?? "";

                Console.Write("Password: ");

                string password =
                    Console.ReadLine() ?? "";

                User? user =
                    _userRepository.Login(
                        username,
                        password);

                if (user != null)
                {
                    Console.WriteLine(
                        "\nLogin Successful!");

                    Console.ReadKey(true);

                    return user;
                }

                Console.WriteLine(
                    "\nInvalid Credentials!");

                Console.ReadKey(true);
            }
        }
    }
}