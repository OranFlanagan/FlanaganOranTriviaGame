namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseHard
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionHard> Results { get; set; }
}

public class TriviaQuestionHard
{
    public string Type { get; set; }
    public string Difficulty { get; set; }
    public string Category { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string> IncorrectAnswers { get; set; }
}
