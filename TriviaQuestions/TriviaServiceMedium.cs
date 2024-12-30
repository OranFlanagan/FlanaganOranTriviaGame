using System.Net.Http.Json;
namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceMedium
{
    private readonly HttpClient _httpClient;
    public TriviaServiceMedium()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TriviaResponseMedium> FetchTriviaAsync()
    {
        var url = "https://opentdb.com/api.php?amount=5&category=9&difficulty=medium&type=multiple";
        int retryCount = 0;
        const int maxRetries = 3;
        const int delay = 1000;
        while (retryCount < maxRetries)
        {
            try
            {
                var triviaResponseMedium = await _httpClient.GetFromJsonAsync<TriviaResponseMedium>(url);
                return triviaResponseMedium;
            }
            catch (Exception ex)
            {
                retryCount++;
                await Task.Delay(delay);
            }
        }
        return null;
    }
}
