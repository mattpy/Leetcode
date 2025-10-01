namespace Leetcode.Backtracking;

class CombinationSumII
{
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
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
                if (i > index && candidates[i] == candidates[i - 1]) continue;

                current.Add(candidates[i]);
                Recurse(i + 1, sum - candidates[i], current);
                current.RemoveAt(current.Count - 1);
            }
        }

        Recurse(0, target, new());

        return output;
    }

    public static void Run()
    {
        int[] candidates = [10, 1, 2, 7, 6, 1, 5];
        int target = 8;
        var result = CombinationSum2(candidates, target);
        Console.WriteLine(result);
    }
}
