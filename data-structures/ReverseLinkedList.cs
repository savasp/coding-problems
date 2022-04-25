namespace Savas.Revision.DataStructures;

using Xunit;

public class ReverseLinkedList
{
    public class ListNode
    {
        public int Value;
        public ListNode Next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.Value = val;
            this.Next = next;
        }
    }
    public static ListNode ReverseList(ListNode node)
    {
        ListNode save = null;
        ListNode previous = null;
        while (node != null)
        {
            save = node.Next;
            node.Next = previous;
            previous = node;
            node = save;
        }

        return previous;
    }
}

/// --- Test infrastructure and test cases
///

public class ReverseLinkedListTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { }, new int[] { } },
        new object[] { new int[] { 1 }, new int[] { 1 } },
        new object[] { new int[] { 0, 1 }, new int[] { 1, 0 } },
        new object[] { new int[] { 0, 1, 2 }, new int[] { 2, 1, 0 } },
        new object[] { new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1, 0 } }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void ReverseLinkedListTest(int[] list, int[] expected)
    {
        // Create list from array
        var node = ToList(list);

        var answer = ReverseLinkedList.ReverseList(node);

        // Create array from list
        var answerList = new List<int>();
        while (answer != null)
        {
            answerList.Add(answer.Value);
            answer = answer.Next;
        }

        Assert.True(answerList.SequenceEqual(expected));
    }

    private ReverseLinkedList.ListNode ToList(int[] list)
    {
        if (list.Length == 0)
        {
            return null;
        }

        var head = new ReverseLinkedList.ListNode(list[0]);
        var tmp = head;
        for (int i = 1; i < list.Length; i++)
        {
            tmp.Next = new ReverseLinkedList.ListNode(list[i]);
            tmp = tmp.Next;
        }

        return head;
    }
}