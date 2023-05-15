using System.ComponentModel.DataAnnotations.Schema;

namespace VkPostParserApi.Models;

public class OccurrenceLetter
{
    public int Id { get; set; }
    
    public int OwnedId { get; set; }

    public int PostsCount { get; set; }
    
    [Column(TypeName = "jsonb")]
    public string Result { get; set; }
}