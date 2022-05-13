namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// Calculates the intersection of two arrays. The result must have unique
/// items and it can be in any order.
/// </summary>
public class IntersectionOfArrays {
    public static int[] Intersection(int[] nums1, int[] nums2) {
        var s1 = nums1.OrderBy(n => n).ToArray();
        var s2 = nums2.OrderBy(n => n).ToArray();
        var answer = new List<int>();
        
        for (int i = 0, j = 0; i < s1.Length && j < s2.Length;) {
            if (s1[i] == s2[j]) {
                if (answer.Count == 0 || (answer.Last() != s1[i])) {
                    answer.Add(s1[i]);
                }
                i++;
            } else if (s1[i] > s2[j]) {
                j++;
            } else {
                i++;
            }
        }
        return answer.ToArray();
    }
}

/// -- Test infrastructure and test cases
///

public class IntersectionOfArraysTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { }, new int[] { }, new int[] { } },
        new object[] { new int[] { 1 }, new int[] { }, new int[] { } },
        new object[] { new int[] { }, new int[] { 1 }, new int[] { } },
        new object[] { new int[] { 1 }, new int[] { 1 }, new int[] { 1 } },
        new object[] { new int[] { 1 }, new int[] { 1, 2 }, new int[] { 1 } },
        new object[] { new int[] { 1, 2, 3, 4 }, new int[] { 2, 3 }, new int[] { 2, 3 } },
        new object[] { new int[] { 1, 2, 2, 3, 3, 4 }, new int[] { 2, 3 }, new int[] { 2, 3 } },
        new object[] { new int[] { 1, 2, 2, 3, 3, 4 }, new int[] { 3, 2 }, new int[] { 2, 3 } },
        new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 2, 3, 5 }, new int[] { 2, 3, 5 } },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void IntersectionOfArraysTest(int[] a, int[] b, int[] expected)
    {
        var answer = IntersectionOfArrays.Intersection(a, b);

        Assert.True(answer.SequenceEqual(expected));
    }
}