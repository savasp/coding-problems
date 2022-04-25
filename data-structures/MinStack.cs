namespace Savas.Revision.DataStructures;

using Xunit;

/// <summary>
/// A stack that can return the minimum value of its items in O(1).
/// If there are no items in the stack, an exception is thrown.
/// It maintains the minimum value at each item in the stack.
/// </summary>
public class MinStack
{
    class Item
    {
        public int Value { get; set; }
        public int MinValue { get; set; }
        public Item Next { get; set; }
    }

    private Item head = null;

    public MinStack()
    {

    }

    public void Push(int val)
    {
        var newItem = new Item { Value = val };

        if (head == null)
        {
            head = newItem;
            head.MinValue = val;
        }
        else
        {
            newItem.Next = head;
            newItem.MinValue = Math.Min(head.MinValue, val);
            head = newItem;
        }
    }

    public void Pop()
    {
        if (head != null)
        {
            head = head.Next;
        }
    }

    public int Top()
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }

        return head.Value;
    }

    public int GetMin()
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }

        return head.MinValue;
    }
}

/// -- Test infrastructure and test cases
///

public class MinStackTests
{
    public interface IOperation
    {
    }

    public class Push : IOperation
    {
        public int Value { get; set; }
    }

    public class Pop : IOperation
    {
    }

    public class GetMinValue : IOperation
    {
        public int Expected { get; set; }
    }

    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] {
            new IOperation[] {
                new Push { Value = 10 },
                new GetMinValue { Expected = 10 },
                new Push { Value = 10 },
                new Push { Value = 5 },
                new GetMinValue { Expected = 5 },
                new Push { Value = 1 },
                new GetMinValue { Expected = 1 },
                new Pop(),
                new GetMinValue { Expected = 5 },
                new Pop(),
                new GetMinValue { Expected = 10 },
            }
        },
        new object[] {
            new IOperation[] {
                new Push { Value = -10 },
                new GetMinValue { Expected = -10 },
                new Push { Value = 0 },
                new GetMinValue { Expected = -10 },
                new Push { Value = -20 },
                new GetMinValue { Expected = -20 },
                new Pop(),
                new GetMinValue { Expected = -10 },
            }
        },
        new object[] {
            new IOperation[] {
                new Push { Value = -10 },
                new Push { Value = -20 },
                new GetMinValue { Expected = -20 },
                new Pop(),
                new GetMinValue { Expected = -10 },
            }
        },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MinStackTestOperationSequences(IOperation[] operations)
    {
        var stack = new MinStack();

        foreach (var op in operations)
        {
            switch (op)
            {
                case Push p:
                    {
                        stack.Push(p.Value);
                        break;
                    }

                case Pop _:
                    {
                        stack.Pop();
                        break;
                    }

                case GetMinValue g:
                    {
                        var answer = stack.GetMin();
                        Assert.Equal(g.Expected, answer);
                        break;
                    }
            }
        }
    }
}
