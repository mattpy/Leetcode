namespace Leetcode.Stacks;

public class Leetcode_84__Largest_Rectangle_In_Histogram
{
    public static int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new(heights.Length);
        stack.Push(-1);

        int maxArea = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
            {
                int rightIndex = stack.Pop();
                int currentHeight = heights[rightIndex];
                int currentWidth = i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);
            }

            stack.Push(i);
        }

        while (stack.Peek() != -1)
        {
            int currentHeight = heights[stack.Pop()];
            int currentWidth = heights.Length - stack.Peek() - 1;
            maxArea = Math.Max(maxArea, currentHeight * currentWidth);
        }

        return maxArea;
    }

    public static int LargestRectangleAreaDivideAndConquer(int[] heights)
    {
        return Divide(0, heights.Length - 1, heights);
    }

    private static int Divide(int left, int right, int[] heights)
    {
        if (left > right) return 0;

        int minIndex = left;
        for (int i = left; i <= right; i++)
        {
            if (heights[i] < heights[minIndex])
            {
                minIndex = i;
            }
        }

        int localSum = heights[minIndex] * (right - left + 1);
        int leftSubarray = Divide(left, minIndex - 1, heights);
        int rightSubarray = Divide(minIndex + 1, right, heights);

        return Math.Max(localSum, Math.Max(leftSubarray, rightSubarray));
    }

    public static void Run()
    {
        var result = LargestRectangleArea([2, 1, 5, 6, 2, 3]);
        Console.WriteLine(string.Join(", ", result));

        var result2 = LargestRectangleArea([2, 4]);
        Console.WriteLine(string.Join(", ", result2));
    }
}
