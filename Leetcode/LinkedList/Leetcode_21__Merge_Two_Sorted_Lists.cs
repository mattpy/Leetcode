using Leetcode.Helpers;

namespace Leetcode.LinkedList;

public class Leetcode_21__Merge_Two_Sorted_Lists
{
    public static ListNode MergeTwoLists(ListNode? l1, ListNode? l2)
    {
        if (l1 is null)
        {
            return l2;
        }
        else if (l2 is null)
        {
            return l1;
        }
        else if (l1.val < l2.val)
        {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}
