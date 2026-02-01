namespace Leetcode.Stacks;

public class Leetcode_475__Heaters
{
    public static int FindRadius(int[] houses, int[] heaters)
    {
        Array.Sort(houses);
        Array.Sort(heaters);

        Stack<int> stack = new(heaters);

        int minRadius = 0;
        int rightHeater = stack.Pop();

        for (int i = houses.Length - 1; i >= 0; i--)
        {
            int house = houses[i];

            while (stack.Count > 0 && house < stack.Peek())
            {
                rightHeater = stack.Pop();
            }

            if (stack.Count == 0)
            {
                minRadius = Math.Max(minRadius, Math.Abs(house - rightHeater));
            }
            else
            {
                minRadius = Math.Max(minRadius, Math.Min(Math.Abs(house - stack.Peek()), Math.Abs(house - rightHeater)));
            }
        }

        return minRadius;
    }
}
