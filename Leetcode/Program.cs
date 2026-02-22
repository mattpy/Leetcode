using Leetcode.Helpers;
using Leetcode.LinkedList;

namespace Leetcode;

internal class Program
{
    static void Main(string[] args)
    {
        ListNode l1 = new(1);
        l1.next = new(3);
        l1.next.next = new(7);
        l1.next.next.next = new(11);

        ListNode l2 = new(2);
        l2.next = new(4);
        l2.next.next = new(4);
        l2.next.next.next = new(10);

        var result = Leetcode_21__Merge_Two_Sorted_Lists.MergeTwoLists(l1, l2);

        while (result is not null)
        {
            Console.WriteLine(result.val);
            result = result.next;
        }
    }
}
