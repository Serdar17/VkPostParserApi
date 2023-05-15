using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VkPostParserApi.Data;
using VkPostParserApi.Models;
using VkPostParserApi.Options;

namespace VkPostParserApi.Repository;

public class OccurrenceLetterRepository : IOccurrenceLetterRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly VkPostsApiOption _option; 

    public OccurrenceLetterRepository(ApplicationDbContext dbContext, IOptions<VkPostsApiOption> optionsSnapshot)
    {
        _dbContext = dbContext;
        _option = optionsSnapshot.Value;
    }

    public async Task<OccurrenceLetter> AddAsync(string jsonResult)
    {
        var occurrenceLetter = new OccurrenceLetter()
        {
            OwnedId = _option.OwnedId,
            PostsCount = _option.PostsCount,
            Result = jsonResult
        };

        await _dbContext.OccurenceLetters.AddAsync(occurrenceLetter);
        await _dbContext.SaveChangesAsync();
        
        return occurrenceLetter;
    }

    public async Task<IEnumerable<OccurrenceLetter>> GetAllAsync()
    {
        return await _dbContext.OccurenceLetters.ToListAsync();
    }
}