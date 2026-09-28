using System;
using System.Media;
using System.Windows;



//-------------------------------------------------------------------
// Welcome screen for Maximus Cyber Security Assistant.
//-------------------------------------------------------------------
namespace CyberSecurityChatBotP2
{
  // Interaction logic for MainWindow.xaml

    public partial class MainWindow : Window
    {
        //Store the user's name
        private string userName = "";


        //Constructor
        public MainWindow()
        {
            InitializeComponent();

            // Display Part 1 ASCII Art in the GUI
            AsciiArtTextBlock.Text =
         @" ___      ___       __       ___  ___   __     ___      ___  ____  ____   ________  
|""  \    /""  |     /""""\     |""  \/""  | |"" \   |""  \    /""  |(""  _||_ "" | /""       ) 
 \   \  //   |    /    \     \   \  /  ||  |   \   \  //   ||   (  ) : |(:   \___/  
 /\\  \/.    |   /' /\  \     \\  \/   |:  |   /\\  \/.    |(:  |  | . ) \___  \    
|: \.        |  //  __'  \    /\.  \   |.  |  |: \.        | \\ \__/ //   __/  \\   
|.  \    /:  | /   /  \\  \  /  \   \  /\  |\ |.  \    /:  | /\\ __ //\  /"" \   :)  
|___|\__/|___|(___/    \___)|___/\___|(__\_|_)|___|\__/|___|(__________)(_______/   
                                                                                    ";


            //Play the welcome sound when the application starts
            PlayWelcomeGreeting();
        }

        // Method to play the welcome sound
        private void PlayWelcomeGreeting()
        {
            try
            {
                // Plays the chatbots greeting
                SoundPlayer player = new SoundPlayer("maximus_greeting.wav");
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }


        // Method to handle the button click event
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the name (text) entered by the user
            string enteredName = NameTextBox.Text.Trim().ToLower();


            // Check if the user entered a name or left it blank
            if (string.IsNullOrWhiteSpace(enteredName))
            {
                MessageBox.Show("Please enter your name.");
                return; // Exit the method if no name was entered
            }


            // Welcome the user with a personalized message
            MessageBox.Show($"Hello, {enteredName}! Welcome to the Cyber Security ChatBot.\n \n" +
             "I'm Maximus, your Cyber Security Assistant.\n\n" +
             "Choose a cybersecurity topic below to get started.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}