using System;

namespace CybersecurityAwarenessBot.Services
{
    public class ResponseService
    {
        public string GetResponse(string userInput, string userName)
        {
            var cleanedInput = NormalizeInput(userInput);

            if (IsEmpty(cleanedInput))
                return "You entered nothing. Please type a question so I can help you.";

            if (Matches(cleanedInput, "how are you"))
                return $"I am doing well, {userName}. Thank you for asking. I am ready to help you with cybersecurity awareness.";

            if (MatchesAny(cleanedInput, "what's your purpose", "what is your purpose"))
                return "My purpose is to educate users about cybersecurity risks and help them stay safe online.";

            if (Matches(cleanedInput, "what can i ask you about"))
                return "You can ask me about password safety, phishing, suspicious links, scams, safe browsing, and basic online protection.";

            if (Matches(cleanedInput, "password"))
                return GetPasswordAdvice();

            if (Matches(cleanedInput, "phishing"))
                return GetPhishingAdvice();

            if (MatchesAny(cleanedInput, "safe browsing", "browse safely", "browsing"))
                return GetBrowsingAdvice();

            if (MatchesAny(cleanedInput, "suspicious link", "link"))
                return GetLinkAdvice();

            if (Matches(cleanedInput, "scam"))
                return GetScamAdvice();

            if (cleanedInput == "exit")
                return $"Goodbye, {userName}. Stay safe online!";

            return GetFallbackMessage();
        }

        private string NormalizeInput(string input)
        {
            return input?.ToLower().Trim() ?? string.Empty;
        }

        private bool IsEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        private bool Matches(string input, string keyword)
        {
            return input.Contains(keyword);
        }

        private bool MatchesAny(string input, params string[] keywords)
        {
            foreach (var word in keywords)
            {
                if (input.Contains(word))
                    return true;
            }
            return false;
        }

        private string GetPasswordAdvice()
        {
            return "Use strong passwords with letters, numbers, and symbols. Do not use personal details like your name or birthday.";
        }

        private string GetPhishingAdvice()
        {
            return "Phishing is when someone pretends to be a trusted company to steal your information. Do not click strange links or share your passwords.";
        }

        private string GetBrowsingAdvice()
        {
            return "Stay safe online by visiting trusted websites, looking for HTTPS, avoiding pop-ups, and updating your browser.";
        }

        private string GetLinkAdvice()
        {
            return "Check a link before clicking it. If it looks strange or unfamiliar, do not click it.";
        }

        private string GetScamAdvice()
        {
            return "Scams try to scare or rush you. Be careful of messages asking for money or personal information.";
        }

        private string GetFallbackMessage()
        {
            return "Sorry, I did not understand. Please ask again. You can ask about browsing, phishing, or passwords.";
        }
    }
}