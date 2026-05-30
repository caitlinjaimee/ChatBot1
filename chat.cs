using System;
using System.Collections.Generic;

namespace ChatbotWebForm
{
    public interface IChatbot
    {
        string GetResponse(string input);
    }

    public class SmartCybersecurityChatbot : IChatbot
    {
        private Dictionary<string, string> responses;

        public SmartCybersecurityChatbot()
        {
            responses = new Dictionary<string, string>()
            {
                { "hello", "Hi! let's talk about cybersecurity." },
                { "password", "Use strong passwords and enable 2FA. Use a random string of mixed-case letters, numbers and symbols. For example: P@ssw0rd123!" },
                { "phishing", "Watch for fake emails and suspicious links. Don't click on unknown links or attachments." },
                { "vpn", "VPN encrypts your internet traffic." },
                { "tips", "Here are some cybersecurity tips: Use strong passwords, enable 2FA, and keep your software updated. " },
                { "malware", "Avoid unknown downloads and keep antivirus updated." },
                { "help", "Ask about: password, phishing, vpn, malware, tips." },
                { "thank you", "You're welcome!" }
            };
        }

        public string GetResponse(string input)
        {
            input = input.ToLower().Trim();

            foreach (var item in responses)
            {
                if (input.Contains(item.Key))
                    return item.Value;
            }

            return "Sorry, I don't understand. Try asking for 'help'.";
        }
    }
}
