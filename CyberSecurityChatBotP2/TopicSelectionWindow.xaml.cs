using System.Windows;

namespace CyberSecurityChatBotP2
{
    public partial class TopicSelectionWindow : Window
    {
        private string userName;

        public TopicSelectionWindow(string userName)
        {
            InitializeComponent();
            this.userName = userName;

            WelcomeUserName.Text = $"Welcome, {userName}!";

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

        private void OpenChatWithTopic(string topic)
        {
            ChatScreenWindow chatWindow = new ChatScreenWindow(userName, topic);
            chatWindow.Show();
            this.Close();
        }
    }
}