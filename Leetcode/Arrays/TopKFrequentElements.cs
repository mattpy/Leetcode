namespace Leetcode.Arrays;

public class TopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dict = new();

        foreach (int n in nums)
        {
            dict.TryGetValue(n, out int c);
            dict[n] = c + 1;
        }

        return dict
            .OrderByDescending(x => x.Value)
            .Take(k)
            .Select(x => x.Key)
            .ToArray();
    }

    public void Run()
    {
        var result = TopKFrequent([1, 1, 1, 2, 2, 3], 2);
        Console.WriteLine(result);
    }
}
