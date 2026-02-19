namespace Leetcode.BinarySearch;

public class Leetcode_34__Find_First_And_Last_Position
{
    public static int[] SearchRange(int[] nums, int target)
    {
        int leftIndex = LeftMostBinarySearch(nums, target);

        if (leftIndex == nums.Length || nums[leftIndex] != target)
        {
            return [-1, -1];
        }

        int rightIndex = LeftMostBinarySearch(nums, target + 1);

        return [leftIndex, rightIndex - 1];
    }

    private static int LeftMostBinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length;

        while (left < right)
        {
            int mid = ((right - left) / 2) + left;

            if (target <= array[mid])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}
