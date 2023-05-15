using System.Globalization;
using Microsoft.Extensions.Options;
using VkPostParserApi.Options;

namespace VkPostParserApi.Infrastructure.Client;

public class VkPostClient : IVkPostClient  
{
    private readonly HttpClient _httpClient;
    private readonly VkPostsApiOption _vkPostsOption;

    public VkPostClient(HttpClient httpClient, IOptions<VkPostsApiOption> optionsSnapshot)
    {
        _httpClient = httpClient;
        _vkPostsOption = optionsSnapshot.Value;
    }
    public async Task<HttpResponseMessage> GetPostsAsync()
    {
        var uriBuilder = new UriBuilder($"{_vkPostsOption.BaseUrl}?v={_vkPostsOption.ApiVersion.ToString("0.000", CultureInfo.InvariantCulture)}&" +
                                        $"access_token={_vkPostsOption.AccessToken}&owner_id={_vkPostsOption.OwnedId}&" +
                                        $"count={_vkPostsOption.PostsCount}");
        
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        var httpResponseMessage = await _httpClient.SendAsync(request);
        return httpResponseMessage;
    }
}