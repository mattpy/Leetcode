using Leetcode.Helpers;

namespace Leetcode.LinkedList;

public class Leetcode_141__Linked_list_Cycle
{
    public static bool HasCycle(ListNode head)
    {
        if (head is null) return false;

        ListNode? slow = head;
        ListNode? fast = head.next;

        while (fast is not null && fast.next is not null)
        {
            if (slow == fast)
            {
                return true;
            }

            slow = slow?.next;
            fast = fast.next.next;
        }

        return false;
    }
}
