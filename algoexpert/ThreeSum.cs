namespace Savas.Revision.AlgoExpert;

using System.Collections.Generic;
using System.Linq;
using Xunit;

public class ThreeSum {

    // Find the triplets of integers that add up to the target sum.
    // If no triplet exists, return an empty one.
    // You can't add a number at an index twice.
    // Use a number only once.
	public static List<int[]> ThreeNumberSum(int[] array, int targetSum) {
        var answer = new List<int[]>();
        if (array.Length < 3) {
            return answer;
        }

        // Sort the array.
        var sorted = array.OrderBy(x => x).ToArray();

        for (int i = 0; i < array.Length - 2; i++) {
            
            var left = i + 1;
            var right = sorted.Length - 1;

            while (left < right) {
                var sum = sorted[i] + sorted[left] + sorted[right];
                if (targetSum == sum) {
                    answer.Add(new int[] { sorted[i], sorted[left], sorted[right] });
                    left++;
                    right--;
                } else if (targetSum > sum) {
                    left++;
                } else {
                    right--;
                }
            }
        }

    	return answer;
	}
}

/// --- Test infrastructure and test cases
/// 

public class ThreeSumTests
{
    public static IEnumerable<object[]> Data => new List<object[]> {
        new object[] { new int[] {3, 5, -4, 8, 11, 1, -1, 6}, 4, new int[][] {new int[] {3, 5, -4} } },
        new object[] { new int[] {}, 10, new int[][] {} },
        new object[] { new int[] {6, 2, 0}, 8, new int[][] {new int[] {6, 2, 0}} },
        new object[] { new int[] {1, 2, 5}, 8, new int[][] {new int[] {1, 2, 5}} },
        new object[] { new int[] {1, 2, 5}, 10, new int[][] {} },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void TwoSumTest(int[] array, int targetSum, int[][] expected) {
        var answer = ThreeSum.ThreeNumberSum(array, targetSum);

        Assert.Equal(expected, answer, new TripletComparer());
    }
}

public class TripletComparer : IEqualityComparer<int[]> {
    public bool Equals(int[] t1, int[] t2) => t1.OrderBy(x => x).SequenceEqual(t2.OrderBy(x => x));
    public int GetHashCode(int[] t) => t.GetHashCode();
}
