using System;
using System.Media;
using System.Windows;



//-------------------------------------------------------------------
//MainWindow class: Handles the initial launch, audio greeting
//ASCII ART and capturing the users name for personalization.
//-------------------------------------------------------------------

namespace CyberSecurityChatBotP2
{
    public partial class MainWindow : Window
    {
        //Store the user's name accross the a
        private string userName = "";


        //Constructor: Runs automatically when the application starts.
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


         //Play the welcome sound. When the App starts.
         PlayWelcomeGreeting();
        }

        // Method to saftely play the welcome audio WAV file.
        private void PlayWelcomeGreeting()
        {
            try
            {
                // Loads and plays the chatbots WAV audio greeting. 
                SoundPlayer player = new SoundPlayer("maximus_greeting.wav");
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                // Try-catch exception. Incase the audio file is missing so the application doesnt crash.
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }


        // Event handler thats triggered when users click the Submit button.
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Get/retrieve the name entered by the user and clean up extra whitespace.
            string enteredName = NameTextBox.Text.Trim().ToLower();


            // Validation Check to see if the user entered a name or left it blank
            if (string.IsNullOrWhiteSpace(enteredName))
            {
                MessageBox.Show("Please enter your name.");
                return; // Exit the method if no name was entered
            }

            //Saves the name to local 
            userName = enteredName;


            //Open the topic selection window and pass the users name forward.
            TopicSelectionWindow topicWindow =
                new TopicSelectionWindow(enteredName);
                topicWindow.Show();

            //Closes the current window
            this.Close();

  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}