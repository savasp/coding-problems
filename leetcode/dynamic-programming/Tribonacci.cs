namespace Savas.Revision.DynamicProgramming;

using Xunit;

/// <summary>
/// Find the tribonnaci number for n
/// </summary>
public class Tribonacci
{
    public static int Get(int n)
    {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        int nm1 = 1;
        int nm2 = 1;
        int nm3 = 0;
        int t = 0;

        for (int i = 3; i <= n; i++)
        {
            t = nm1 + nm2 + nm3;
            nm3 = nm2;
            nm2 = nm1;
            nm1 = t;
        }

        return t;
    }
}

/// --- Test infrastructure and test cases
public class TribonacciTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { 4, 4 },
        new object[] { 1, 1 },
        new object[] { 0, 0 },
        new object[] { 2, 1 },
        new object[] { 25, 1389537 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void TribonacciTest(int n, int expected)
    {
        var answer = Tribonacci.Get(n);

        Assert.Equal(answer, expected);
    }
}
