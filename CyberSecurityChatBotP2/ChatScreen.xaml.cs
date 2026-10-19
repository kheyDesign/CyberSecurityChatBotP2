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
        private ChatBotLogicEngine chatBotLogicEngine;

        //ObservableCollection is used to bind the chat messages to the ListBox in the UI,
        //allowing dynamic updates when new messages are added.
        private ObservableCollection<string> chatMessages = new ObservableCollection<string>();

        //constructor accepts the user's name and an optional initial topic, initializes the UI, and sets up event handlers.
        public ChatScreenWindow(string userName, string initialTopic = "")
        {
            InitializeComponent();
            this.userName = userName;
            this.chatBotLogicEngine = new ChatBotLogicEngine(userName);


           //personalise the UI header
           ChatHeaderTitle.Text = $"Welcome, {this.userName} - Cyber Security Awareness Assistant";
           ChatListBox.ItemsSource = chatMessages;

            // Greet the user when entering the chat screen
            AddBotMessage($"Hello {this.userName}, I am Maximus. I am here to help you stay safe online.");


            // If a topic was clicked in Screen 2, process it immediately in Screen 3
            if (!string.IsNullOrEmpty(initialTopic))
            {
                ProcessTopicQuery(initialTopic);
            }

            // Allow sending message using/ pressing Enter key
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


            //Display the user's message in the chat window and clear the input box for the next message
            chatMessages.Add($"You: {userText}");
            MessageTextBox.Clear();

            // Pass the user's input to the chat bot logic engine and get a response
            string botResponse = chatBotLogicEngine.GetResponse(userText, out string updatedFavoriteTopic);
            AddBotMessage(botResponse);

            //Closes app
            if (userText.ToLower() == "exit" || userText.ToLower() == "quit")
            {
                this.Close();
            }
        }

        //Handles the processing of a topic query, simulating user input and invoking the chat logic engine.
        private void ProcessTopicQuery(string topic)
        {
            
            chatMessages.Add($"You: {topic}");
            string botResponse = chatBotLogicEngine.GetResponse(topic, out string updatedFavoriteTopic);
            AddBotMessage(botResponse);
        }

       
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