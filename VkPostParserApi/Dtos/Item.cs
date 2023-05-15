using System.Text.Json.Serialization;

namespace VkPostParserApi.Dtos;

public class Item
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}