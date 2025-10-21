using Leetcode.Helpers;

namespace Leetcode.LinkedList;

public class AddTwoNumbers
{
    public ListNode? AddTwoNumbersImpl(ListNode? l1, ListNode? l2)
    {
        ListNode dummyHead = new();
        ListNode ptr = dummyHead;
        int carry = 0;

        while (l1 is not null || l2 is not null || carry != 0)
        {
            int x = l1 is null ? 0 : l1.val;
            int y = l2 is null ? 0 : l2.val;
            int sum = x + y + carry;
            carry = sum / 10;

            ptr.next = new ListNode(sum % 10);
            ptr = ptr.next;

            if (l1 is not null) l1 = l1.next;
            if (l2 is not null) l2 = l2.next;
        }

        return dummyHead.next;
    }
}
