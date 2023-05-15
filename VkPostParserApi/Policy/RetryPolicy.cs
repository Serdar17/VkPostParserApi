using System.Net;
using Polly;
using Serilog;

namespace VkPostParserApi.Policy;

public static class RetryPolicy
{
    private const int MaxRetries = 5;
    
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(x => x.StatusCode != HttpStatusCode.OK)
            .WaitAndRetryAsync(MaxRetries, attempt =>
            {
                Log.Information($"Происходит {attempt} запрос");
                return TimeSpan.FromMilliseconds(100 * attempt);
            });
    }
}