using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceHard
{
    private readonly HttpClient _httpClient;

    public TriviaServiceHard()
    {
        _httpClient = new HttpClient(); // Set up the tool to talk to the API
    }

    public async Task<TriviaResponseHard> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=6&category=9&difficulty=hard&type=multiple"; // Replace with the actual API URL
        var triviaResponseHard = await _httpClient.GetFromJsonAsync<TriviaResponseHard>(url); // Fetch and parse JSON
        return triviaResponseHard; // Return the trivia data
    }
}