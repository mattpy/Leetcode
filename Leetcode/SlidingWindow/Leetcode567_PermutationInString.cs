namespace Leetcode.SlidingWindow;

class Leetcode567_PermutationInString
{
    public static bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> d1 = s1
            .Distinct()
            .ToDictionary(k => k, v => s1.Count(x => x == v));

        Dictionary<char, int> d2 = new();

        int k = s1.Length;
        int left = 0;

        for (int right = 0; right < s2.Length; right++)
        {
            char c = s2[right];
            d2.TryAdd(c, 0);
            d2[c]++;

            if (right >= k)
            {
                char leftChar = s2[left];
                d2[leftChar]--;

                if (d2[leftChar] == 0)
                    d2.Remove(leftChar);

                left++;
            }

            if (AreDictionariesEqual(d1, d2))
            {
                return true;
            }
        }

        return false;
    }

    private static bool AreDictionariesEqual<TKey, TValue>(
        Dictionary<TKey, TValue> d1,
        Dictionary<TKey, TValue> d2)
        where TKey : notnull
    {
        if (ReferenceEquals(d1, d2)) 
            return true;

        if (d1 is null || d2 is null)
            return false;

        if (d1.Count != d2.Count)
            return false;

        foreach (var (key, value) in d1)
        {
            if (!d2.TryGetValue(key, out var value2))
                return false;

            if (!EqualityComparer<TValue>.Default.Equals(value, value2))
                return false;
        }

        return true;
    }
}
