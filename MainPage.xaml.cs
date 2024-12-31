using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;
using Microsoft.Maui.Platform;
using Plugin.Maui.Audio;

namespace FlanaganOranTriviaGame
{
    public partial class MainPage : ContentPage
    {
        public List<string> Players { get; set; } = new List<string>();
        private int _currentPlayerIndex = -1;
        private bool isDarkTheme = true;
        private readonly IAudioManager audioManager;
        public static string CurrentPlayerName { get; set; }
        private List<string> player = new List<string>();
        
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }

        private async void EnterNames_Clicked(object sender, EventArgs e)
        {
            var enterNames = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("button_click_sound.mp3"));
            enterNames.Play();
            Players.Clear();
            for (int i = 1; i <= 4; i++)
            {
                string playerNames = await DisplayPromptAsync($"Player {i}", "Enter your name");

                if (string.IsNullOrWhiteSpace(playerNames))
                {
                    await DisplayAlert("Error", $"Player{i} must enter a valid name to play.", "OK");
                    return;
                }
                Players.Add(playerNames);

            }

            if (Players == null || Players.Count == 0)
                {
                    await DisplayAlert("Error", "No players available!", "OK");
                    return;
                }

            if (_currentPlayerIndex < Players.Count)
            {
                _currentPlayerIndex++;
            }

            CurrentPlayerName = Players[_currentPlayerIndex];
            await Navigation.PushAsync(new CashBuilder());
            

            var begin = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("_The_Chase_Theme_Music_.mp3"));
            begin.Play();
        }

        private async void Instruction_Button_Clicked(object sender, EventArgs e)
        {
            var instruction = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("button_click_sound.mp3"));
            instruction.Play();
            await Navigation.PushAsync(new InstructionPage());
        }

        private async void Setting_Button_Clicked(object sender, EventArgs e)
        {
            var setting = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("button_click_sound.mp3"));
            setting.Play();
            await Navigation.PushAsync(new Settings());
        }
    }
}
