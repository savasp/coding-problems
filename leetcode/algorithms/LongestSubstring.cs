namespace Savas.Revision.Algorithms;

using Xunit;

public class LongestSubstring {
    /// <summary>
    /// Identifies the length of the longest substring in the given string
    /// without any repeating characters.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <returns>The length of the longest substring.</returns>
    public static int Find(string str)
    {
        if (str.Length == 1) { return 1; }

        var max = 0;
        var map = new Dictionary<char, int>();
        for (int left = 0, right = 0; right < str.Length; right++)
        {
            if (map.ContainsKey(str[right]))
            {
                left = Math.Max(map[str[right]], left);
            }

            max = Math.Max(max, right - left + 1);
            map[str[right]] = right + 1;
        }

        return max;
    }
}

/// --- Test infrastructure and test cases
public class LongestSubstringTests
{
    public static List<object[]> Data => new List<object[]> {
        new object[] { "abc", 3 },
        new object[] { "abcabc", 3 },
        new object[] { "abcdac", 4 },
        new object[] { "a", 1 },
        new object[] { "aaaa", 1 },
        new object[] { "abaaaaaa", 2 },
        new object[] { "abcabcdaaaaaa", 4 },
    };

    [Theory]
    [MemberData(nameof(LongestSubstringTests.Data))]
    public void LongestSubstringTest(string str, int expected)
    {
        var answer = LongestSubstring.Find(str);

        Assert.Equal(answer, expected);
    }
}