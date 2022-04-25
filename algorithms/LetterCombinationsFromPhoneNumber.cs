namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// Given a string of digits, generate the possible strings that
/// can be formed given the letter assignments on a phone keyboard.
public class LetterCombinationsFromPhoneNumber
{
    private static Dictionary<char, string[]> map = new Dictionary<char, string[]> {
        { '2', new string[] { "a", "b", "c" } },
        { '3', new string[] { "d", "e", "f" } },
        { '4', new string[] { "g", "h", "i" } },
        { '5', new string[] { "j", "k", "l" } },
        { '6', new string[] { "m", "n", "o" } },
        { '7', new string[] { "p", "q", "r", "s" } },
        { '8', new string[] { "t", "u", "v" } },
        { '9', new string[] { "w", "x", "y", "z" } },
    };

    public static IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new string[] { };

        var answer = new List<string>();
        LetterCombinations(digits, answer);

        return answer;
    }

    private static void LetterCombinations(string digits, List<string> answer)
    {
        if (digits.Length == 1)
        {
            answer.AddRange(map[digits[0]]);
        }
        else
        {
            foreach (var str in LetterCombinations(digits.Substring(1)))
            {
                for (int i = 0; i < map[digits[0]].Length; i++)
                {
                    answer.Add(map[digits[0]][i] + str);
                }
            }
        }
    }
}


/// --- Test infrastructure and test cases
///

public class LetterCombinationsFromPhoneNumberTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { "", new string[] {} },
        new object[] { "2", new string[] {"a", "b", "c" } },
        new object[] { "23", new string[] {"ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" } },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void LetterCombinationsFromPhoneNumberTest(string digits, IEnumerable<string> expected)
    {
        var answer = LetterCombinationsFromPhoneNumber.LetterCombinations(digits);

        Assert.True(answer.OrderBy(a => a).SequenceEqual(expected.OrderBy(a => a)));
    }
}