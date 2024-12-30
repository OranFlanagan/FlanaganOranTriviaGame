using Microsoft.Maui.Dispatching;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using FlanaganOranTriviaGame.TriviaQuestions;
using Microsoft.Maui.Platform;
using Plugin.Maui.Audio;
using System.ComponentModel;
using Microsoft.Maui.Graphics;

namespace FlanaganOranTriviaGame;

public partial class LowerOffer : ContentPage
{
    private readonly TriviaServiceEasy _CashBuilderService;
    private List<TriviaQuestionEasy> _CashBuilderQuestions;
    private int _currentQuestionIndex = 0;

    public LowerOffer()
    {
        InitializeComponent();
        _CashBuilderService = new TriviaServiceEasy();
        LoadTrivia();
    }

    private async void LoadTrivia()
    {
        var triviaResponse = await _CashBuilderService.FetchTriviaAsync();

        if (triviaResponse?.Results != null && triviaResponse.Results.Any())
        {
            _CashBuilderQuestions = triviaResponse.Results;
            Console.WriteLine($"Loaded {_CashBuilderQuestions.Count} questions.");
            ShowQuestion(_currentQuestionIndex);
        }

        else
        {
            await DisplayAlert("Error", "No trivia questions available.", "OK");
        }
    }

    private void ShowQuestion(int index)
    {
        if (AnswerButton1 == null || AnswerButton2 == null || AnswerButton3 == null || QuestionLabel == null)
        {
            Console.WriteLine("No questions to show.");
            return;
        }
        if (_CashBuilderQuestions == null || index < 0 || index >= _CashBuilderQuestions.Count)
        {
            Console.WriteLine("No questions to show.");
            return;
        }

        var question = _CashBuilderQuestions[index];
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


    private void OnNextClicked(object sender, EventArgs e)
    {
        LoadNewQuestions(new List<Button> { AnswerButton1, AnswerButton2, AnswerButton3 });
        _currentQuestionIndex++;
        if (_currentQuestionIndex < _CashBuilderQuestions.Count)
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

    private async void DisplayResults()
    {
        _currentQuestionIndex = 0;
        await Navigation.PushAsync(new TheChase());
    }
}
