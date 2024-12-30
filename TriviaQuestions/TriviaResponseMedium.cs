using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseMedium
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionMedium> Results { get; set; }
}

public class TriviaQuestionMedium
{
    public string type { get; set; }
    public string difficulty { get; set; }
    public string category { get; set; }
    public string question { get; set; }
    public string correct_answer { get; set; }
    public List<string> incorrect_answers { get; set; }
}