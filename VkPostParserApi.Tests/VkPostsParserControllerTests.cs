using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using VkPostParserApi.Models;

namespace VkPostParserApi.Tests;

public class VkPostsParserControllerTests
{
    private WebApplicationFactory<Program> _webHost;
    private HttpClient _client;
    
    [SetUp]
    public void Setup()
    {
        _webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
        _client = _webHost.CreateClient();
    }

    [TestCase("api/VkPostParser/get-occurrence-letters", HttpStatusCode.OK)]
    public async Task CheckStatus_SendRequest_ShouldReturnOk(string path, HttpStatusCode statusCode)
    {
        var uri = new Uri(_client.BaseAddress, path);

        var response = await _client.GetAsync(uri);
        
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }

    [TestCase("api/VkPostParser/get-occurrence-letters", -6214974, 5)]
    public async Task CheckLocationData_SendRequestToSuggest_ShouldReturnActualLocationsData(string path, int ownedId,
        int postsCount)
    {
        var uri = new Uri(_client.BaseAddress, path);
        
        var response = await _client.GetAsync(uri);
        
        var responseObj = await response.Content.ReadFromJsonAsync<OccurrenceLetter>();

        Assert.That(responseObj.OwnedId, Is.EqualTo(ownedId));
        Assert.That(responseObj.PostsCount, Is.EqualTo(postsCount));
        
        Assert.That(responseObj.Result, Is.Not.Empty);
    }
}