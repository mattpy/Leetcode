namespace Leetcode.Intervals;

class NonOverlappingIntervals
{
    public static int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, new IntervalSorter());

        int totalOverlaps = 0;

        for (int i = 0; i < intervals.Length - 1; i++)
        {
            if (intervals[i][1] > intervals[i + 1][0])
            {
                int max = Math.Min(intervals[i][1], intervals[i + 1][1]);
                intervals[i + 1][1] = max;

                totalOverlaps++;
            }
        }

        return totalOverlaps;
    }

    class IntervalSorter : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            if (x is null) return 1;
            else if (y is null) return -1;
            else
            {
                if (x[0] == y[0])
                {
                    return x[1] - y[1];
                }
                return x[0] - y[0];
            }
        }
    }
}
