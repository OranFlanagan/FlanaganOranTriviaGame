using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceCashBuilder
{
    private readonly HttpClient _httpClient;
    public TriviaServiceCashBuilder()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TriviaResponseCashBuilder> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=20&category=9&difficulty=easy&type=multiple";
        int retryCount = 0;
        const int maxRetries = 4;
        const int delay = 1000;
        while (retryCount < maxRetries)
        {
            try
            {
                var triviaResponseCashBuilder = await _httpClient.GetFromJsonAsync<TriviaResponseCashBuilder>(url);
                return triviaResponseCashBuilder;
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