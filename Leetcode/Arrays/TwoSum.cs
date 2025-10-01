namespace Leetcode.Arrays;

internal class TwoSum
{
    public static int[] TwoSumImpl(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int remainder = target - nums[i];
            if (map.ContainsKey(remainder))
            {
                return new int[] { i, map[remainder]
    };
            }
            map[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}

