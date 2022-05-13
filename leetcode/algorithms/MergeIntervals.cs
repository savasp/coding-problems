namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// Given an array of intervals, merge the overlapping ones.
/// (0, 1), (1, 2) => (0, 2)
/// (0, 4), (1, 2) => (0, 4)
/// </summary>
public class MergeIntervals {
    public static int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0 || intervals[0].Length == 0)
        {
            return intervals;
        }

        var sorted = intervals.OrderBy(interval => interval[0]).ToArray();
        
        var merged = new List<int[]>();
        merged.Add(sorted[0]);
        
        for (int i = 1; i < sorted.Length; i++) {
            if (merged.Last()[1] >= sorted[i][0]) {
                merged.Last()[1] = Math.Max(sorted[i][1], merged.Last()[1]);
            } else {
                merged.Add(sorted[i]);
            }
        }
        
        return merged.ToArray();
    }
}


/// --- Test infrastructure and test cases
///

public class MergeIntervalsTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[][] { new int[] { 0, 1 }}, new int[][] { new int[] { 0, 1 } } },
        new object[] { new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } }, new int[][] { new int[] { 0, 2 } } },
        new object[] { new int[][] { new int[] { 0, 4 }, new int[] { 1, 2 } }, new int[][] { new int[] { 0, 4 } } },
        new object[] { new int[][] { new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 3, 4 } }, new int[][] { new int[] { 0, 2 }, new int[] { 3, 4 } } },
        new object[] { new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 0, 1 } }, new int[][] { new int[] { 0, 2 }, new int[] { 3, 4 } } },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MergeIntervalsTest(int[][] intervals, int[][] expected)
    {
        var answer = MergeIntervals.Merge(intervals);

        Assert.Equal(expected.Length, answer.Length);
        Assert.True(answer.OrderBy(a => a[0]).SequenceEqual(expected.OrderBy(a => a[0]), new RangeComparer()));
    }

    [Fact]
    public void MergeEmptyIntervalsTest()
    {
        var answer = MergeIntervals.Merge(new int[][] { });
        Assert.Empty(answer);

        answer = MergeIntervals.Merge(new int[][] { new int[] { } });
        Assert.Empty(answer[0]);
    }

    public class RangeComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] p1, int[] p2)
        {
            return p1.Length == 2 && p2.Length == 2 && p1[0] == p2[0] && p1[1] == p2[1];
        }

        public int GetHashCode(int[] p1)
        {
            return p1.GetHashCode();
        }
    }
}