namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// Adds two numbers represented as lists in reverse order.
/// Example: 243 is represented as a list: [3, 4, 2].
/// No leading zeros. Positive integers.
/// </summary>
public class AddTwoNumbersRepresentedAsLists
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

    public static ListNode Sum(ListNode l1, ListNode l2)
    {
        ListNode answer = new ListNode();
        ListNode prev = null;
        bool carryover = false;

        while (l1 != null || l2 != null)
        {
            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + (carryover ? 1 : 0);
            if (sum >= 10)
            {
                sum -= 10;
                carryover = true;
            }
            else
            {
                carryover = false;
            }

            l1 = l1?.next;
            l2 = l2?.next;

            if (prev == null)
            {
                answer.val = sum;
                prev = answer;
            }
            else
            {
                prev.next = new ListNode(sum);
                prev = prev.next;
            }
        }

        if (carryover)
        {
            prev.next = new ListNode(1);
        }

        return answer;
    }
}

public class AddTwoNumbersRepresentedAsListsTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 4321 + 4321 },
        new object[] { new int[] { 0 }, new int[] { 0 }, 0 },
        new object[] { new int[] { 0 }, new int[] { 1 }, 1 },
        new object[] { new int[] { 1 }, new int[] { 0 }, 1 },
        new object[] { new int[] { 1 }, new int[] { 1 }, 2 },
        new object[] { new int[] { 0, 1 }, new int[] { 1 }, 11 },
        new object[] { new int[] { 0, 1 }, new int[] { 0, 1 }, 20 },
        new object[] { new int[] { 1, 0, 1 }, new int[] { 1, 0, 1 }, 202 },
        new object[] { new int[] { 2, 3, 4 }, new int[] { 1 }, 433 },
        new object[] { new int[] { 9, 9 }, new int[] { 1 }, 100 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void AddTwoNumbersRepresentedAsListsTest(int[] n1, int[] n2, int expected)
    {
        var number1 = ToList(n1);
        var number2 = ToList(n2);

        var answerAsList = AddTwoNumbersRepresentedAsLists.Sum(number1, number2);
        var answer = ToNumber(answerAsList);

        Assert.Equal(answer, expected);
    }

    private AddTwoNumbersRepresentedAsLists.ListNode ToList(int[] number)
    {
        if (number.Length == 0) { return null; }

        var head = new AddTwoNumbersRepresentedAsLists.ListNode(number[0]);
        var tmp = head;
        for (int i = 1; i < number.Length; i++)
        {
            tmp.next = new AddTwoNumbersRepresentedAsLists.ListNode(number[i]);
            tmp = tmp.next;
        }

        return head;
    }

    private double ToNumber(AddTwoNumbersRepresentedAsLists.ListNode number)
    {
        if (number == null)
        {
            throw new ArgumentNullException(nameof(number));
        }

        int n = 0;
        double sum = 0;
        while (number != null)
        {
            sum += number.val * Math.Pow(10, n);
            n++;
            number = number.next;
        }

        return sum;
    }
}