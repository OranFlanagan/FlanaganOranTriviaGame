using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;
using Microsoft.Maui.Platform;
using Plugin.Maui.Audio;
using Microsoft.Maui.Graphics;
using System.Runtime.CompilerServices;

namespace FlanaganOranTriviaGame;

public partial class HigherOffer : ContentPage
{
    private int _currentQuestionIndex = 0;
    private string _correctAnswer;
    private int cashAmount = 150000;
    private readonly TriviaServiceHard HardQuestionService;
    private List<TriviaQuestionHard> HardQuestions;
    private readonly IAudioManager audioManager;
    public HigherOffer()
    {
        InitializeComponent();
        HardQuestionService = new TriviaServiceHard();
        LoadTrivia();
    }

    private async void LoadTrivia()
    {

        var triviaResponse = await HardQuestionService.FetchTriviaAsync();

        if (triviaResponse?.Results != null && triviaResponse.Results.Any())
        {
            HardQuestions = triviaResponse.Results;
            Console.WriteLine($"Loaded {HardQuestions.Count} questions.");
            ShowQuestion(_currentQuestionIndex);
        }

        else
        {
            await DisplayAlert("Error", "No trivia questions available.", "OK");
        }
    }

    private async void ShowQuestion(int index)
    {
        if (AnswerButton1 == null || AnswerButton2 == null || AnswerButton3 == null || QuestionLabel == null)
        {
            Console.WriteLine("No questions to show.");
            return;
        }
        if (HardQuestions == null || index < 0 || index >= HardQuestions.Count)
        {
            Console.WriteLine("No questions to show.");
            return;
        }

        var question = HardQuestions[index];
        Console.WriteLine($"Showing question: {question.question}");

        QuestionLabel.Text = System.Web.HttpUtility.HtmlDecode(question.question);

        var random = new Random();
        var selectedIncorrectAnswers = question.incorrect_answers?
            .OrderBy(x => random.Next())
            .Take(2)
            .ToList() ?? new List<string>();

        var answers = new List<string>(selectedIncorrectAnswers)
        {
            question.correct_answer
        };

        if(HardQuestions.Count == 5)
        {
            await DisplayAlert("Well Done", "You have made it through", "OK");
            DisplayResults();

        }
        answers = answers.OrderBy(x => random.Next()).ToList();
        Console.WriteLine($"Answers: {string.Join(", ", answers)}");

        if (answers.Count >= 3)
        {
            Console.WriteLine($"Assigning AnswerButton1: {answers[0]}");
            Console.WriteLine($"Assigning AnswerButton2: {answers[1]}");
            Console.WriteLine($"Assigning AnswerButton3:  {answers[2]}");

            AnswerButton1.Text = System.Web.HttpUtility.HtmlDecode(answers[0]);
            AnswerButton2.Text = System.Web.HttpUtility.HtmlDecode(answers[1]);
            AnswerButton3.Text = System.Web.HttpUtility.HtmlDecode(answers[2]);

            AnswerButton1.CommandParameter = answers[0] == question.correct_answer;
            AnswerButton2.CommandParameter = answers[1] == question.correct_answer;
            AnswerButton3.CommandParameter = answers[2] == question.correct_answer;

            Console.WriteLine($"AnswerButton1 Text: {AnswerButton1.Text}");
            Console.WriteLine($"AnswerButton2 Text: {AnswerButton2.Text}");
            Console.WriteLine($"AnswerButton3 Text: {AnswerButton3.Text}");
        }
        else
        {
            Console.WriteLine("Not enough answers to show.");
        }
    }

    public async void OnNextClicked(object sender, EventArgs e)
    {
        LoadNewQuestions(new List<Button> { AnswerButton1, AnswerButton2, AnswerButton3 });
        _currentQuestionIndex++;
        if (_currentQuestionIndex < HardQuestions.Count)
        {
            ShowQuestion(_currentQuestionIndex);
        }
    }
    private void OnAnswerClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is bool isCorrect)
        {
            Console.WriteLine($"Button text: {button.Text}, IsCorrect: {isCorrect}");
            if (isCorrect)
            {
                button.BackgroundColor = Colors.Green;
                if (button == Question1)
                    Question1.BackgroundColor = Colors.LightBlue;
                else if (button == Question2)
                    Question2.BackgroundColor = Colors.LightBlue;
                else if (button == Question3)
                    Question3.BackgroundColor = Colors.LightBlue;
                else if (button == Question4)
                    Question4.BackgroundColor = Colors.LightBlue;
                else if (button == Question5)
                    Question5.BackgroundColor = Colors.LightBlue;
                else if (button == Question6)
                    Question6.BackgroundColor = Colors.LightBlue;
            }
            else
            {
                button.BackgroundColor = Colors.Red;
            }
        }
    }

    private void ResetButtonColor(IEnumerable<Button> buttons)
    {
        foreach (var button in buttons)
        {
            button.BackgroundColor = Colors.Red;
        }
    }

    private void LoadNewQuestions(IEnumerable<Button> buttons)
    {
        ResetButtonColor(buttons);

        Console.WriteLine("New question loaded");
    }

    public class QuizData
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public string Correct { get; set; }
    }
    private async void DisplayResults()
    {
        _currentQuestionIndex = 0;
        await Navigation.PushAsync(new CashBuilder());
    }
}
