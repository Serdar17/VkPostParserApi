using NUnit.Framework;
using NUnit.Framework.Internal;
using VkPostParserApi.Extinsions;

namespace VkPostParserApi.Tests;

public class OccurrenceLettersTests
{
    [Test]
    public void TestOccurrenceLetterExtension_SomeTexts_ReturnOccurrenceLetters()
    {
        var lines = new List<string> { "first text", "second text" };
        var actualResult = lines.Select(x => x.ToLower().ToCharArray()).OccurrenceLetters();
        var expectedDictionary = new Dictionary<char, int>()
        {
            { 'c', 1 },
            { 'd', 1 },
            { 'e', 3 },
            { 'f', 1 },
            { 'i', 1 },
            { 'n', 1 },
            { 'o', 1 },
            { 'r', 1 },
            { 's', 2 },
            { 't', 5 },
            { 'x', 2 },
        };
        Assert.That(actualResult, Is.EqualTo(expectedDictionary));
    }
    
}