using Ardalis.Result;
using VkPostParserApi.Models;

namespace VkPostParserApi.Infrastructure.Services;

public interface IVkPostsParserService
{
    public Task<Result<OccurrenceLetter>> GetParsedPostsAsync();

    public Task<Result<IEnumerable<OccurrenceLetter>>> GetAllAsync();
}