namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary<>
/// Calculate the median of two sorted arrays
/// </summary>
public class MedianOfTwoSortedArrays {
    /// The arrays are quaranteed to be non-empty.
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var merged = new int[nums1.Length + nums2.Length];
        
        var n = nums1.Length + nums2.Length;
        int m = 0, k = 0;
        for (int i = 0; i < n; i++) {
            if (m < nums1.Length && k < nums2.Length) {
                if (nums1[m] < nums2[k]) {
                    merged[i] = nums1[m++];
                } else {
                    merged[i] = nums2[k++];
                }
            } else {
                if (m < nums1.Length) {
                    merged[i] = nums1[m++];
                } else {
                    merged[i] = nums2[k++];
                }
            }
        }
        
        if (n == 1) return merged[0];
        if ((n % 2) == 0) {
            return (merged[n / 2 - 1] + merged[n / 2]) / 2.0;
        } else {
            return merged[n / 2];
        }
    }
}


/// -- Test infrastructure and test cases
///

public class MedianOfTwoSortedArraysTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { 0 },  new int[] { 0 }, 0},
        new object[] { new int[] { 1, 2 },  new int[] { 4, 5 }, 3},
        new object[] { new int[] { 1, 2, 3 },  new int[] { 4, 5 }, 3},
        new object[] { new int[] { 1, 2},  new int[] { 3 }, 2},
        new object[] { new int[] { 1, 2, 5, 6},  new int[] { 3 }, 3},
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MedianOfTwoSortedArraysTest(int[] a1, int[] a2, int expected)
    {
        var answer = MedianOfTwoSortedArrays.FindMedianSortedArrays(a1, a2);

        Assert.Equal(expected, answer);
    }
}