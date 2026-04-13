namespace CybersecurityAwarenessBot.Models
{
    public class UserProfile
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value ?? string.Empty;
        }
    }
}