namespace Savas.Revision.Algorithms;

using static System.Console;

public class RomanToIntegerExercise : IExercise {
    record Test(string str, int expected);
    public String Name => "Roman to integer";

    public void Start() {
        var tests = new Test[] {
            new Test("III", 3),
            new Test("LVIII", 58),
            new Test("I", 1),
            new Test("MCMXCIV", 1994),
        };

        WriteLine("Convert the given roman number to an integer.?");

        for (int t = 0; t < tests.Length; t++) {
            var test = tests[t];
            
            var str = $"Test case {t}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            WriteLine($"String: {test.str}");

            int answer = RomanToInteger(test.str);

            WriteLine($"Expected: {test.expected}, Answer: {answer}.");
            WriteLine(test.expected == answer ? "SUCCESS" : "FAILURE");
        }
    }

    int RomanToInteger(string str) {
        var map = new Dictionary<char, int>() {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        // Start from the back
        int number = map[str[str.Length - 1]];

        for (int i = str.Length - 2; i >= 0; i--) {
            if (map[str[i]] < map[str[i + 1]]) {
                number -= map[str[i]];
            } else {
                number += map[str[i]];
            }
        }

        return number;
    }
}