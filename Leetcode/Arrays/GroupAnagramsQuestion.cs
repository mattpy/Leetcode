namespace Leetcode.Arrays;

public class GroupAnagramsQuestion
{
    public IList<IList<string>> GroupAnagramsLinq(string[] strs)
    {
        return strs
            .GroupBy(x => string.Concat(x.OrderBy(c => c)))
            .Select(x => x.ToArray())
            .ToArray();
    }

    public IList<IList<string>> GroupAnagramsDict(string[] strs)
    {
        Dictionary<string, List<string>> dict = new();

        foreach (string s in strs)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);

            string key = new string(chars);

            dict.TryAdd(key, new());
            dict[key].Add(s);
        }

        return dict.Values.ToArray();
    }

    public void Run()
    {
        GroupAnagramsDict(["eat", "tea", "tan", "ate", "nat", "bat"]);
    }
}
