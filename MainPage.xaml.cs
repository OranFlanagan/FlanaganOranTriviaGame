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
        public int CashBuilder;
        private bool isDarkTheme = true;
        private readonly IAudioManager audioManager;
        //private int _currentPlayerIndex = 0;

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
                string playerName = await DisplayPromptAsync($"Player {i}", "Enter your name");
                
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    await DisplayAlert("Error", $"Player{i} must enter a valid name to play.", "OK");
                    return;
                }
                    Players.Add(playerName);
            }
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
