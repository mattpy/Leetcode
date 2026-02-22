namespace Leetcode.LinkedList;

public class Leetcode_146__LRU_Cache
{
    private readonly LinkedList<(int key, int value)> _cache = new();
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _map = new();
    private readonly int _size;

    public Leetcode_146__LRU_Cache(int capacity)
    {
        _size = capacity;
    }

    public int Get(int key)
    {
        if (_map.TryGetValue(key, out var node))
        {
            _cache.Remove(node);
            _cache.AddFirst(node);
            return node.Value.value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (_size == 0) return;

        if (_map.TryGetValue(key, out var node))
        {
            _cache.Remove(node);
            node.Value = (key, value);
            _cache.AddFirst(node);
            return;
        }

        if (_cache.Count >= _size)
        {
            int oldestKey = _cache.Last!.Value.key;
            _map.Remove(oldestKey);
            _cache.RemoveLast();
        }

        var newNode = _cache.AddFirst((key, value));
        _map[key] = newNode;
    }
}
