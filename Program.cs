using CybersecurityAwarenessBot.Models;
using CybersecurityAwarenessBot.Services;
using CybersecurityAwarenessBot.UI;

namespace CybersecurityAwarenessBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitializeApp();

            var currentUser = CreateUserProfile();
            var botService = new ChatbotService();

            ShowIntroMessages(currentUser);

            botService.StartChat(currentUser);
        }

        private static void InitializeApp()
        {
            Console.Title = "Cybersecurity Awareness Bot";
            ConsoleUI.DisplayHeader();
            AudioPlayer.PlayGreetings("Assets/Greetings.wav");
        }

        private static UserProfile CreateUserProfile()
        {
            var profile = new UserProfile();

            ConsoleUI.WriteBotMessage("Hello! Welcome to the Cybersecurity Awareness Bot.");
            ConsoleUI.WriteBotMessage("I am here to help you stay and remain safe online.");
            ConsoleUI.WriteBotMessage("What is your name?"); 

            string? inputName = GetValidName();

            profile.Name = inputName;

            return profile;
        }

        private static string GetValidName()
        {
            string? name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                ConsoleUI.WriteError("Name space provided cannot be empty. Please enter your name:");
                name = Console.ReadLine();
            }

            return name.Trim();
        }

        private static void ShowIntroMessages(UserProfile user)
        {
            ConsoleUI.WriteSuccess($"Hello, nice to meet you, {user.Name}!");
            ConsoleUI.WriteBotMessage("You may ask me things such as:");
            ConsoleUI.WriteBotMessage("- How are you doing today?");
            ConsoleUI.WriteBotMessage("- What may I ask you about?");
            ConsoleUI.WriteBotMessage("- What's your purpose?");
            ConsoleUI.WriteBotMessage("- How do I browse safely?");

            ConsoleUI.WriteBotMessage("- Would you like me explain password safety");
            ConsoleUI.WriteBotMessage("- What is phishing?");
            
            ConsoleUI.WriteBotMessage("Type 'exit' to close the chatbot system.");
        }
    }
}