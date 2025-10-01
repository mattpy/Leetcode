using Leetcode.Sorting;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] randomNums = { 5, 2, 3, 1, 4, 7, 9, 8, 6, 10 };
            Quicksort.QuicksortImpl(randomNums);
            Console.WriteLine(string.Join(", ", randomNums));
        }
    }
}
