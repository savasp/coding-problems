namespace Savas.Revision.DataStructures;

using Xunit;

/// <summary>
/// Clone a graph without reusing the given nodes.
/// </summary>
public class Graph
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public static Node Clone(Node node)
    {
        var map = new Dictionary<int, Node>();

        if (node == null) { return null; }

        return Clone(node, map);
    }

    private static Node Clone(Node node, Dictionary<int, Node> map)
    {
        if (map.ContainsKey(node.val))
        {
            return map[node.val];
        }

        var n = new Node(node.val);
        map[node.val] = n;
        foreach (var nn in node.neighbors)
        {
            n.neighbors.Add(Clone(nn, map));
        }

        return n;
    }
}


/// --- Test infrastructure and test cases
///

public class CloneGraphTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[][] { } },
        new object[] { new int[][] { new int[] { } } },
        new object[] { new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 1 } } },
        new object[] { new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } } },
        new object[] { new int[][] { new int[] { 1, 2 } } },
        new object[] { new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 } } },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void ClongGraphTest(int[][] adjacencies)
    {
        var graph = ToGraph(adjacencies);

        var answer = Graph.Clone(graph);

        Assert.True(IsClone(graph, answer));
        Assert.True(!ReuseNodes(graph, answer));
    }

    private Graph.Node ToGraph(int[][] adjacencies)
    {
        if (adjacencies.Length == 0 || adjacencies[0].Length == 0)
        {
            return null;
        }

        var nodes = new Dictionary<int, Graph.Node>();

        foreach(var edge in adjacencies)
        {
            if (!nodes.ContainsKey(edge[0]))
            {
                nodes.Add(edge[0], new Graph.Node(edge[0]));
            }

            if (!nodes.ContainsKey(edge[1]))
            {
                nodes.Add(edge[1], new Graph.Node(edge[1]));
            }

            nodes[edge[0]].neighbors.Add(nodes[edge[1]]);
            nodes[edge[1]].neighbors.Add(nodes[edge[0]]);
        }

        return nodes.First().Value;
    }

    private bool IsClone(Graph.Node graph1, Graph.Node graph2)
    {
        if (graph1 == null && graph2 == null)
        {
            return true;
        }

        var graph1Nodes = ToMap(graph1);
        var graph2Nodes = ToMap(graph2);

        foreach (var node in graph1Nodes)
        {
            if (!graph2Nodes.ContainsKey(node.Key))
            {
                return false;
            }

            var n1 = node.Value.neighbors.Select(node => node.val).OrderBy(n => n);
            var n2 = graph2Nodes[node.Key].neighbors.Select(node => node.val).OrderBy(n => n);
            if (!n1.SequenceEqual(n2))
            {
                return false;
            }
        }
        
        return true;
    }

    private bool ReuseNodes(Graph.Node graph1, Graph.Node graph2)
    {
        if (graph1 == null && graph2 == null)
        {
            return false;
        }

        var graph1Nodes = ToMap(graph1);
        var graph2Nodes = ToMap(graph2);

        foreach (var node in graph1Nodes)
        {
            var n1 = node.Value.neighbors.OrderBy(n => n.val);
            var n2 = graph2Nodes[node.Key].neighbors.OrderBy(n => n.val);
            if (!n1.Zip(n2).All(p => p.First != p.Second))
            {
                return true;
            }
        }

        return false;
    }

    private Dictionary<int, Graph.Node> ToMap(Graph.Node node)
    {
        var map = new Dictionary<int, Graph.Node>();

        ToMapDfs(node, map);

        return map;
    }

    private void ToMapDfs(Graph.Node node, Dictionary<int, Graph.Node> map)
    {
        if (!map.ContainsKey(node.val))
        {
            map.Add(node.val, node);
            foreach (var n in node.neighbors)
            {
                ToMapDfs(n, map);
            }
        }
    }
}