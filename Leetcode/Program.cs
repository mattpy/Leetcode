using static Leetcode.SlidingWindow.Leetcode567_PermutationInString;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result = CheckInclusion("abcdxabcde", "abcdeabcdx");
            Console.WriteLine(result);
        }
    }
}
