namespace Leetcode.Sorting;

internal class Quicksort
{
    private static readonly Random _rng = new();

    public static void QuicksortImpl(int[] nums)
    {
        Qs(0, nums.Length - 1, nums);
    }

    private static void Qs(int left, int right, int[] nums)
    {
        if (left >= right) return;
        int p = Partition(left, right, nums);
        Qs(left, p - 1, nums);
        Qs(p + 1, right, nums);
    }

    private static int Partition(int left, int right, int[] nums)
    {
        int n = nums.Length;

        // Random pivot
        int pivotIndex = _rng.Next(left, right + 1);
        int pivot = nums[pivotIndex];
        Swap(ref nums[pivotIndex], ref nums[right]);

        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (nums[j] < pivot)
            {
                i++;
                Swap(ref nums[i], ref nums[j]);
            }
        }

        i++;
        Swap(ref nums[i], ref nums[right]);
        return i;
    }

    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
