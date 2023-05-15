namespace VkPostParserApi.Infrastructure.Client;

public interface IVkPostClient
{
    public Task<HttpResponseMessage> GetPostsAsync();
}