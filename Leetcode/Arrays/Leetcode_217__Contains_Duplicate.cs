using System.Numerics;

namespace Leetcode.Arrays;

internal class Leetcode_217__Contains_Duplicate
{
    public static bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> seen = [.. nums];
        return seen.Count == nums.Length;
    }

    public static void Run()
    {
        var result1 = ContainsDuplicate([1, 2, 3, 1]);
        Console.WriteLine(result1);

        var result2 = ContainsDuplicate([1, 2, 3, 4]);
        Console.WriteLine(result2);

        var result3 = ContainsDuplicate([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]);
        Console.WriteLine(result3);
    }
}
