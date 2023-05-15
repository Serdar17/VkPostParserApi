using Ardalis.Result;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using VkPostParserApi.Models;
using VkPostParserApi.Options;

namespace VkPostParserApi.Infrastructure.Services;

public class CachedVkPostsParserService : IVkPostsParserService
{
    private readonly IVkPostsParserService _service;
    private readonly IMemoryCache _memoryCache;
    private readonly VkPostsApiOption _vkPostsOption;

    public CachedVkPostsParserService(IVkPostsParserService service, IMemoryCache memoryCache, 
        IOptions<VkPostsApiOption> optionsSnapshot)
    {
        _service = service;
        _memoryCache = memoryCache;
        _vkPostsOption = optionsSnapshot.Value;
    }

    public async Task<Result<OccurrenceLetter>> GetParsedPostsAsync()
    {
        return (await _memoryCache.GetOrCreateAsync(_vkPostsOption.OwnedId, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.GetParsedPostsAsync();
        }))!;
    }
    
    public async Task<Result<IEnumerable<OccurrenceLetter>>> GetAllAsync()
    {
        return (await _memoryCache.GetOrCreateAsync(_vkPostsOption.OwnedId + _vkPostsOption.PostsCount, 
            async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.GetAllAsync();
        }))!;
    }
}