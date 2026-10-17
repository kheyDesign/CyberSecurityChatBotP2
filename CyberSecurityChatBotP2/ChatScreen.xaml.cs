using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


//-------------------------------------------------------------------
//ChatScreenWindow class: Handles the chat interface, user input, and bot responses.
//keyboard event handling for sending messages with the Enter key. And keyword-based
//response logic for cybersecurity topics.
//-------------------------------------------------------------------

namespace CyberSecurityChatBotP2
{
    public partial class ChatScreenWindow : Window
    {
        private string userName;

        //ObservableCollection is used to bind the chat messages to the ListBox in the UI,
        //allowing dynamic updates when new messages are added.
        private ObservableCollection<string> chatMessages = new ObservableCollection<string>();

        //constructor accepts the user's name and an optional initial topic, initializes the UI, and sets up event handlers.
        public ChatScreenWindow(string userName, string initialTopic = "")
        {
            InitializeComponent();
            this.userName = userName;
            ChatHeaderTitle.Text = $"Welcome, {this.userName} - Cyber Security Awareness Assistant";

            ChatListBox.ItemsSource = chatMessages;

            // Greet the user when entering the chat screen
            AddBotMessage($"Hello {this.userName}, I am Maximus. I am here to help you stay safe online.");

            // If a topic was clicked in Screen 2, process it immediately in Screen 3
            if (!string.IsNullOrEmpty(initialTopic))
            {
                ProcessTopicQuery(initialTopic);
            }

            // Allow sending message using Enter key
            MessageTextBox.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    SendButton_Click(this, new RoutedEventArgs());
                }
            };
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userText = MessageTextBox.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            chatMessages.Add($"You: {userText}");
            MessageTextBox.Clear();

            HandleChatLogic(userText);
        }

        private void ProcessTopicQuery(string topic)
        {
            // Simulates typing/choosing the topic inside the chat window
            chatMessages.Add($"You: {topic}");
            HandleChatLogic(topic);
        }

        // Core logic engine: Parses user queries for keywords and returns a random tip
        private void HandleChatLogic(string input)
        {
           
            string query = input.ToLower();
            Random rand = new Random(); // Initialize random number generator

            // SENTIMENT DETECTION. Adjusts responses based on user sentiment for empathy
            if (query.Contains("worried") || query.Contains("scared") || query.Contains("nervous") || query.Contains("unsure"))
            {
                AddBotMessage($"I understand that cybersecurity can feel overwhelming, {userName}. Don't worry, you're taking the right steps by learning about it. Take it one step at a time, and I'm here to help!");
                return;
            }
            else if (query.Contains("curious") || query.Contains("interested") || query.Contains("want to know"))
            {
                AddBotMessage($"It's great that you're curious, {userName}! Continuous learning is the best defense. Which topic would you like to explore next?");
                return;
            }
            else if (query.Contains("frustrated") || query.Contains("confused") || query.Contains("annoyed") || query.Contains("hard"))
            {
                AddBotMessage($"I know it can be a bit tricky sometimes, {userName}, but take a deep breath. We can break any topic down into simple steps whenever you're ready.");
                return;
            }


            if (query.Contains("phishing"))
            {
                // Array of individual phishing tips
                string[] phishingTips = {
                    "Check email addresses carefully for subtle typos or fake domains.",
                    "Never click on suspicious links or unexpected attachments.",
                    "Never share your passwords over email or chat.",
                    "Always watch out for urgent or threatening requests demanding immediate action."
                };

                // Select and display a random tip from the array
                string randomTip = phishingTips[rand.Next(phishingTips.Length)];
                AddBotMessage(randomTip);
            }
            else if (query.Contains("password") || query.Contains("passwords"))
            {
                string[] passwordTips = {
                    "Always use strong, complex passwords combining letters, numbers, and symbols.",
                    "Never reuse the same password across multiple websites or accounts.",
                    "Enable Multi-Factor Authentication (MFA) wherever it is available.",
                    "Use a trusted password manager to securely store and generate your credentials."
                };
                AddBotMessage(passwordTips[rand.Next(passwordTips.Length)]);
            }
            else if (query.Contains("link") || query.Contains("links"))
            {
                string[] linkTips = {
                    "Always hover over links before clicking to preview the actual destination URL.",
                    "Verify website URLs carefully to spot lookalike or fraudulent domains.",
                    "Avoid clicking on shortened links from unknown or untrusted sources.",
                    "Visit official websites directly by typing the address into your browser."
                };
                AddBotMessage(linkTips[rand.Next(linkTips.Length)]);
            }
            else if (query.Contains("malware"))
            {
                string[] malwareTips = {
                    "Install and maintain reputable antivirus and anti-malware software.",
                    "Keep your operating system and applications updated with the latest security patches.",
                    "Avoid downloading files or software from untrusted third-party sites.",
                    "Run regular system scans to detect and remove potential threats early."
                };
                AddBotMessage(malwareTips[rand.Next(malwareTips.Length)]);
            }
            else if (query.Contains("firewall"))
            {
                string[] firewallTips = {
                    "Always keep your system and network firewall enabled.",
                    "Monitor network traffic regularly for unusual or unauthorized outbound activity.",
                    "Block unnecessary ports and incoming connections you don't recognize.",
                    "Review your security and firewall settings on a regular basis."
                };
                AddBotMessage(firewallTips[rand.Next(firewallTips.Length)]);
            }
            else if (query.Contains("vpn"))
            {
                string[] vpnTips = {
                    "Always choose trusted, reputable VPN service providers.",
                    "Always enable your VPN when connecting to public Wi-Fi networks.",
                    "Keep your VPN client software updated to the latest version.",
                    "Disconnect your VPN session when it is no longer needed."
               };
                AddBotMessage(vpnTips[rand.Next(vpnTips.Length)]);
            }
            else if (query.Contains("how are you"))
            {
                AddBotMessage($"Maximus: I am good {userName}, I am here to help you stay safe online.");
            }
            else
            {
                AddBotMessage($"Maximus: That's an interesting question about '{input}'. Feel free to ask about Phishing, Passwords, Links, Malware, Firewall, or VPN!");
            }
        }

        // Helper method to add messages and enforce auto-scrolling to the latest entry
        private void AddBotMessage(string message)
        {
            chatMessages.Add(message);

            // Automatically scroll the ListBox down so the newest message is always visible
            if (ChatListBox.Items.Count > 0)
            {
                ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
            }
        }
    }
}