using System.Windows;


//-------------------------------------------------------------------
//TopicSelectionWindow class: Handles the topic selection screen,
//displaying available topics and capturing the user's selection.
//-------------------------------------------------------------------

namespace CyberSecurityChatBotP2
{
    public partial class TopicSelectionWindow : Window
    {
        //Local variable to store the user's name passed from the previous window.
        private string userName;
        
       
        //Constructor: Initializes the TopicSelectionWindow and sets the user's name.
        
        public TopicSelectionWindow(string userName)
        {
            InitializeComponent();
            this.userName = userName;


            //Personalize the UI Handler with the user's name. (welcome message)
            WelcomeUserName.Text = $"Welcome, {userName}!";


            // Display ASCII Art in the GUI
            AsciiArtHeader.Text =
 @" ___      ___       __       ___  ___   __     ___      ___  ____  ____   ________  
|""  \    /""  |     /""""\     |""  \/""  | |"" \   |""  \    /""  |(""  _||_ "" | /""       ) 
 \   \  //   |    /    \     \   \  /  ||  |   \   \  //   ||   (  ) : |(:   \___/  
 /\\  \/.    |   /' /\  \     \\  \/   |:  |   /\\  \/.    |(:  |  | . ) \___  \    
|: \.        |  //  __'  \    /\.  \   |.  |  |: \.        | \\ \__/ //   __/  \\   
|.  \    /:  | /   /  \\  \  /  \   \  /\  |\ |.  \    /:  | /\\ __ //\  /"" \   :)  
|___|\__/|___|(___/    \___)|___/\___|(__\_|_)|___|\__/|___|(__________)(_______/   
                                                ";
        }


        //Event handlers for each topic button click, opening the chat window with the selected topic.
        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            OpenChatWithTopic("Phishing");
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            OpenChatWithTopic("Passwords");
        }

        private void LinksButton_Click(object sender, RoutedEventArgs e)
        {
            OpenChatWithTopic("Links");
        }

        private void Malware_Click(object sender, RoutedEventArgs e)
        {
            OpenChatWithTopic("Malware");
        }

        private void Firewall_Click(object sender, RoutedEventArgs e)
        {
            OpenChatWithTopic("Firewall");
        }

        private void VPN_Click(object sender, RoutedEventArgs e)
        {
            OpenChatWithTopic("VPN");
        }


        ///Helper method to open the chat window with the selected topic.
        private void OpenChatWithTopic(string topic)
        {
            ChatScreenWindow chatWindow = new ChatScreenWindow(userName, topic);
            chatWindow.Show();
            this.Close();
        }
    }
}