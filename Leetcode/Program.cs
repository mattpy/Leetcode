using Leetcode.Stacks;

namespace Leetcode;

internal class Program
{
    static void Main(string[] args)
    {
        Leetcode_739__Daily_Temperatures.Run();
    }
}


/**
 * 
 * public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        Stack<int> stack = new();
        int[] output = new int[n];

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int index = stack.Pop();
                int difference = i - index;
                output[index] = difference;
            }
            stack.Push(i);
        }

        return output;
    }
}
 * 
 * 
 * 
 */