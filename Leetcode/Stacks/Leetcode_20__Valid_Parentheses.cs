namespace Leetcode.Stacks;

public class Leetcode_20__Valid_Parentheses
{
    public bool IsValid(string s)
    {
        Dictionary<char, char> matches = new()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' },
        };

        Stack<char> seen = new();

        foreach (char letter in s)
        {
            if (!matches.ContainsKey(letter))
            {
                seen.Push(letter);
                continue;
            }

            if (seen.Count == 0 || matches[letter] != seen.Pop())
            {
                return false;
            }
        }

        return seen.Count == 0;
    }
}
