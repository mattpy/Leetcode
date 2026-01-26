namespace Leetcode.Graphs;

public class Leetcode_200__Number_Of_Islands
{
    public static int NumIslands(char[][] grid)
    {
        int numIslands = 0;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == '1')
                {
                    numIslands++;
                    MarkIslands(row, col, grid);
                }
            }
        }

        return numIslands;

        static void MarkIslands(int row, int col, char[][] grid)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == '0') return;
            grid[row][col] = '0';

            MarkIslands(row + 1, col, grid);
            MarkIslands(row - 1, col, grid);
            MarkIslands(row, col + 1, grid);
            MarkIslands(row, col - 1, grid);
        }
    }

    public static void Run()
    {
        var result = NumIslands([
            ['1', '1', '1', '1', '0'], 
            ['1', '1', '0', '1', '0'], 
            ['1', '1', '0', '0', '0'], 
            ['0', '0', '0', '0', '0']
        ]);
        Console.WriteLine(result);
    }
}
