namespace Savas.Revision.AlgoExpert;

using System.Collections.Generic;
using Xunit;

public class SubarrayMaxSum {

    // The subarray with the maximum sum.
    // Return the max sum.
	public static int MaxSum(int[] array) {
        // If an item in the array doesn't increase the sum
        // then we start a new subarray.

        if (array == null || array.Length == 0) {
            return int.MinValue;
        }

        int max = array[0];
        int maxInCurrentSequence = array[0];

        for (int i = 1; i < array.Length; i++) {
            maxInCurrentSequence = Math.Max(array[i], array[i] + maxInCurrentSequence);
            max = Math.Max(max, maxInCurrentSequence);
        }

        return max;
	}
}

/// --- Test infrastructure and test cases
/// 

public class SubarrayMaxSumTests
{
    public static IEnumerable<object[]> Data => new List<object[]> {
        new object[] { new int[] {3, 5, -4, 8, 11, 1, -1, 6}, 29},
        new object[] { new int[] {3, 5, -4, 8, 11, 1, -1, 6, -2}, 29},
        new object[] { new int[] {}, int.MinValue },
        new object[] { new int[] {6, 2, 0}, 8 },
        new object[] { new int[] {1, 2, -5}, 3 },
        new object[] { new int[] {1, -2, 5}, 5 },
        new object[] { new int[] {-1, -2}, -1 },
        new object[] { new int[] {-1, 3, -2}, 3 },
        new object[] { new int[] {-1}, -1 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void SubarrayMaxSumTest(int[] array, int expected) {
        var answer = SubarrayMaxSum.MaxSum(array);

        Assert.Equal(expected, answer);
    }
}