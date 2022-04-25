namespace Savas.Revision.Algorithms;

using Xunit;

public static class GroupAnagrams {
    /// <summary>
    /// Converts the input set of strings into a set of groups, with each
    /// group containing the strings that are anagrams of each other from
    /// the original set.
    /// </summary>
    /// <param name="strings">The set of strings from which to generate
    /// the anagram groups, if any.</param>
    /// <returns>The groups of strings that are anagrams of each other.</returns>
    public static string[][] Run(string[] strings) {
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

/// --- Test code and data.
public class GroupAnagramsTests {
    public static IEnumerable<object[]> Tests => new List<object[]> {
            new object[] {
                new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
                new string[][] { new string[] {"bat"}, new string[] {"nat", "tan"}, new string[] {"eat", "ate", "tea"} } },
            new object[] {
                new string[] { "" },
                new string[][] { new string[] {""} } },
            new object[] {
                new string[] { "a" },
                new string[][] { new string[] {"a"} } },
            new object[] {
                new string[] { "a", "b" },
                new string[][] { new string[] {"a"}, new string[] {"b"} } },
            new object[] {
                new string[] { "abe", "bea" },
                new string[][] { new string[] {"abe", "bea"} } },
            new object[] {
                new string[] { "abe", "bea", "tea" },
                new string[][] { new string[] {"abe", "bea"}, new string[] { "tea"} } },
            new object[] {
                new string[] { "abe", "bea", "tea", "sav" },
                new string[][] { new string[] { "tea"}, new string[] {"abe", "bea"}, new string[] { "sav" } } },
        };

    [Theory]
    [MemberData(nameof(GroupAnagramsTests.Tests))]
    public void EvaluateTest(string[] test, string[][] expected) {
        string[][] answer = GroupAnagrams.Run(test);

        // Log("answer  ", Sort(answer));
        // Log("expected", Sort(expected));

        Assert.True(GroupsAreEqual(answer, expected));
    }

    private bool GroupsAreEqual(IEnumerable<IEnumerable<string>> first, IEnumerable<IEnumerable<string>> second) {
        // Compare the sorted sequences
        var sf = Sort(first);
        var ss = Sort(second);

        return sf.Zip(ss).All(p => p.First.SequenceEqual(p.Second));
    }

    private IEnumerable<IEnumerable<string>> Sort(IEnumerable<IEnumerable<string>> groups) {
        var sorted = new List<(string key, List<string> group)>();
        foreach (var g in groups) {
            var sublist = new List<string>(g.OrderBy(gg => gg));
            var key = new String(sublist.SelectMany(s => s).ToArray());
            sorted.Add((key, sublist));
        }

        return sorted.OrderBy(kv => kv.key).Select(kv => kv.group);
    }

    void Log(string header, IEnumerable<IEnumerable<string>> stringGroups) {
        Console.Write($"{header}: ");
        foreach (var g in stringGroups) {
            Log("", g);
        }
        Console.WriteLine();
    }
    
    private void Log(string header, IEnumerable<string> strings) {
        Console.Write($"{header} {{ ");
        foreach (var s in strings) {
            Console.Write($"{s} ");
        }
        Console.Write("}");
    }
}
