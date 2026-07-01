namespace Leetcode.SlidingWindow;

public class Leetcode3_LongestSubstringWithoutRepeatingCharacters
{
    public static int LengthOfLongestSubstring(string s)
    {
        HashSet<char> seen = new();
        int maxLength = 0;
        int currentLength = 0;

        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char rightChar = s[right];

            while (seen.Contains(rightChar))
            {
                seen.Remove(s[left]);
                left++;
            }

            seen.Add(s[right]);

            currentLength = right - left + 1;
            maxLength = Math.Max(maxLength, currentLength);
        }

        return maxLength;
    }
}
