namespace Leetcode.Stacks;

public class Leetcode_739__Daily_Temperatures
{
    public static int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;

        Stack<(int index, int temp)> stack = new(n);
        int[] output = new int[n];

        for (int i = 0; i < n; i++)
        {
            int temp = temperatures[i];

            while (stack.Count > 0 && temp > stack.Peek().temp)
            {
                (int prevIndex, _) = stack.Pop();
                output[prevIndex] = i - prevIndex;
            }

            stack.Push((i, temp));
        }

        return output;
    }

    public static void Run()
    {
        int[] input = [73, 74, 75, 71, 69, 72, 76, 73];
        var result = DailyTemperatures(input);
        Console.WriteLine(string.Join(", ", result));
    }
}
