using NSubstitute.Core;
using System;


namespace CyberSecurityChatBotP2
{
    
    public class ChatBotLogicEngine
    {

       
        private string userName;               
        private string lastTopic = "";         //Conversation flow handler
        private string favoriteTopic = "";     //Memory recall. Remembers topic.
        private Random random = new Random();  //Random Response response Arrays. Chooses a random tip from the list. 


        //Constructor accepts the user's name.
        public ChatBotLogicEngine(string userName)
        {
            this.userName = userName;
        }


        // Method processes the user's input and generates a response.
        public string GetResponse(string userInput, out string updatedFavoriteTopic)
        {
            string query = userInput.ToLower();
            updatedFavoriteTopic = this.favoriteTopic;


            //Sentiment Detection Checks how the user is feeling and responds accordingly.
            if (query.Contains("worried") || query.Contains("scared") || query.Contains("nervous") || query.Contains("unsure"))
            {
                return $"I understand that cybersecurity can feel overwhelming, {userName}. Don't worry, you're taking the right steps by learning about it. Take it one step at a time, and I'm here to help!";
            }

            else if (query.Contains("frustrated") || query.Contains("confused") || query.Contains("annoyed") || query.Contains("hard"))
            {
                return $"I know it can be a bit tricky sometimes, {userName}, but take a deep breath. We can break any topic down into simple steps whenever you're ready.";
            }


            //Stores favourite topic.
            if (query.Contains("curious") || query.Contains("interested") || query.Contains("want to know"))
            {

            if (query.Contains("phishing")) favoriteTopic = "Phishing";
            else if (query.Contains("password")) favoriteTopic = "Passwords";
            else if (query.Contains("Links")) favoriteTopic = "Links";
            else if (query.Contains("Malware")) favoriteTopic = "Malware";
            else if (query.Contains("Firewall")) favoriteTopic = "Firewall";
            else if (query.Contains("VPN")) favoriteTopic = "VPN";

            updatedFavoriteTopic = favoriteTopic;
            return $"It's great that you're curious, {userName}! Continuous learning is the best defense. {(string.IsNullOrEmpty(favoriteTopic) ? "" : $"I'll remember that you're interested in {favoriteTopic}.")}";
        }



        //Conversation flow handler. If the user asks for another tip based on last topic discussed.
        if (query.Contains("another tip") || query.Contains("tell me more") || query.Contains("explain more"))
            {
            if (!string.IsNullOrEmpty (lastTopic))
        {
        return $"Sure! Here's another tip about {lastTopic}: \n" + GetRandomTipForTopic(lastTopic);
        }
        return "I'd be happy to share more! Which topic would you like another tip on—Phishing, Passwords, Links, Malware, Firewall, or VPN?";
            }

       
            //Keyword detection and response user's input with a tip from the arrays.
            if (query.Contains("phishing"))
            {
                // Array of individual phishing tips
                lastTopic = "Phishing";
                string[] phishingTips = {
                    "Check email addresses carefully for subtle typos or fake domains.",
                    "Never click on suspicious links or unexpected attachments.",
                    "Never share your passwords over email or chat.",
                    "Always watch out for urgent or threatening requests demanding immediate action."
                };
                // Select and display a random tip from the array
                return phishingTips[random.Next(phishingTips.Length)];
                
              
            }
            else if (query.Contains("password") || query.Contains("passwords"))
            {
                lastTopic="Passwords";
                string[] passwordTips = {
                    "Always use strong, complex passwords combining letters, numbers, and symbols.",
                    "Never reuse the same password across multiple websites or accounts.",
                    "Enable Multi-Factor Authentication (MFA) wherever it is available.",
                    "Use a trusted password manager to securely store and generate your credentials."
                };

               return passwordTips[random.Next(passwordTips.Length)];
               
            }
            else if (query.Contains("link") || query.Contains("links"))
            {
                lastTopic="Links";
                string[] linkTips = {
                    "Always hover over links before clicking to preview the actual destination URL.",
                    "Verify website URLs carefully to spot lookalike or fraudulent domains.",
                    "Avoid clicking on shortened links from unknown or untrusted sources.",
                    "Visit official websites directly by typing the address into your browser."
                };
                return linkTips[random.Next(linkTips.Length)];

            }
            else if (query.Contains("malware"))
            {
                lastTopic="Malware";
                string[] malwareTips = {
                    "Install and maintain reputable antivirus and anti-malware software.",
                    "Keep your operating system and applications updated with the latest security patches.",
                    "Avoid downloading files or software from untrusted third-party sites.",
                    "Run regular system scans to detect and remove potential threats early."
                };
                return malwareTips[random.Next(malwareTips.Length)];
             
            }
            else if (query.Contains("firewall"))
            {
                lastTopic="Firewall";
                string[] firewallTips = {
                    "Always keep your system and network firewall enabled.",
                    "Monitor network traffic regularly for unusual or unauthorized outbound activity.",
                    "Block unnecessary ports and incoming connections you don't recognize.",
                    "Review your security and firewall settings on a regular basis."
                };
                return firewallTips[random.Next(firewallTips.Length)];
                
            }
            else if (query.Contains("vpn"))
            {
                lastTopic="VPN";
                string[] vpnTips = {
                    "Always choose trusted, reputable VPN service providers.",
                    "Always enable your VPN when connecting to public Wi-Fi networks.",
                    "Keep your VPN client software updated to the latest version.",
                    "Disconnect your VPN session when it is no longer needed."
               };

            return vpnTips[random.Next(vpnTips.Length)];

               
            }
            else if (query.Contains("how are you"))
            {
                return $"Maximus: I am good {userName}, I am here to help you stay safe online. {(string.IsNullOrEmpty(favoriteTopic) ? "" : $"As someone intrested in {favoriteTopic}.")}";
            }
            else
            {
                //Error handler If the user input doesn't match any known keywords, provide a default response.
                return $"Maximus: That's an interesting question about '{userInput}'. Feel free to ask about Phishing, Passwords, Links, Malware, Firewall, or VPN!";
            }
        }

        //Helper method for conversation flow. Returns a random tip from the specified topic's array.
        private string GetRandomTipForTopic(string topic)
        {
            string[] tips = topic switch
            {
                "Phishing" => new[] {
                    "Check email addresses carefully for subtle typos or fake domains.",
                    "Never click on suspicious links or unexpected attachments.",
                    "Never share your passwords over email or chat.",
                    "Always watch out for urgent or threatening requests demanding immediate action."
                },
                "Passwords" => new[] {
                    "Always use strong, complex passwords combining letters, numbers, and symbols.",
                    "Never reuse the same password across multiple websites or accounts.",
                    "Enable Multi-Factor Authentication (MFA) wherever it is available.",
                    "Use a trusted password manager to securely store and generate your credentials."
                },
                "Links" => new[] {
                    "Always hover over links before clicking to preview the actual destination URL.",
                    "Verify website URLs carefully to spot lookalike or fraudulent domains.",
                    "Avoid clicking on shortened links from unknown or untrusted sources.",
                    "Visit official websites directly by typing the address into your browser."
                },
                "Malware" => new[] {
                    "Install and maintain reputable antivirus and anti-malware software.",
                    "Keep your operating system and applications updated with the latest security patches.",
                    "Avoid downloading files or software from untrusted third-party sites.",
                    "Run regular system scans to detect and remove potential threats early."
                },
                "Firewall" => new[] {
                    "Always keep your system and network firewall enabled.",
                    "Monitor network traffic regularly for unusual or unauthorized outbound activity.",
                    "Block unnecessary ports and incoming connections you don't recognize.",
                    "Review your security and firewall settings on a regular basis."
                },
                "VPN" => new[] {
                    "Always choose trusted, reputable VPN service providers.",
                    "Always enable your VPN when connecting to public Wi-Fi networks.",
                    "Keep your VPN client software updated to the latest version.",
                    "Disconnect your VPN session when it is no longer needed."
                },
                _ => new[] { "Stay vigilant and verify links before clicking." }
            };

            return tips[random.Next(tips.Length)];
        }
    }
}