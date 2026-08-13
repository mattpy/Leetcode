namespace Leetcode;

internal class Program
{
    static void Main(string[] args)
    {
        int result1 = Graphs.Leetcode_994__Rotting_Oranges.OrangesRotting([[2, 1, 1], [1, 1, 0], [0, 1, 1]]);
        int result2 = Graphs.Leetcode_994__Rotting_Oranges.OrangesRotting([[2, 1, 1], [0, 1, 1], [1, 0, 1]]);
        int result3 = Graphs.Leetcode_994__Rotting_Oranges.OrangesRotting([[0, 2]]);

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
    }
}
