namespace Savas.Revision.DataStructures;

using Xunit;

/// <summary>
/// Determines whether the two given trees are the same.
/// </summary>
public class SameTree
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.Value = val;
            this.Left = left;
            this.Right = right;
        }
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p != null && q != null)
        {
            return (p.Value == q.Value && IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right));
        }
        else
        {
            return p == q ? true : false;
        }
    }
}

/// -- Test infrastructure and test cases
///

public class SameTreeTests
{
    public record Node(int value, int left, int right);
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new Node[] { }, new Node[] { }, true },
        new object[] { new Node[] { new Node(0, -1, -1) }, new Node[] { }, false },
        new object[] { new Node[] { }, new Node[] { new Node(0, -1, -1) }, false },
        new object[] { new Node[] { new Node(0, -1, -1) }, new Node[] { new Node(0, -1, -1) }, true },
        new object[] { 
            new Node[] { new Node(0, 1, 2), new Node(1, -1, -1), new Node(2, -1, -1) },
            new Node[] { new Node(0, 1, 2), new Node(1, -1, -1), new Node(2, -1, -1) },
            true },
        new object[] {
            new Node[] { new Node(0, 1, -1), new Node(1, 2, -1), new Node(2, -1, -1) },
            new Node[] { new Node(0, 1, -1), new Node(1, 2, -1), new Node(2, -1, -1) },
            true },
        new object[] {
            new Node[] { new Node(0, 1, -1), new Node(1, 2, -1), new Node(2, -1, -1) },
            new Node[] { new Node(0, 2, -1), new Node(2, 1, -1), new Node(1, -1, -1) },
            false },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void SameTreeTest(Node[] tree1, Node[] tree2, bool expected)
    {
        var node1 = ToTree(tree1);
        var node2 = ToTree(tree2);

        var answer = SameTree.IsSameTree(node1, node2);

        Assert.Equal(expected, answer);
    }

    /// Assumes that the root of the tree has value 0.
    private SameTree.TreeNode ToTree(Node[] tree)
    {
        if (tree.Length == 0)
        {
            return null;
        }

        var map = new Dictionary<int, SameTree.TreeNode>();
        foreach (var n in tree)
        {
            if (!map.ContainsKey(n.value))
            {
                map[n.value] = new SameTree.TreeNode(n.value);
            }

            if (n.left != -1 && !map.ContainsKey(n.left))
            {
                map[n.left] = new SameTree.TreeNode(n.left);
            }

            if (n.right != -1 && !map.ContainsKey(n.right))
            {
                map[n.right] = new SameTree.TreeNode(n.right);
            }

            map[n.value].Left = n.left == -1 ? null : map[n.left];
            map[n.value].Right = n.right == -1 ? null : map[n.right];
        }

        return map[0];
    }
}