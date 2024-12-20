using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseCashBuilder
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionCashBuilder> Results { get; set; }
}
public class TriviaQuestionCashBuilder
{
    public string Type { get; set; }
    public string Difficulty { get; set; }
    public string Category { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string> IncorrectAnswers { get; set; }

    public string CleanedQuestion => System.Web.HttpUtility.HtmlDecode(Question);
}