using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseMedium
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionMedium> Results { get; set; }
}

public class TriviaQuestionMedium
{
    public string Type { get; set; }
    public string Difficulty { get; set; }
    public string Category { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string> IncorrectAnswers { get; set; }
}