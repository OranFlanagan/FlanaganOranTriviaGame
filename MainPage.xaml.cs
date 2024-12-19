using System.Timers;
//using timers for the questions
using Timer = System.Timers.Timer;
using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;

namespace FlanaganOranTriviaGame
{
    public partial class MainPage : ContentPage
    {
        public string Player1;
        public string Player2;
        public string Player3;
        public string Player4;
        public int CashBuilder;
        //random is being used to act as the chaser
        private Random random = new Random();
        private readonly TriviaServiceHard _triviaService;
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
            _triviaService = new TriviaServiceHard();
            LoadTrivia();

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

        private async void LoadTrivia()
        {
            var triviaResponseHard = await _triviaService.FetchTriviaAsync();
            if (triviaResponseHard != null)
            {
                var triviaQuestions = triviaResponseHard.Results;
                BindingContext = new { TriviaQuestionHard = triviaResponseHard.Results };
            }
        }
        private async void PlayBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CashBuilder());
        }

        private async void Instruction_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InstructionPage());
        }

        private async void Setting_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
        /*private void OnThemeToggleClicked(object sender, EventArgs e)
        {
            // Toggle between Light and Dark Mode
            App.Current.UserAppTheme = App.Current.UserAppTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;

            // Update the theme UI
            ApplyTheme();
        }*/

        /*private void ApplyTheme()
        {
            themeLabel.Text = $"Current Theme: {App.Current.UserAppTheme}";

            // Optionally, apply specific styles based on the theme
            Resources["PageStyle"] = App.Current.UserAppTheme == AppTheme.Dark
                ? App.Current.Resources["DarkThemePageStyle"]
                : App.Current.Resources["LightThemePageStyle"];
        }*/
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
