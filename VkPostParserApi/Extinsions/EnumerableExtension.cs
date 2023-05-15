namespace VkPostParserApi.Extinsions;

public static class EnumerableExtension
{
    public static SortedDictionary<char, int> OccurrenceLetters(this IEnumerable<char[]> letters)
    {
        var dictionary = new SortedDictionary<char, int>();
        
        foreach (var items in letters)
        {
            foreach (var ch in items)
            {
                if (!char.IsLetter(ch))
                    continue;
                if (!dictionary.ContainsKey(ch))
                    dictionary[ch] = 1;
                else
                    dictionary[ch] += 1;
            }
        }

        return dictionary;
    }
    
    public static SortedDictionary<char, int> OccurrenceLetters(this IEnumerable<char> symbols)
    {
        var dictionary = new SortedDictionary<char, int>();
        
        foreach (var ch in symbols)
        {
            if (!char.IsLetter(ch))
                continue;
            if (!dictionary.ContainsKey(ch))
                dictionary[ch] = 1;
            else
                dictionary[ch] += 1;
        }
        return dictionary;
    }
}