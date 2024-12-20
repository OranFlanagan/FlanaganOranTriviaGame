using FlanaganOranTriviaGame.TriviaQuestions;
using System.ComponentModel;
using System.Timers;

namespace FlanaganOranTriviaGame;

public partial class CashBuilder : ContentPage
{
    private readonly TriviaServiceCashBuilder _CashBuilderService;
    private List<TriviaQuestionCashBuilder> _CashBuilderQuestions;
    private int _currentQuestionIndex = 0;
    public int cashBuilder = 0;
    private System.Timers.Timer _timer; // Specify the full namespace
    private bool _isTimeUp = false;
    public CashBuilder()
    {
        InitializeComponent();
        _CashBuilderService = new TriviaServiceCashBuilder();
        StartTimer();
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
        if (_CashBuilderQuestions == null || index < 0 || index >= _CashBuilderQuestions.Count)
        {
            return;
        }
        AnswerButton1.Text = string.Empty;
        AnswerButton2.Text = string.Empty;
        AnswerButton3.Text = string.Empty;

        var question = _CashBuilderQuestions[index];
        Console.WriteLine($"Showing question: {question.Question}");

        QuestionLabel.Text = System.Web.HttpUtility.HtmlDecode(question.Question);

        var random = new Random();
        var selectedIncorrectAnswers = question.IncorrectAnswers?
            .OrderBy(x => random.Next())
            .Take(2)
            .ToList() ?? new List<string>();

        var answers = new List<string>(selectedIncorrectAnswers)
                {
                    question.CorrectAnswer
                };

        answers = answers.OrderBy(x => random.Next()).ToList();

        if (answers.Count >= 3)
        {
            Console.WriteLine($"AnswerButton1 Text: {answers[0]}");
            Console.WriteLine($"AnswerButton2 Text: {answers[1]}");
            Console.WriteLine($"AnswerButton3 Text: {answers[2]}");

            AnswerButton1.Text = System.Web.HttpUtility.HtmlDecode(answers[0]);
            AnswerButton2.Text = System.Web.HttpUtility.HtmlDecode(answers[1]);
            AnswerButton3.Text = System.Web.HttpUtility.HtmlDecode(answers[2]);

            AnswerButton1.CommandParameter = answers[0] == question.CorrectAnswer;
            AnswerButton2.CommandParameter = answers[1] == question.CorrectAnswer;
            AnswerButton3.CommandParameter = answers[2] == question.CorrectAnswer;
        }
    }


    private void OnNextClicked(object sender, EventArgs e)
    {
        if (_isTimeUp)
        {
            return;
        }
        _currentQuestionIndex++;
        if (_currentQuestionIndex < _CashBuilderQuestions.Count)
        {
            ShowQuestion(_currentQuestionIndex);
        }
    }


    private void OnAnswerClicked(object sender, EventArgs e)
    {
        AnswerButton1.Clicked += OnAnswerClicked;
        AnswerButton2.Clicked += OnAnswerClicked;
        AnswerButton3.Clicked += OnAnswerClicked;

        if (sender is Button button && button.CommandParameter is bool isCorrect)
        {
            Console.WriteLine($"Button text: {button.Text}, IsCorrect: {isCorrect}");
            if (isCorrect)
            {
                button.BackgroundColor = Colors.Green;
                cashBuilder += 1000;
            }
            else
            {
                button.BackgroundColor = Colors.Red;
            }
            if (_isTimeUp)
            {
                Console.WriteLine("Time's up!");
                return;
            }
        }
    }

    private void StartTimer()
    {
        _timer = new System.Timers.Timer(60000);
        _timer.Elapsed += OnTimeUp;
        _timer.AutoReset = false;
        _timer.Start();
    }
    private void OnTimeUp(object sender, ElapsedEventArgs e)
    {
        _isTimeUp = true;
        _timer.Stop();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            DisplayResults();
        });
    }

    private async void DisplayResults()
    {
        await DisplayAlert("Time's up!", $"You earned {cashBuilder}Pounds!", "OK");

        _currentQuestionIndex = 0;
        cashBuilder = 0;
        _isTimeUp = false;
        await Navigation.PushAsync(new TheChase());
    }
}

