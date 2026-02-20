using Leetcode.Helpers;
using Leetcode.LinkedList;

namespace Leetcode;

internal class Program
{
    static void Main(string[] args)
    {
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);

        Leetcode__143__Reorder_List.ReorderList(head);
    }
}
