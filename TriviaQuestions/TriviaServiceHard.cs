using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceHard
{
    private readonly HttpClient _httpClient;

    public TriviaServiceHard()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TriviaResponseHard> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=10&category=9&difficulty=hard&type=multiple";
        var triviaResponseHard = await _httpClient.GetFromJsonAsync<TriviaResponseHard>(url);
        return triviaResponseHard;
    }
}