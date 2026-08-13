namespace Leetcode.Graphs;

public class Leetcode_994__Rotting_Oranges
{
    public static int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int numberFresh = 0;

        Queue<(int row, int col)> queue = new();

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == 1) numberFresh++;

                if (grid[row][col] == 2)
                {
                    queue.Enqueue((row, col));
                }
            }
        }

        if (numberFresh == 0) return 0;

        ReadOnlySpan<(int dx, int dy)> offsets = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        int secondsPassed = 0;

        while (queue.Count > 0 && numberFresh > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (row, col) = queue.Dequeue();

                foreach (var (dx, dy) in offsets)
                {
                    int newRow = row + dx;
                    int newCol = col + dy;

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                    {
                        numberFresh--;
                        grid[newRow][newCol] = 2;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
            secondsPassed++;
        }

        return numberFresh == 0 ? secondsPassed : -1;
    }
}
