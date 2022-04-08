namespace Savas.Revision.Algorithms;

using System.Text;

using static System.Console;

public class IntegerToRomanExercise : IExercise {
    record Test(int number, string expected);
    public String Name => "Roman to integer";

    public void Start() {
        var tests = new Test[] {
            new Test(3, "III"),
            new Test(58, "LVIII"),
            new Test(1, "I"),
            new Test(1994, "MCMXCIV"),
        };

        WriteLine("Convert the given integer to a roman number.");

        for (int t = 0; t < tests.Length; t++) {
            var test = tests[t];
            
            var str = $"Test case {t}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            WriteLine($"String: {test.number}");

            var answer = RomanToInteger(test.number);

            WriteLine($"Expected: {test.expected}, Answer: {answer}.");
            WriteLine(test.expected == answer ? "SUCCESS" : "FAILURE");
        }
    }

    string RomanToInteger(int number) {
        var romanLetters = new Dictionary<string, int>() {
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

        var romanValues = romanLetters.ToDictionary(p => p.Value, p => p.Key);
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
}