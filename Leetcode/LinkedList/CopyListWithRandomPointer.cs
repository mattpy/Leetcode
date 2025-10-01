namespace Leetcode.LinkedList;

public class CopyListWithRandomPointer
{
    private Dictionary<Node, Node> _map = new();

    public Node CopyRandomList(Node head)
    {
        if (head is null)
        {
            return head;
        }

        if (_map.ContainsKey(head))
        {
            return _map[head];
        }

        Node node = new(head.val);
        _map[head] = node;

        node.next = CopyRandomList(head.next);
        node.random = CopyRandomList(head.random);

        return node;
    }
}
