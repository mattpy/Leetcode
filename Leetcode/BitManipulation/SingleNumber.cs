namespace Leetcode.BitManipulation;

public class SingleNumber
{
    public static int FindSingleNumber(int[] nums)
    {
        // The XOR operator is communative and associative
        // [2, 3, 2] can be rearranged to (2 ^ 2) ^ 3 = 0 ^ 3 = 3
        int a = 0;
        foreach (int n in nums)
        {
            a ^= n;
        }
        return a;
    }

    public static void Run()
    {
        int result = FindSingleNumber([2, 2, 1]);
        Console.WriteLine(result);
    }
}
