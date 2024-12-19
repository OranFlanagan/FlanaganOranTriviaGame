using System.Timers;
//using timers for the questions
using Timer = System.Timers.Timer;
using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;

namespace FlanaganOranTriviaGame
{
    public partial class MainPage : ContentPage
    {
        public string Player1;
        public string Player2;
        public string Player3;
        public string Player4;
        public int CashBuilder;
        //random is neing used to act as the chaser
        private Random random = new Random();
        List<Player> players;
        private Timer gameTimer = new System.Timers.Timer()
        {
            Interval = 1000
        };

        public MainPage()
        {
            Title = "";
            InitializeComponent();
            players = new List<Player>();
            gameTimer.Elapsed += OnTimeElapsed;

        }
        //getting the players name
        public class Player
        {
            internal string name;
            internal int cashBuilder;

            public string Name { get; set; }
            public int CashBuilder { get; set; }

            public Player(string name, int cashBuilder)
            {
                Name = name;
                CashBuilder = cashBuilder;
            }
        }


        private async void PlayBtn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Player1 = await DisplayPromptAsync("Player one", "Enter your name");
            if (Player1 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }
            else
            {
                gameTimer.Start();
            }

            Player2 = await DisplayPromptAsync("Player two", "Enter your name");
            if (Player2 == Player1)
            {
                await DisplayAlert("Error", "That Name is Already Taken", "OK");
                return;
            }
            if (Player2 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }

            Player3 = await DisplayPromptAsync("Player 3", "Enter your name");
            if (Player3 == Player1 || Player3 == Player2)
            {
                await DisplayAlert("Error", "That Name is Already Taken", "OK");
                return;
            }
            if (Player3 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }

            Player4 = await DisplayPromptAsync("Enter", "Enter your name");
            if (Player4 == Player1 || Player4 == Player2 || Player4 == Player3)
            {
                await DisplayAlert("Error", "That Name is Already Taken", "OK");
                return;
            }

            if (Player4 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }

        }

        private async void Instruction_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InstructionPage());
        }

        private async void Setting_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
        public void OnWindowChange(object sender, EventArgs e)
        {
            DisplayAlert(Player1, "Are you ready?", "I am!");
        }

        private async void OnTimeElapsed(Object sender, EventArgs e)
        {
            await DisplayAlert("uh oh", "You've ran out of time ", "OK");
            return;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
