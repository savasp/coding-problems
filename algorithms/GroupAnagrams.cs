namespace Savas.Revision.Algorithms;

using static System.Console;

public class GroupAnagramsExercise : IExercise {
    record Test(string[] strings, string[][] expected);
    public String Name => "Group anagrams";

    public void Start() {
        var tests = new Test[] {
            new Test(
                new string[] {"eat","tea","tan","ate","nat","bat"},
                new string[][] { new string[] {"bat"}, new string[] {"nat", "tan"}, new string[] {"ate", "eat", "tea"} }),
            new Test(new string[] { "" }, new string[][] { new string[] {""} }),
            new Test(new string[] { "a" }, new string[][] { new string[] {"a"} }),
        };

        for (int t = 0; t < tests.Length; t++) {
            var test = tests[t];
            
            var str = $"Test case {t}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            Log("Input", test.strings);
            WriteLine();

            string[][] answer = GroupAnagrams(test.strings);

            Log("Expected", test.expected);
            Log("Answer", answer);
        }
    }

    void Log(string header, string[][] stringGroups) {
        Write($"{header}: ");
        foreach (var g in stringGroups) {
            Log("", g);
        }
        WriteLine();
    }

    void Log(string header, string[] strings) {
        Write($"{header} {{ ");
        foreach (var s in strings) {
            Write($"{s} ");
        }
        Write("}");
    }

    string[][] GroupAnagrams(string[] strings) {
        var groups = new Dictionary<string, List<string>>();

        foreach (var s in strings) {
            var ss = new String(s.OrderBy(c => c).ToArray());
            if (!groups.ContainsKey(ss)) {
                groups[ss] = new List<string>();
            }
            
            groups[ss].Add(s);
        }

        return groups.Values.Select(l => l.ToArray()).ToArray();
    }
}