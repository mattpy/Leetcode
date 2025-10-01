namespace Leetcode.Intervals;

class MinimumNumberOfArrowsToBurstBalloons
{
    public static int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (int[] x, int[] y) =>
        {
            if (x is null) return 1;
            else if (y is null) return -1;
            else
            {
                return x[1].CompareTo(y[1]);
            }
        });

        Stack<int[]> stack = new();

        foreach (int[] point in points)
        {
            if (stack.Count == 0 || point[0] > stack.Peek()[1])
            {
                stack.Push(point);
            }
        }

        return stack.Count;
    }
}
