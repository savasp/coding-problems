namespace Savas.Revision.DynamicProgramming;

using static System.Console;

public class HouseRobberExercise : IExercise {
    struct Test {
        public int[] houses;
        public int expected;
    }

    public String Name => "House Robber";
    public void Start() {
        var tests = new Test[] {
            new Test { houses = new int[] {4, 3, 1, 2, 5, 6, 8}, expected = 20 },
            new Test { houses = new int[] {3, 2, 1, 3}, expected = 6 },
            new Test { houses = new int[] {2, 1}, expected = 2},
            new Test { houses = new int[] {1, 2}, expected = 2},
            new Test { houses = new int[] {2, 1, 1, 2}, expected = 4}
        };

        WriteLine("What is the maximum you can get from these houses?");

        var i = 0;
        foreach (var test in tests) {
            var str = $"Test case {i++}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            test.houses.ToList().ForEach(i => Write(i + " "));
            WriteLine();

            // Recursive
            var map = Enumerable.Repeat(-1, test.houses.Length).ToArray();
            var max = recursiveWithArray(test.houses, test.houses.Length - 1, map);
            WriteLine($"Using the recursive function, the max you can get is {max}");
            WriteLine(max != test.expected ? "Failed!!!" : "Passed!");

            // Iterative
            max = iterative(test.houses);
            WriteLine($"Using the iterative function, the max you can get is {max}");
            WriteLine(max != test.expected ? "Failed!!!" : "Passed!");

        }
    }

    int recursiveWithArray(int[] houses, int i, int[] map) {
        if (i == 0) {
            return houses[0];
        }

        if (i == 1) {
            return Math.Max(houses[0], houses[1]);
        }

        if (map[i - 2] == -1) {
            map[i - 2] = recursiveWithArray(houses, i - 2, map);
        }

        if (map[i - 1] == -1) {
            map[i - 1] = recursiveWithArray(houses, i - 1, map);
        }

        var option1 = houses[i] + map[i - 2];
        var option2 = map[i - 1];

        return Math.Max(option1, option2);
    }

    int recursiveWithDictionary(int[] houses, int i, IDictionary<int, int> map) {
        if (i == 0) {
            return houses[0];
        }

        if (i == 1) {
            return Math.Max(houses[0], houses[1]);
        }

        if (!map.ContainsKey(i - 2)) {
            map.Add(i - 2, recursiveWithDictionary(houses, i - 2, map));
        }

        if (!map.ContainsKey(i - 1)) {
            map.Add(i - 1, recursiveWithDictionary(houses, i - 1, map));
        }

        var option1 = houses[i] + map[i - 2];
        var option2 = map[i - 1];

        return Math.Max(option1, option2);
    }

    int iterative(int[] houses) {
        if (houses.Length == 1) return houses[0];

        var map = new int[houses.Length];
        map[0] = houses[0];
        map[1] = Math.Max(houses[0], houses[1]);

        for (int i = 2; i < houses.Length; i++) {
            map[i] = Math.Max(map[i - 1], houses[i] + map[i - 2]);
        }

        return map[map.Length - 1];
    }
}