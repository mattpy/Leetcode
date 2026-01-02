using System.Text;

namespace Leetcode.Strings;

public class ZigzagConversion
{
    public static string Convert(string s, int numRows)
    {
        if (numRows == 1 || numRows >= s.Length) return s;

        IList<IList<char>> letters = new List<IList<char>>(numRows);
        for (int i = 0; i < numRows; i++) letters.Add(new List<char>());

        bool isGoingDown = true;
        int verticalPosition = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            letters[verticalPosition].Add(c);

            if (!isGoingDown)
            {
                verticalPosition--;

                if (verticalPosition < 0)
                {
                    isGoingDown = true;
                    verticalPosition = Math.Min(1, numRows - 1);
                }
            }
            else
            {
                verticalPosition++;

                if (verticalPosition >= numRows)
                {
                    isGoingDown = false;
                    verticalPosition = Math.Max(0, numRows - 2);
                }
            }
        }

        StringBuilder sb = new(s.Length);
        foreach (var list in letters)
        {
            foreach (var c in list)
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
