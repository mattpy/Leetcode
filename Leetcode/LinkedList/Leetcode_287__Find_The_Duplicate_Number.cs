namespace Leetcode.LinkedList;

public class Leetcode_287__Find_The_Duplicate_Number
{
    public static int FindDuplicate(int[] nums)
    {
        int slow = nums[0];
        int fast = nums[0];

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = nums[0];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return fast;
    }
}
