namespace Savas.Revision.DynamicProgramming;

using static System.Console;

public class MinCostClimbingStairsExercise : IExercise {
struct Test {
    public int[] stairs;
    public int expected;
}

    public String Name => "Min Cost Climbing Stairs";
    public void Start() {
        var tests = new Test[] {
            new Test { stairs = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1}, expected = 6},
            new Test { stairs = new int[] { 10, 15, 20}, expected = 15},
            new Test { stairs = new int[] { 1, 100, 1}, expected = 2},
            new Test { stairs = new int[] { 100, 1, 1}, expected = 1},
            new Test { stairs = new int[] {3, 2, 1, 3}, expected = 3 },
            new Test { stairs = new int[] {2, 1}, expected = 1},
            new Test { stairs = new int[] {1, 2}, expected = 1},
            new Test { stairs = new int[] {2, 1, 1, 2}, expected = 2}
        };

        WriteLine("What is the minimum cost for climbing the stairs?");

        var i = 0;
        foreach (var test in tests) {
            var str = $"Test case {i++}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            test.stairs.ToList().ForEach(i => Write(i + " "));
            WriteLine();

            var min = iterative(test.stairs);
            WriteLine($"Using the iterative function, the min cost for climbing the stairs is {min}");
            WriteLine(min != test.expected ? "Failed!!!" : "Passed!");

        }
    }

    int iterative(int[] stairs) {
        var map = new int[stairs.Length + 1];
        map[0] = 0;
        map[1] = 0;

        for (int i = 2; i <= stairs.Length; i++) {
            map[i] = Math.Min(stairs[i - 1] + map[i - 1], stairs[i - 2] + map[i - 2]);
        }

        return map[stairs.Length];
    }
}