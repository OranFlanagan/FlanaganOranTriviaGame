namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseEasy
{
    public int ResponseCode { get; set; }
    public List<TriviaQuestionEasy> Results { get; set; }
}


public class TriviaQuestionEasy
{
     public string type { get; set; }
     public string difficulty { get; set; }
     public string category { get; set; }
     public string question { get; set; }
     public string correct_answer { get; set; }
     public List<string> incorrect_answers { get; set; }
}