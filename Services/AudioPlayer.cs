using System;
using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot.Services
{
    public static class AudioPlayer
    {
        public static void PlayGreetings(string filePath)
        {
            if (!File.Exists(filePath))
            {
                NotifyMissingFile();
                return;
            }

            TryPlayAudio(filePath);
        }

        private static void TryPlayAudio(string path)
        {
            try
            {
                using (var sound = new SoundPlayer(path))
                {
                    sound.PlaySync();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private static void NotifyMissingFile()
        {
            Console.WriteLine("[Audio file not found. Continuing without voice greeting.]");
        }

        private static void ShowError(string message)
        {
            Console.WriteLine($"[Could not play audio: {message}]");
        }
    }
}