namespace Savas.Revision.DataStructures;

using Xunit;

public class MergeTwoSortedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public static ListNode Merge(ListNode list1, ListNode list2)
    {
        var head = new ListNode(-1);

        var curr = head;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                curr.next = list1;
                list1 = list1.next;
            }
            else
            {
                curr.next = list2;
                list2 = list2.next;
            }

            curr = curr.next;
        }

        curr.next = list1 ?? list2;

        return head.next;
    }
}

public class MergeTwoSortedListsTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { }, new int[] { }, new int[] { } },
        new object[] { new int[] { 1 }, new int[] { }, new int[] { 1 } },
        new object[] { new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 } },
        new object[] { new int[] { }, new int[] { 1 }, new int[] { 1 } },
        new object[] { new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 } },
        new object[] { new int[] { 2, 3, 4 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 2, 3, 3, 4 } },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MergeTwoSortedListsTest(int[] list1, int[] list2, int[] expected)
    {
        var l1 = ToList(list1);
        var l2 = ToList(list2);

        var answer = MergeTwoSortedLists.Merge(l1, l2);

        Assert.True(ToArray(answer).SequenceEqual(expected));
    }

    private MergeTwoSortedLists.ListNode ToList(int[] list)
    {
        if (list.Length == 0)
        {
            return null;
        }

        var head = new MergeTwoSortedLists.ListNode(list[0]);
        var tmp = head;
        for (int i = 1; i < list.Length; i++)
        {
            tmp.next = new MergeTwoSortedLists.ListNode(list[i]);
            tmp = tmp.next;
        }

        return head;
    }

    private int[] ToArray(MergeTwoSortedLists.ListNode node)
    {
        var list = new List<int>();
        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }

        return list.ToArray();
    }
}