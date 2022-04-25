namespace Savas.Revision.DataStructures;

using Xunit;

/// <summary>
/// Find the maximum depth of the given binary tree
/// <summary>
public static class MaximumDepthOfBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static int MaxDepth(TreeNode root)
    {
        if (root == null) { return 0; }

        // Just do a DFS on the tree to calculate the maximum depth.
        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}


/// --- Test infrastructure and test cases
///

public class MaximumDepthOfBinaryTreeTests
{
    public record Edge(int root, int left, int right);
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new List<Edge> {}, 0 },
        new object[] { new List<Edge> { new Edge(0, 1, 2) }, 2 },
        new object[] { new List<Edge> { new Edge(0, 1, 2), new Edge(1, 3, 4), new Edge(2, 5, 6) }, 3},
        new object[] { new List<Edge> { new Edge(0, 1, 2), new Edge(1, 3, 4), new Edge(2, 5, 6), new Edge(5, 7, 8) }, 4},
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MaximumDepthOfBinaryTreeTest(List<Edge> edges, int expected)
    {
        var tree = ToTree(edges);

        var answer = MaximumDepthOfBinaryTree.MaxDepth(tree);

        Assert.Equal(expected, answer);
    }

    public void MaximumDepthOfBinaryTreeSingleNodeTest(List<Edge> edges, int expected)
    {
        var answer = MaximumDepthOfBinaryTree.MaxDepth(new MaximumDepthOfBinaryTree.TreeNode(0));

        Assert.Equal(1, answer);
    }

    /// Assumes that the edges represent a binary tree with the root's value being 0.
    private MaximumDepthOfBinaryTree.TreeNode ToTree(IEnumerable<Edge> edges)
    {
        if (edges.Count() == 0)
        {
            return null;
        }

        var map = new Dictionary<int, MaximumDepthOfBinaryTree.TreeNode>();
        foreach (var e in edges)
        {
            if (!map.ContainsKey(e.root))
            {
                map[e.root] = new MaximumDepthOfBinaryTree.TreeNode(e.root);
            }

            if (!map.ContainsKey(e.left))
            {
                map[e.left] = new MaximumDepthOfBinaryTree.TreeNode(e.left);
            }

            if (!map.ContainsKey(e.right))
            {
                map[e.right] = new MaximumDepthOfBinaryTree.TreeNode(e.right);
            }

            map[e.root].left = map[e.left];
            map[e.root].right = map[e.right];
        }

        return map[0];
    }
}