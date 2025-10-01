namespace Leetcode;

class MergeKSortedLists
{
    public static ListNode? MergeKLists(ListNode[] lists)
    {
        PriorityQueue<ListNode, int> pq = new();

        foreach (ListNode list in lists)
        {
            ListNode? node = list;

            while (node is not null)
            {
                var next = node.next;
                node.next = null;
                pq.Enqueue(node, node.val);
                node = next;
            }
        }

        ListNode dummyNode = new();
        ListNode head = dummyNode;

        while (pq.Count != 0)
        {
            head.next = pq.Dequeue();
            head = head.next;
        }

        return dummyNode.next;
    }
}
