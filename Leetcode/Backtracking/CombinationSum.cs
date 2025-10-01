namespace Leetcode.Backtracking;

class CombinationSum
{
    public static IList<IList<int>> CombinationSumImpl(int[] candidates, int target)
    {
        List<IList<int>> output = new();

        void Recurse(int index, int sum, List<int> current)
        {
            if (sum < 0) return;
            else if (sum == 0)
            {
                output.Add([.. current]);
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                current.Add(candidates[i]);
                Recurse(i, sum - candidates[i], current);
                current.RemoveAt(current.Count - 1);
            }
        }

        Recurse(0, target, new());
        return output;
    }

    public static void Run()
    {
        int[] candidates = [2, 3, 5];
        int target = 8;
        var result = CombinationSumImpl(candidates, target);

        foreach (var r in result)
        {
            Console.WriteLine(string.Join(", ", r));
        }
    }
}
