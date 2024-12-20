namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseEasy
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionEasy> Results { get; set; }
}


public class TriviaQuestionEasy
{
     public string Type { get; set; }
     public string Difficulty { get; set; }
     public string Category { get; set; }
     public string Question { get; set; }
     public string CorrectAnswer { get; set; }
     public List<string> IncorrectAnswers { get; set; }
}