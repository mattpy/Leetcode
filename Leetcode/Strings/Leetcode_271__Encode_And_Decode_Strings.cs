using System.Text;

namespace Leetcode.Strings;

public class Leetcode_271__Encode_And_Decode_Strings
{
    private const string _delimiter = "!!@@!!";

    public static string Encode(IList<string> strs)
    {
        StringBuilder sb = new();

        for (int i = 0; i < strs.Count; i++)
        {
            sb.Append(strs[i]);
            if (i != strs.Count - 1)
            {
                sb.Append(_delimiter);
            }
        }

        return sb.ToString();
    }

    public static IList<string> Decode(string s)
    {
        return s.Split(_delimiter);
    }
}
