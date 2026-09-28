using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CyberSecurityChatBotP2
{
    /// <summary>
    /// Interaction logic for TopicSelectionWindow.xaml
    /// </summary>
    public partial class TopicSelectionWindow : Window
    {
        public TopicSelectionWindow(string userName)
        {
            InitializeComponent();
            WelcomeUserName.Text = $"Welcome, {userName}!";

            //ASCII ART
            AsciiArtHeader.Text =
          @" ___      ___       __       ___  ___   __     ___      ___  ____  ____   ________  
|""  \    /""  |     /""""\     |""  \/""  | |"" \   |""  \    /""  |(""  _||_ "" | /""       ) 
 \   \  //   |    /    \     \   \  /  ||  |   \   \  //   ||   (  ) : |(:   \___/  
 /\\  \/.    |   /' /\  \     \\  \/   |:  |   /\\  \/.    |(:  |  | . ) \___  \    
|: \.        |  //  __'  \    /\.  \   |.  |  |: \.        | \\ \__/ //   __/  \\   
|.  \    /:  | /   /  \\  \  /  \   \  /\  |\ |.  \    /:  | /\\ __ //\  /"" \   :)  
|___|\__/|___|(___/    \___)|___/\___|(__\_|_)|___|\__/|___|(__________)(_______/   
                                                        
        }
    }
