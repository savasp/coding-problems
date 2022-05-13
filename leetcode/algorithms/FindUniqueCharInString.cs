namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// Find the unique character in a given string.
/// </summary>
public class UniqueCharInString {
    /// <summary>
    /// Returns the index (0-based) of the first
    // unique character in a string.
    public static int FindUniqueChar(string s) {
        var map = new Dictionary<char, int>();
        
        foreach (char c in s) {
            if (!map.ContainsKey(c)) {
                map.Add(c, 1);
            } else {
                map[c] += 1;
            }
        }

        for (int i = 0; i < s.Length; i++) {
            if (map[s[i]] == 1) {
                return i;
            }
        }
        
        return -1;
    }
}

/// --- Test infrastructure and test cases
///

public class UniqueCharInStringTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { "", -1 },
        new object[] { "a", 0 },
        new object[] { "aa", -1 },
        new object[] { "aaaaaaa", -1 },
        new object[] { "aaabaaaa", 3 },
        new object[] { "abbbbb", 0 },
        new object[] { "bbbbba", 5 },
        new object[] { "bbbbbadfdsgb", 5 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void FindUniqueCharInStringTest(string str, int expected)
    {
        var answer = UniqueCharInString.FindUniqueChar(str);

        Assert.Equal(answer, expected);
    }
}