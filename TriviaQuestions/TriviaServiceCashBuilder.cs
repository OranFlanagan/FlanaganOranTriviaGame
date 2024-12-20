using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceCashBuilder
{
    private readonly HttpClient _httpClient;
    public TriviaServiceCashBuilder()
    {
        _httpClient = new HttpClient(); // Set up the tool to talk to the API
    }

    public async Task<TriviaResponseCashBuilder> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=20&category=9&difficulty=easy&type=multiple"; // Replace with the actual API URL
        int retryCount = 0;
        const int maxRetries = 3;
        const int delay = 1000;
        while (retryCount < maxRetries)
        {
            try
            {
                var triviaResponseCashBuilder = await _httpClient.GetFromJsonAsync<TriviaResponseCashBuilder>(url); // Fetch and parse JSON
                return triviaResponseCashBuilder; // Return the trivia data
            }
            catch (Exception ex)
            {
                retryCount++;
                await Task.Delay(delay);
            }
        }

        throw new Exception("Failed to fetch trivia questions");
    }
}