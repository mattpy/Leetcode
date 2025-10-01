namespace Leetcode.Intervals;

static class MeetingRoomsII
{
    public static int MinMeetingRooms(int[][] intervals)
    {
        Array.Sort(intervals, new IntervalComparer());

        PriorityQueue<int[], int> pq = new();

        foreach (int[] interval in intervals)
        {
            if (pq.Count == 0 || interval[0] < pq.Peek()[1])
            {
                pq.Enqueue(interval, interval[1]);
            }
            else
            {
                while (pq.Count > 0 && pq.Peek()[1] < interval[0])
                {
                    pq.Dequeue();
                }
                pq.Enqueue(interval, interval[1]);
            }
        }

        return pq.Count;
    }
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
