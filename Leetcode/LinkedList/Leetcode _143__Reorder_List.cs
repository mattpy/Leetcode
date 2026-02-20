using Leetcode.Helpers;

namespace Leetcode.LinkedList;

public class Leetcode__143__Reorder_List
{
    public static void ReorderList(ListNode head)
    {
        ListNode? middle = FindMiddleOfLinkedList(head);
        middle = ReverseLinkedList(middle);

        ListNode first = head;
        ListNode second = middle;

        while (second.next is not null)
        {
            ListNode temp = first.next;
            first.next = second;
            first = temp;

            temp = second.next;
            second.next = first;
            second = temp;
        }
    }

    private static ListNode FindMiddleOfLinkedList(ListNode start)
    {
        ListNode slow = start;
        ListNode? fast = start;

        while (fast is not null && fast.next is not null)
        {
            slow = slow.next!;
            fast = fast.next.next;
        }

        return slow;
    }

    private static ListNode? ReverseLinkedList(ListNode? head)
    {
        ListNode? prev = null;
        ListNode? next = null;

        while (head is not null)
        {
            next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
    }
}
