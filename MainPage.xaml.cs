using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;
using Microsoft.Maui.Platform;

namespace FlanaganOranTriviaGame
{
    public partial class MainPage : ContentPage
    {
        public string Player1;
        public string Player2;
        public string Player3;
        public string Player4;
        public int CashBuilder;
        private bool isDarkTheme = true;
        //random is being used to act as the chaser
        private readonly TriviaServiceHard _triviaService;

        public MainPage()
        {
            InitializeComponent();
            _triviaService = new TriviaServiceHard();

        }

        private async void PlayBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CashBuilder());
        }
        private async void EnterNames_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Player1 = await DisplayPromptAsync("Player one", "Enter your name");
            if (Player1 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }

            Player2 = await DisplayPromptAsync("Player two", "Enter your name");
            if (Player2 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }

            Player3 = await DisplayPromptAsync("Player 3", "Enter your name");
            if (Player3 == null)
            {
                await DisplayAlert("Error", "You must enter a name to play.", "OK");
                return;
            }

            Player4 = await DisplayPromptAsync("Enter", "Enter your name");
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
    }
}
