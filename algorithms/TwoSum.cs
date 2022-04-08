namespace Savas.Revision.Algorithms;

using static System.Console;

static class Extensions {
    public static String MapToString(this int[] array) => array.Select(i => i + " ").Aggregate((str, i) => (str + i));
}

public class TwoSumExercise : IExercise {
    record Test(int target, int[] numbers, int[] expected);
    public String Name => "Two Sum";

    public void Start() {
        var tests = new Test[] {
            new Test(3, new int[] {1, 2, 3}, new int[] {0, 1}),
            new Test(1, new int[] {1, 2, 3}, new int[] {-1, -1}),
            new Test(2, new int[] {1, 1}, new int[] {0, 1}),
            new Test(-3, new int[] {1, -2, -1}, new int[] {0, 2}),
            new Test(-1, new int[] {0, -2, 1}, new int[] {1, 2}),
            new Test(4, new int[] {0, 1, 2, 1, 3, 6}, new int[] {1, 4}),
        };

        WriteLine("What are the indexes of the two array elements that add up to X.");

        for (int i = 0; i < tests.Length; i++) {
            var test = tests[i];
            
            var str = $"Test case {i}";
            WriteLine();
            WriteLine(str);
            WriteLine(new String('.', str.Length));

            Write($"Target: {test.target}, Numbers: ");
            WriteLine(test.numbers.MapToString());

            int[] solution = TwoSum(test.target, test.numbers);

            WriteLine($"Expected: {test.expected.MapToString()}, Solution: {solution.MapToString()}.");
            WriteLine(test.expected.OrderBy(i => i).SequenceEqual(solution.OrderBy(i => i)) ? "SUCCESS" : "FAILURE");
        }
    }

    int[] TwoSum(int target, int[] numbers) {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++) {
            var x = target - numbers[i];
            if (map.ContainsKey(x)) {
                return new int[] { map[x], i };
            }

            if (!map.ContainsKey(numbers[i])) {
                map.Add(numbers[i], i);
            }
        }

        return new int[] { -1, -1 };
    }
}