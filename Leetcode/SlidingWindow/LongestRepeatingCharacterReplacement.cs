namespace Leetcode.SlidingWindow;

public class LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        Span<int> freq = stackalloc int[26];
        int result = 0;
        int left = 0;
        int maxFrequency = 0;

        for (int right = 0; right < s.Length; right++)
        {
            int index = s[right] - 'A';
            freq[index]++;

            maxFrequency = Math.Max(maxFrequency, freq[index]);

            while ((right - left + 1) - maxFrequency > k)
            {
                int leftIndex = s[left] - 'A';
                freq[leftIndex]--;
                left++;
            }

            result = right - left + 1;
        }

        return result;
    }
}
