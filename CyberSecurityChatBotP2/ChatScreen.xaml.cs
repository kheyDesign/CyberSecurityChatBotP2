using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatBotP2
{
    public partial class ChatScreenWindow : Window
    {
        private string userName;
        private ObservableCollection<string> chatMessages = new ObservableCollection<string>();

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

        private void HandleChatLogic(string input)
        {
            string query = input.ToLower();

            if (query.Contains("phishing"))
            {
                AddBotMessage("Maximus (Phishing Tips):\n• Check email addresses carefully.\n• Don't click suspicious links.\n• Never share passwords.\n• Watch out for urgent requests.");
            }
            else if (query.Contains("password") || query.Contains("passwords"))
            {
                AddBotMessage("Maximus (Password Tips):\n• Use strong passwords.\n• Never reuse passwords.\n• Enable Multi-Factor Authentication.\n• Use a password manager.");
            }
            else if (query.Contains("link") || query.Contains("links"))
            {
                AddBotMessage("Maximus (Link Safety Tips):\n• Hover over links before clicking.\n• Verify website URLs.\n• Avoid shortened links.\n• Visit official websites directly.");
            }
            else if (query.Contains("malware"))
            {
                AddBotMessage("Maximus (Malware Tips):\n• Inst  all antivirus software.\n• Keep software updated.\n• Avoid suspicious downloads.\n• Scan files regularly.");
            }
            else if (query.Contains("firewall"))
            {
                AddBotMessage("Maximus (Firewall Tips):\n• Keep your firewall enabled.\n• Monitor network traffic.\n• Block unnecessary connections.\n• Review settings regularly.");
            }
            else if (query.Contains("vpn"))
            {
                AddBotMessage("Maximus (VPN Tips):\n• Use trusted VPN providers.\n• Use VPN on public Wi-Fi.\n• Keep VPN software updated.\n• Disconnect when not needed.");
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

        private void AddBotMessage(string message)
        {
            chatMessages.Add(message);
            if (ChatListBox.Items.Count > 0)
            {
                ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
            }
        }
    }
}