namespace Savas.Revision.Algorithms;

using Xunit;

/// <summary>
/// Given a series of stock prices, determine what is the maximum profit.
/// </summary>
public class BestTimeToSellStocks
{
    public static int MaxProfit(int[] prices)
    {
        int max = 0;
        int low = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            low = Math.Min(low, prices[i]);

            max = Math.Max(max, prices[i] - low);
        }

        return max;
    }
}


/// -- Test infrastructure and test cases
///

public class BestTimeToSellStocksTests
{
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        new object[] { new int[] { 0, 2, 3, 5, 2, 3, 1 }, 5 },
        new object[] { new int[] { 0 }, 0 },
        new object[] { new int[] { 0, 1 }, 1 },
        new object[] { new int[] { 5, 3, 2 }, 0 },
        new object[] { new int[] { 3, 1, 3 }, 2 },
        new object[] { new int[] { 3, 1, 3, 5, 3, 1, 5, 3, 8 }, 7 },
        new object[] { new int[] { 3, 1, 3, 5, 3, 8, 5, 3, 7 }, 7 },
        new object[] { new int[] { 3, 1, 3, 5, 3, 8, 5, 15, 7 }, 14 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MaxProfit(int[] prices, int expected)
    {
        var answer = BestTimeToSellStocks.MaxProfit(prices);

        Assert.Equal(answer, expected);
    }
}