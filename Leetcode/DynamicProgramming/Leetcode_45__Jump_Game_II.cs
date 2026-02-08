namespace Leetcode.DynamicProgramming;

public class Leetcode_45__Jump_Game_II
{
    public static int Jump(int[] nums)
    {
        int answer = 0;
        int currentEnd = 0;
        int currentFarthest = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            currentFarthest = Math.Max(currentFarthest, i + nums[i]);

            if (i == currentEnd)
            {
                answer++;
                currentEnd = currentFarthest;
            }
        }

        return answer;
    }
}
