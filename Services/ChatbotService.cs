using CybersecurityAwarenessBot.Models;
using CybersecurityAwarenessBot.UI;
using System;

namespace CybersecurityAwarenessBot.Services
{
    public class ChatbotService
    {
        private readonly ResponseService _responder;

        public ChatbotService()
        {
            _responder = new ResponseService();
        }

        public void StartChat(UserProfile user)
        {
            RunChatLoop(user);
        }

        private void RunChatLoop(UserProfile user)
        {
            bool isRunning = true;

            while (isRunning)
            {
                string? input = GetUserInput(user);

                if (!IsValidInput(input))
                {
                    ShowInvalidInputMessage();
                    continue;
                }

                string reply = GenerateReply(input!, user.Name);
                DisplayReply(reply);

                if (ShouldExit(input!))
                {
                    isRunning = false;
                }
            }
        }

        private string? GetUserInput(UserProfile user)
        {
            ConsoleUI.WriteUserPrompt($"{user.Name}: ");
            return Console.ReadLine();
        }

        private bool IsValidInput(string? input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private void ShowInvalidInputMessage()
        {
            ConsoleUI.WriteError("Invalid input. Please type a valid question.");
        }

        private string GenerateReply(string input, string userName)
        {
            return _responder.GetResponse(input, userName);
        }

        private void DisplayReply(string message)
        {
            ConsoleUI.WriteBotMessage(message);
        }

        private bool ShouldExit(string input)
        {
            return input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase);
        }
    }
}