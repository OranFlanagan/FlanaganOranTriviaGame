using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseCashBuilder
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionCashBuilder> Results { get; set; }
}
public class TriviaQuestionCashBuilder
{
    public string type { get; set; }
    public string difficulty { get; set; }
    public string category { get; set; }
    public string question { get; set; }
    public string correct_answer { get; set; }
    public List<string> incorrect_answers { get; set; }

    public string CleanedQuestion => System.Web.HttpUtility.HtmlDecode(question);
}