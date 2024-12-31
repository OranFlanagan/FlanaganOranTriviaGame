using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;
using Microsoft.Maui.Platform;
using Plugin.Maui.Audio;
using System.Diagnostics;
/*A lot of the code is just copy and past with the variable names changed to appropriate names 
for example the LoadTrivia, ShowQuestion OnNextClicked, OnAnswerClicked, OnPlayerCompleted, NextplayerTurn, ResetButtonColor and finally LoadNewQuestion*/
namespace FlanaganOranTriviaGame
{
    public partial class MainPage : ContentPage
    {
        public List<string> Players { get; set; } = new List<string>();
        private int _currentPlayerIndex;
        private readonly IAudioManager audioManager;
        public static string CurrentPlayerName { get; set; }
        
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }

        private async void EnterNames_Clicked(object sender, EventArgs e)
        {
            //plays the sound of the button clicked when any of the buttons are clicked 
            var enterNames = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("button_click_sound.mp3"));
            enterNames.Play();
            if (Players.Count == 0)
            {
                //only lets four players and no more enter their names
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
            }

            if (Players.Count == 0)
            { 
                    await DisplayAlert("Error", "No players available!", "OK");
                    return;
            }
            //displays the current players name when CashBuilder is open
            CurrentPlayerName = Players[_currentPlayerIndex];
            await Navigation.PushAsync(new CashBuilder());

            if (_currentPlayerIndex < Players.Count)
            {
                _currentPlayerIndex++;
            }
            
            var begin = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("_The_Chase_Theme_Music_.mp3"));
            begin.Play();
        }

        
        //once the instruction button is clicked it calls and plays the instructions of the game
        private async void Instruction_Button_Clicked(object sender, EventArgs e)
        {
            var instruction = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("button_click_sound.mp3"));
            instruction.Play();
            await Navigation.PushAsync(new InstructionPage());
        }
        //once the Settings button is clicked it calls and produces the dark amd light mode button on that page
        private async void Setting_Button_Clicked(object sender, EventArgs e)
        {
            var setting = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("button_click_sound.mp3"));
            setting.Play();
            await Navigation.PushAsync(new Settings());
        }


    }
}
