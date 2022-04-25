namespace Savas.Revision.Algorithms;

using Xunit;

public class TwoSum
{
    /// <summary>
    /// Identifies the indexes in the array of the two numbers that add up
    /// to the given integer.
    /// </summary>
    /// <param name="target">The target sum.</param>
    /// <param name="numbers">The set of numbers.</param>
    /// <returns>The indexes of the two numbers that add up to the target number.
    /// (-1, -1) if no pair is identified.</returns>
    public static int[] Find(int target, int[] numbers)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            var x = target - numbers[i];
            if (map.ContainsKey(x))
            {
                return new int[] { map[x], i };
            }

            if (!map.ContainsKey(numbers[i]))
            {
                map.Add(numbers[i], i);
            }
        }

        return new int[] { -1, -1 };
    }
}

///--- Testing infrastrucutre and test cases
public class TwoSumTests
{
    public static List<object[]> Data => new List<object[]>
    {
        new object[] { 3, new int[] {1, 2, 3}, new int[] {0, 1} },
        new object[] { 1, new int[] {1, 2, 3}, new int[] {-1, -1} },
        new object[] { 2, new int[] {1, 1}, new int[] {0, 1} },
        new object[] { -3, new int[] {1, -2, -1}, new int[] {1, 2} },
        new object[] { -1, new int[] {0, -2, 1}, new int[] {1, 2} },
        new object[] { 4, new int[] {0, 1, 2, 1, 3, 6}, new int[] {1, 4} },
    };

    [Theory]
    [MemberData(nameof(TwoSumTests.Data))]
    public void TwoSumTest(int target, int[] numbers, int[] expected) {
        var answer = TwoSum.Find(target, numbers);

        Assert.True((answer[0] == expected[0]) && (answer[1] == expected[1]));
    }
}