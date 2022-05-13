namespace Savas.Revision.DynamicProgramming;

using Xunit;

/// <summary>
/// Get the minimum cost of climbing the stairs. Each stair step has a cost.
/// One can only climb 1 or 2 steps at a time.
/// </summary>
public class MinCostClimbingStairs
{
    public static int Find(int[] stairs)
    {
        var map = new int[stairs.Length + 1];
        map[0] = 0;
        map[1] = 0;

        for (int i = 2; i <= stairs.Length; i++)
        {
            map[i] = Math.Min(stairs[i - 1] + map[i - 1], stairs[i - 2] + map[i - 2]);
        }

        return map[stairs.Length];
    }
}


/// --- Test infrastructure and test cases.
public class MinCostClimbingStairsTests {
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1}, 6},
        new object[] { new int[] { 10, 15, 20}, 15},
        new object[] { new int[] { 1, 100, 1}, 2},
        new object[] { new int[] { 100, 1, 1}, 1},
        new object[] { new int[] {3, 2, 1, 3}, 3 },
        new object[] { new int[] {2, 1}, 1},
        new object[] { new int[] {1, 2}, 1},
        new object[] { new int[] {2, 1, 1, 2}, 2}
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MinCostClimbingStairsTest(int[] stairs, int expected)
    {
        var answer = MinCostClimbingStairs.Find(stairs);

        Assert.Equal(answer, expected);
    }
}