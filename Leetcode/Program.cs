using Leetcode.BinarySearch;

namespace Leetcode;

internal class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 1, 1, 2, 2, 2, 2, 2, 3, 4, 5 };
        int target = 1;
        Leetcode_34__Find_First_And_Last_Position.SearchRange(nums, target);
    }
}
