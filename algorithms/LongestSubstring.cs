namespace Savas.Revision.Algorithms;

using static System.Console;

public class LongestSubstringExercise : IExercise {
    record Test(string str, int expected);
    public String Name => "Longest Substring";

    public void Start() {
        var tests = new Test[] {
            new Test("abc", 3),
            new Test("abcabc", 3),
            new Test("abcdac", 4),
            new Test("a", 1),
            new Test("aaaa", 1),
            new Test("abaaaaaa", 2),
            new Test("abcabcdaaaaaa", 4),
        };

        WriteLine("What is the longest substring without any repeating characters?");

        for (int t = 0; t < tests.Length; t++) {
            var test = tests[t];
            
            var str = $"Test case {t}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            WriteLine($"String: {test.str}");

            int answer = LongestSubstring(test.str);

            WriteLine($"Expected: {test.expected}, Answer: {answer}.");
            WriteLine(test.expected == answer ? "SUCCESS" : "FAILURE");
        }
    }

    int LongestSubstring(string str) {
        if (str.Length == 1) { return 1; }
        
        var max = 0;
        var map = new Dictionary<char, int>();
        for (int left = 0, right = 0; right < str.Length; right++) {
            if (map.ContainsKey(str[right])) {
                left = Math.Max(map[str[right]], left);
            }
            
            max = Math.Max(max, right - left + 1);
            map[str[right]] = right + 1;
        }

        return max;
    }
}