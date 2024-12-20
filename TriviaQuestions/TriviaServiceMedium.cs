using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceMedium
{
    private readonly HttpClient _httpClient;
    public TriviaServiceMedium()
    {
        _httpClient = new HttpClient(); // Set up the tool to talk to the API
    }

    public async Task<TriviaResponseMedium> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=5&category=9&difficulty=medium&type=multiple"; // Replace with the actual API URL
        var triviaResponseMedium = await _httpClient.GetFromJsonAsync<TriviaResponseMedium>(url); // Fetch and parse JSON
        return triviaResponseMedium; // Return the trivia data
    }
}