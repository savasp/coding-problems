namespace Savas.Revision.Algorithms;

using Xunit;

public class RomanToInteger
{
    static Dictionary<char, int> map = new Dictionary<char, int>() {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    /// <summary>
    /// Converts the given roman number to an integer.
    /// </summary>
    /// <param name="str">The roman number. It is assumed that the given number
    /// is correct.</param>
    /// <returns>The integer representation of the roman number.</returns>
    public static int Convert(string str)
    {
        // Start from the back
        int number = map[str[str.Length - 1]];

        for (int i = str.Length - 2; i >= 0; i--)
        {
            if (map[str[i]] < map[str[i + 1]])
            {
                number -= map[str[i]];
            }
            else
            {
                number += map[str[i]];
            }
        }

        return number;
    }
}

/// -- Testing infrastructure and test cases
public class RomanToIntegerTests
{
    public static List<object[]> Data => new List<object[]>
    {
        new object[] { "V", 5 },
        new object[] { "III", 3 },
        new object[] { "LVIII", 58 },
        new object[] { "I", 1 },
        new object[] { "MCMXCIV", 1994 },
    };

    [Theory]
    [MemberData(nameof(RomanToIntegerTests.Data))]
    public void RomanToIntegerTest(string roman, int expected)
    {
        int answer = RomanToInteger.Convert(roman);

        Assert.Equal(answer, expected);
    }
}