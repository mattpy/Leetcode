namespace Leetcode.Intervals;

class MergeIntervals
{
    public static int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, new IntervalComparer());

        LinkedList<int[]> list = new();

        foreach (int[] interval in intervals)
        {
            if (list.Count == 0 || list.Last!.Value[1] < interval[0])
            {
                list.AddLast(interval);
            }
            else
            {
                int[] last = list.Last!.Value;
                last[0] = Math.Min(last[0], interval[0]);
                last[1] = Math.Max(last[1], interval[1]);
            }
        }

        return list.ToArray<int[]>();
    }

    class IntervalComparer : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            if (x is null) return 1;
            else if (y is null) return -1;
            else return x[0] - y[0];
        }
    }
}
