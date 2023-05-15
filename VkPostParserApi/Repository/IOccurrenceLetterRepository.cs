using VkPostParserApi.Models;

namespace VkPostParserApi.Repository;

public interface IOccurrenceLetterRepository
{
    Task<OccurrenceLetter> AddAsync(string jsonResult);

    Task<IEnumerable<OccurrenceLetter>> GetAllAsync();
}