namespace Savas.Revision.Algorithms;

using System.Text;
using Xunit;

using static System.Console;

public class IntegerToRoman {

    private static Dictionary<string, int> RomanLetters = new Dictionary<string, int>() {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
            { "CM", 900 },
            { "CD", 400 },
            { "XC", 90 },
            { "XL", 40 },
            { "IX", 9 },
            { "IV", 4 },
        };

    /// <summary>
    /// Converts the given integer to a roman number.
    /// </summary>
    /// <param name="number">The number to convert.</param>
    /// <returns>The string representation of the roman number.</returns>
    public static string Convert(int number) {

        var romanValues = RomanLetters.ToDictionary(p => p.Value, p => p.Key);
        var values = romanValues.Keys.OrderByDescending(k => k).ToArray();

        var sb = new StringBuilder();
        var i = 0;
        while (number > 0) {
            int n = number / values[i];
            if (n == 0) {
                i++;
            } else {
                for (int j = 0; j < n; j++) {
                    sb.Append(romanValues[values[i]]);
                }
                number -= n * values[i];
            }
        }

        return sb.ToString();
    }

    /// --- Test infrastructure and test cases
    public class IntegerToRomanTests {

        public static IEnumerable<object[]> Data => new List<object[]> {
            new object[] { 3, "III" },
            new object[] { 58, "LVIII" },
            new object[] { 1, "I" },
            new object[] { 1994, "MCMXCIV" },
        };

        [Theory]
        [MemberData(nameof(IntegerToRomanTests.Data))]
        void IntegerToRomanTest(int number, string expected) {
            var answer = IntegerToRoman.Convert(number);

            Assert.Equal(answer, expected);
        }
    }
}