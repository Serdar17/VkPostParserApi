using System.Text.Json.Serialization;

namespace VkPostParserApi.Dtos;

public class SuccessResponse
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}