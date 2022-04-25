namespace Savas.Revision.DataStructures;

using Xunit;

public class PathInGraph
{
    /// <summary>
    /// Checks if the path between the two given nodes is valid in a non-directed
    /// graph.
    /// </summary>
    /// <param name="n">The number of nodes in the graph.</param>
    /// <param name="edges">The edges in the graph 0-indexed.</param>
    /// <param name="source">The start node.</param>
    /// <param name="destination">The destination node.</param>
    /// <returns></returns>
    public static bool IsValidPath(int n, int[][] edges, int source, int destination)
    {
        if (!(n > 0))
        {
            return false;
        }

        if (source == destination)
        {
            return true;
        }

        var adjacencies = new Dictionary<int, List<int>>();
        var visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            adjacencies.Add(i, new List<int>());
            visited[i] = false;
        }

        foreach (var e in edges)
        {
            adjacencies[e[0]].Add(e[1]);
            adjacencies[e[1]].Add(e[0]);
        }

        return Dfs(source, destination, adjacencies, visited);
    }

    private static bool Dfs(int node, int destination, Dictionary<int, List<int>> adjastencies, bool[] visited)
    {
        if (visited[node]) return false;
        visited[node] = true;
        if (node == destination) return true;

        foreach (var e in adjastencies[node])
        {
            if (Dfs(e, destination, adjastencies, visited)) return true;
        }

        return false;
    }
}

/// --- Test infrastructure and test cases
///

public class FindPathInGraphTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { 0, new int[][] { }, 0, 1, false},
        new object[] { 1, new int[][] { }, 0, 0, true },
        new object[] { 2, new int[][] { }, 0, 1, false },
        new object[] { 1, new int[][] { new int[] { 0, 0 } }, 0, 0, true },
        new object[] { 2, new int[][] { new int[] { 0, 1 } }, 0, 1, true },
        new object[] { 3, new int[][] { new int[] { 0, 1 } }, 0, 2, false },
        new object[] { 3, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } }, 0, 2, true },
        new object[] { 3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } }, 0, 2, true },
        new object[] { 4, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 1, 3 } }, 2, 3, true },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void IsValidPathTest(int n, int[][] edges, int source, int destination, bool expected)
    {
        var answer = PathInGraph.IsValidPath(n, edges, source, destination);

        Assert.Equal(answer, expected);
    }
}