namespace Leetcode.SlidingWindow;

class Leetcode121_BestTimeToBuyAndSellStock
{
    public static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int minPrice = int.MaxValue;

        foreach (int price in prices)
        {
            minPrice = Math.Min(minPrice, price);
            maxProfit = Math.Max(maxProfit, price - minPrice);
        }

        return maxProfit;
    }

    public static void Run()
    {
        int result = MaxProfit([7, 1, 5, 3, 6, 4]);
        Console.WriteLine(result);
    }
}
