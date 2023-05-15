namespace VkPostParserApi.Options;

public class VkPostsApiOption
{
    public const string Section = "VkPostsApi";
    
    public string BaseUrl { get; set; } = string.Empty;

    public string AccessToken { get; set; } = string.Empty;

    public int OwnedId { get; set; }

    public int PostsCount { get; set; }
    
    public double ApiVersion { get; set; }
}