using System.Text.Json.Serialization;

namespace VkPostParserApi.Dtos;

public class Response
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }
}