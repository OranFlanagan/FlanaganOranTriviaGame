namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseHard
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionHard> Results { get; set; }
}

public class TriviaQuestionHard
{
    public string type { get; set; }
    public string difficulty { get; set; }
    public string category { get; set; }
    public string question { get; set; }
    public string correct_answer { get; set; }
    public List<string> incorrect_answers { get; set; }
}
