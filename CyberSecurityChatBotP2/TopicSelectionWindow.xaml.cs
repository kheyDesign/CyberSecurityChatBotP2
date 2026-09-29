using System.Windows;

namespace CyberSecurityChatBotP2
{
    /// <summary>
    /// Interaction logic for TopicSelectionWindow.xaml
    /// </summary>
    public partial class TopicSelectionWindow : Window
    {
        // Constructor - receives the user's name from MainWindow
        public TopicSelectionWindow(string userName)
        {
            InitializeComponent();

            // Display the user's name
            WelcomeUserName.Text = $"Welcome, {userName}!";

            // Display ASCII Art
            AsciiArtHeader.Text =
@" ___      ___       __       ___  ___   __     ___      ___
|""  \    /""  |     /""""\     |""  \/""  | |"" \   |""  \    /""  |
 \   \  //   |    /    \     \   \  /  ||  |   \   \  //   |
 /\\  \/.    |   /' /\  \     \\  \/   |:  |   /\\  \/.    |
|: \.        |  //  __'  \    /\.  \   |.  |  |: \.        |
|.  \    /:  | /   /  \\  \  /  \   \  /\  |\ |.  \    /:  |
|___|\__/|___|(___/    \___)|___/\___|(__\_|_)|___|\__/|___|";
        }

        // ==========================
        // PHISHING
        // ==========================
        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "PHISHING TIPS\n\n" +
                "• Check email addresses carefully.\n" +
                "• Don't click suspicious links.\n" +
                "• Never share passwords.\n" +
                "• Watch out for urgent requests.");
        }

        // ==========================
        // PASSWORDS
        // ==========================
        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "PASSWORD TIPS\n\n" +
                "• Use strong passwords.\n" +
                "• Never reuse passwords.\n" +
                "• Enable Multi-Factor Authentication.\n" +
                "• Use a password manager.");
        }

        // ==========================
        // LINKS
        // ==========================
        private void LinksButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "LINK SAFETY TIPS\n\n" +
                "• Hover over links before clicking.\n" +
                "• Verify website URLs.\n" +
                "• Avoid shortened links.\n" +
                "• Visit official websites directly.");
        }

        // ==========================
        // MALWARE
        // ==========================
        private void Malware_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "MALWARE TIPS\n\n" +
                "• Install antivirus software.\n" +
                "• Keep software updated.\n" +
                "• Avoid suspicious downloads.\n" +
                "• Scan files regularly.");
        }

        // ==========================
        // FIREWALL
        // ==========================
        private void Firewall_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "FIREWALL TIPS\n\n" +
                "• Keep your firewall enabled.\n" +
                "• Monitor network traffic.\n" +
                "• Block unnecessary connections.\n" +
                "• Review settings regularly.");
        }

        // ==========================
        // VPN
        // ==========================
        private void VPN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "VPN TIPS\n\n" +
                "• Use trusted VPN providers.\n" +
                "• Use VPN on public Wi-Fi.\n" +
                "• Keep VPN software updated.\n" +
                "• Disconnect when not needed.");
        }
    }
}
