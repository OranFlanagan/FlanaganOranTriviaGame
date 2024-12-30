using System.Net.Http.Json;

namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceEasy
{
    private readonly HttpClient _httpClient;

    public TriviaServiceEasy()
    {
        _httpClient = new HttpClient(); // Set up the tool to talk to the API
    }

    public async Task<TriviaResponseEasy> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple"; // Replace with the actual API URL
        var triviaResponseEasy = await _httpClient.GetFromJsonAsync<TriviaResponseEasy>(url); // Fetch and parse JSON
        return triviaResponseEasy; // Return the trivia data
    }
}