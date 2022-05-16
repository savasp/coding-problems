namespace Savas.Revision.AlgoExpert;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class TwoSum {

    // There is at most one pair of integers that adds up to the target sum.
    // If no pair exists, return an empty array.
    // You can't add a number at an index twice.
    // Assume that a number appears only once.
	public static int[] TwoNumberSum(int[] array, int targetSum) {
		
        // Find an integer at i so that targetSum - array[i] == y.

        // Index all the numbers in the array. <number, position in array>
        var map = new Dictionary<int, int>();
        for (int i = 0; i < array.Length; i++) {
            map.Add(array[i], i);
        }

        for (int i = 0; i < array.Length; i++) {
            var y = targetSum - array[i];

            if (map.ContainsKey(y) && map[y] != i) {
                return new int[2] {y, array[i]};
            }
        }

    	return new int[0];
	}
}

/// --- Test infrastructure and test cases
/// 

public class TwoSumTests
{
    public static IEnumerable<object[]> Data => new List<object[]> {
        new object[] { new int[] {3, 5, -4, 8, 11, 1, -1, 6}, 10, new int[] {-1, 11} },
        new object[] { new int[] {}, 10, new int[] {} },
        new object[] { new int[] {1, 2}, 10, new int[] {} },
        new object[] { new int[] {1, 2}, 3, new int[] {1, 2} },
        new object[] { new int[] {1, 2, 3}, 3, new int[] {1, 2} },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void TwoSumTest(int[] array, int targetSum, int[] expected) {
        var answer = TwoSum.TwoNumberSum(array, targetSum);

        Assert.Equal(expected.OrderBy(x => x), answer.OrderBy(x => x));
    }
}
