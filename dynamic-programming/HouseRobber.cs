namespace Savas.Revision.DynamicProgramming;

using Xunit;

/// <summary>
/// Calculates the max a robber can steal from a set of houses
/// without visiting two neighboring houses. The given array
/// contains the money that can be stolen from the given house.
/// </summary>
public class HouseRobber
{
    public static int FindUsingRecursionWithArray(int[] houses)
    {
        var map = new int[houses.Length];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = -1;
        }

        return FindUsingRecursionWithArray(houses, houses.Length - 1, map);
    }

    static int FindUsingRecursionWithArray(int[] houses, int i, int[] map)
    {
        if (i == 0)
        {
            return houses[0];
        }

        if (i == 1)
        {
            return Math.Max(houses[0], houses[1]);
        }

        if (map[i - 2] == -1)
        {
            map[i - 2] = FindUsingRecursionWithArray(houses, i - 2, map);
        }

        if (map[i - 1] == -1)
        {
            map[i - 1] = FindUsingRecursionWithArray(houses, i - 1, map);
        }

        var option1 = houses[i] + map[i - 2];
        var option2 = map[i - 1];

        return Math.Max(option1, option2);
    }

    public static int FindUsingRecursionWithDictionary(int[] houses)
    {
        return FindUsingRecursionWithDictionary(houses, houses.Length - 1, new Dictionary<int, int>());
    }

    static int FindUsingRecursionWithDictionary(int[] houses, int i, IDictionary<int, int> map)
    {
        if (i == 0)
        {
            return houses[0];
        }

        if (i == 1)
        {
            return Math.Max(houses[0], houses[1]);
        }

        if (!map.ContainsKey(i - 2))
        {
            map.Add(i - 2, FindUsingRecursionWithDictionary(houses, i - 2, map));
        }

        if (!map.ContainsKey(i - 1))
        {
            map.Add(i - 1, FindUsingRecursionWithDictionary(houses, i - 1, map));
        }

        var option1 = houses[i] + map[i - 2];
        var option2 = map[i - 1];

        return Math.Max(option1, option2);
    }

    public static int FindUsingIteration(int[] houses)
    {
        if (houses.Length == 1) return houses[0];

        var map = new int[houses.Length];
        map[0] = houses[0];
        map[1] = Math.Max(houses[0], houses[1]);

        for (int i = 2; i < houses.Length; i++)
        {
            map[i] = Math.Max(map[i - 1], houses[i] + map[i - 2]);
        }

        return map[map.Length - 1];
    }
}


/// --- Test infrastructure and test cases
/// 
public class HouseRobberTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] {4, 3, 1, 2, 5, 6, 8}, 18 },
        new object[] { new int[] {3, 2, 1, 3}, 6 },
        new object[] { new int[] {2, 1}, 2},
        new object[] { new int[] {1, 2}, 2},
        new object[] { new int[] {5, 3, 2, 2}, 7},
        new object[] { new int[] {2, 5, 5, 3}, 8},
        new object[] { new int[] {2, 1, 1, 2}, 4},
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void RecursionWithArray(int[] houses, int expected)
    {
        var answer = HouseRobber.FindUsingRecursionWithArray(houses);

        Assert.Equal(answer, expected);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void RecursionWithDictionary(int[] houses, int expected)
    {
        var answer = HouseRobber.FindUsingRecursionWithDictionary(houses);

        Assert.Equal(answer, expected);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void RecursionWithIteration(int[] houses, int expected)
    {
        var answer = HouseRobber.FindUsingIteration(houses);

        Assert.Equal(answer, expected);
    }
}