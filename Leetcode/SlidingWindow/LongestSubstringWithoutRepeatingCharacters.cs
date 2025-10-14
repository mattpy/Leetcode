namespace Leetcode.SlidingWindow;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> seen = new();

        int left = 0;
        int max = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (seen.Contains(s[right]))
            {
                seen.Remove(s[left]);
                left++;
            }
            seen.Add(s[right]);

            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}
