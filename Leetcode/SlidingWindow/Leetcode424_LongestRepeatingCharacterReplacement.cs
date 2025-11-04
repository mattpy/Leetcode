namespace Leetcode.SlidingWindow;

public class Leetcode424_LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        Span<int> seen = stackalloc int[26];
        int maxFrequency = 0;
        int result = 0;

        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            int index = s[right] - 'A';
            seen[index]++;

            maxFrequency = Math.Max(maxFrequency, seen[index]);

            if ((right - left + 1) - maxFrequency > k)
            {
                int leftIndex = s[left] - 'A';
                seen[leftIndex]--;
                left++;
            }

            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
