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

            if (query.Contains("phishing"))
            {
                // Array of individual phishing tips
                string[] phishingTips = {
                    "Maximus (Phishing Tip): Check email addresses carefully for subtle typos or fake domains.",
                    "Maximus (Phishing Tip): Never click on suspicious links or unexpected attachments.",
                    "Maximus (Phishing Tip): Never share your passwords over email or chat.",
                    "Maximus (Phishing Tip): Always watch out for urgent or threatening requests demanding immediate action."
                };

                // Select and display a random tip from the array
                string randomTip = phishingTips[rand.Next(phishingTips.Length)];
                AddBotMessage(randomTip);
            }
            else if (query.Contains("password") || query.Contains("passwords"))
            {
                string[] passwordTips = {
                    "Maximus (Password Tip): Always use strong, complex passwords combining letters, numbers, and symbols.",
                    "Maximus (Password Tip): Never reuse the same password across multiple websites or accounts.",
                    "Maximus (Password Tip): Enable Multi-Factor Authentication (MFA) wherever it is available.",
                    "Maximus (Password Tip): Use a trusted password manager to securely store and generate your credentials."
                };
                AddBotMessage(passwordTips[rand.Next(passwordTips.Length)]);
            }
            else if (query.Contains("link") || query.Contains("links"))
            {
                string[] linkTips = {
                    "Maximus (Link Safety Tip): Always hover over links before clicking to preview the actual destination URL.",
                    "Maximus (Link Safety Tip): Verify website URLs carefully to spot lookalike or fraudulent domains.",
                    "Maximus (Link Safety Tip): Avoid clicking on shortened links from unknown or untrusted sources.",
                    "Maximus (Link Safety Tip): Visit official websites directly by typing the address into your browser."
                };
                AddBotMessage(linkTips[rand.Next(linkTips.Length)]);
            }
            else if (query.Contains("malware"))
            {
                string[] malwareTips = {
                    "Maximus (Malware Tip): Install and maintain reputable antivirus and anti-malware software.",
                    "Maximus (Malware Tip): Keep your operating system and applications updated with the latest security patches.",
                    "Maximus (Malware Tip): Avoid downloading files or software from untrusted third-party sites.",
                    "Maximus (Malware Tip): Run regular system scans to detect and remove potential threats early."
                };
                AddBotMessage(malwareTips[rand.Next(malwareTips.Length)]);
            }
            else if (query.Contains("firewall"))
            {
                string[] firewallTips = {
                    "Maximus (Firewall Tip): Always keep your system and network firewall enabled.",
                    "Maximus (Firewall Tip): Monitor network traffic regularly for unusual or unauthorized outbound activity.",
                    "Maximus (Firewall Tip): Block unnecessary ports and incoming connections you don't recognize.",
                    "Maximus (Firewall Tip): Review your security and firewall settings on a regular basis."
                };
                AddBotMessage(firewallTips[rand.Next(firewallTips.Length)]);
            }
            else if (query.Contains("vpn"))
            {
                string[] vpnTips = {
                    "Maximus (VPN Tip): Always choose trusted, reputable VPN service providers.",
                    "Maximus (VPN Tip): Always enable your VPN when connecting to public Wi-Fi networks.",
                    "Maximus (VPN Tip): Keep your VPN client software updated to the latest version.",
                    "Maximus (VPN Tip): Disconnect your VPN session when it is no longer needed."
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


