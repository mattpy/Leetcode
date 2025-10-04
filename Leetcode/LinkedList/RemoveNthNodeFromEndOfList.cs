using Leetcode.Helpers;

namespace Leetcode.LinkedList;

class RemoveNthNodeFromEndOfList
{
    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode savedHead = new();
        savedHead.next = head;

        ListNode? slow = savedHead;
        ListNode? fast = savedHead;

        for (int i = 0; i < n + 1; i++)
        {
            fast = fast?.next;
        }

        while (fast is not null)
        {
            slow = slow!.next;
            fast = fast.next;
        }

        slow!.next = slow!.next!.next;
        return savedHead.next;
    }
}

