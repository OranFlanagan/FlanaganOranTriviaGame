using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;
using Microsoft.Maui.Platform;
using Plugin.Maui.Audio;

namespace FlanaganOranTriviaGame;

public partial class HigherOffer : ContentPage
{
    private string _correctAnswer;
    private readonly TriviaServiceHard _CashBuilderService;
    private List<TriviaQuestionHard> _CashBuilderQuestions;
    public HigherOffer()
	{
		InitializeComponent();
        LoadQuizDataAsync();
	}

    private async void LoadQuizDataAsync()
    {
        try 
        { 
            var apiUrl = "https://opentdb.com/api.php?amount=6&category=9&difficulty=hard&type=multiple";
            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(apiUrl);

            var quizData = JsonSerializer.Deserialize<QuizData>(response);

            if (quizData != null)
            {
                QuestionLabel.Text = quizData.Question;
                AnswerButton1.Text = quizData.Answers[0];
                AnswerButton2.Text = quizData.Answers[1];
                AnswerButton3.Text = quizData.Answers[2];
                _correctAnswer = quizData.Correct;
            }
        }
        catch(Exception ex)  
        {
            await DisplayAlert("Error", $"Failed to load Quiz: {ex.Message}", "Ok");
        }
    }
    public async void OnAnswerClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var selectedAnswer = button.Text;
            FeedbackLabel.IsVisible = true;
            FeedbackLabel.Text = selectedAnswer == _correctAnswer
                ? "Correct!"
                : "Incorrect, try again.";
            FeedbackLabel.TextColor = selectedAnswer == _correctAnswer ? Colors.Green : Colors.Red;
        }

    }
    public class QuizData
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public string Correct { get; set; }
    }
    public async void OnNextClicked(object sender, EventArgs e)
    {

    }
}