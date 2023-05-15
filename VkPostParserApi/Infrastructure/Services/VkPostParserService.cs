using System.Text;
using Ardalis.Result;
using Newtonsoft.Json;
using VkPostParserApi.Dtos;
using VkPostParserApi.Extinsions;
using VkPostParserApi.Infrastructure.Client;
using VkPostParserApi.Models;
using VkPostParserApi.Repository;

namespace VkPostParserApi.Infrastructure.Services;

public class VkPostParserService : IVkPostsParserService
{
    private readonly IVkPostClient _client;
    private readonly ILogger<VkPostParserService> _logger;
    private readonly IOccurrenceLetterRepository _repository;

    public VkPostParserService(IVkPostClient client, ILogger<VkPostParserService> logger, IOccurrenceLetterRepository repository)
    {
        _client = client;
        _logger = logger;
        _repository = repository;
    }

    public async Task<Result<OccurrenceLetter>> GetParsedPostsAsync()
    {
        var response = await _client.GetPostsAsync();
        var result = await ParseResponse<SuccessResponse>(response);

        var json = ParsePosts(result.Value.Response.Items.Select(x => x.Text.ToLower().ToCharArray()));

        var occurrenceLetter = await _repository.AddAsync(json);
            
        return occurrenceLetter;
    }

    public async Task<Result<IEnumerable<OccurrenceLetter>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        
        return Result.Success(result);
    }


    private string ParsePosts(IEnumerable<char[]> letters)
    {
        _logger.LogInformation("The beginning of counting the number of occurrences of the list.");
        
        var dictionary = letters.OccurrenceLetters();

        _logger.LogInformation("End counting the number of occurrences, result is  {@Result}", dictionary);
        
        return JsonConvert.SerializeObject(dictionary);
    }
    
    private async Task<Result<TResponse>> ParseResponse<TResponse>(HttpResponseMessage response)
    {
        try
        {
            response.EnsureSuccessStatusCode();
            var successResponse = await response.Content.ReadFromJsonAsync<TResponse>();
            if (successResponse is null)
            {
                _logger.LogInformation("Something went wrong. Check your \'access_token\' or \'owned_id\'");
                
                return Result.Error("Something went wrong. Check your \'access_token\' or \'owned_id\'");
            }
            _logger.LogInformation("ParseResponse the method was executed successfully");
            return Result.Success(successResponse);
        }
        catch (HttpRequestException e)
        {
            _logger.LogInformation("Status code the request was not successful");
            
            return Result.Error(e.Message);
        }
    }
}