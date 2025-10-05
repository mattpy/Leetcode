namespace Leetcode.Arrays;

public class GroupAnagramsQuestion
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        return strs
            .GroupBy(x => string.Concat(x.OrderBy(c => c)))
            .Select(x => x.ToArray())
            .ToArray();
    }
}
