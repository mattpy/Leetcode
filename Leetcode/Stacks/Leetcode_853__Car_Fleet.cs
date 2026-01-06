namespace Leetcode.Stacks;

public class Leetcode_853__Car_Fleet
{
    public static int CarFleet(int target, int[] position, int[] speed)
    {
        int n = position.Length;
        if (n == 0) return 0;

        (int position, int speed)[] values = new (int, int)[n];

        for (int i = 0; i < n; i++)
        {
            values[i] = (position[i], speed[i]);
        }

        Array.Sort(values, (a, b) => b.CompareTo(a));

        Stack<float> stack = new(n);

        foreach (var car in values)
        {
            int distanceRemaining = target - car.position;
            float timeRemaining = (float)distanceRemaining / car.speed;

            if (stack.Count == 0 || timeRemaining > stack.Peek())
            {
                stack.Push(timeRemaining);
            }
        }

        return stack.Count;
    }

    public static void Run()
    {
        int result1 = CarFleet(target: 12, position: [10, 8, 0, 5, 3], speed: [2, 4, 1, 1, 3]);
        Console.WriteLine(result1);

        int result2 = CarFleet(target: 10, position: [3], speed: [3]);
        Console.WriteLine(result2);

        int result3 = CarFleet(target: 100, position: [0, 2, 4], speed: [4, 2, 1]);
        Console.WriteLine(result3);
    }
}
