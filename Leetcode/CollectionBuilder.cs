using System.Runtime.CompilerServices;

namespace Leetcode;

[CollectionBuilder(typeof(BagBuilder), nameof(BagBuilder.Create))]
public sealed class Bag<T>
{
    private readonly List<T> _items = new();
    public void Add(T value) => _items.Add(value);

    // Pattern-based enumeration (enables foreach without implementing IEnumerable<T>)
    public List<T>.Enumerator GetEnumerator() => _items.GetEnumerator();
}

public static class BagBuilder
{
    public static Bag<T> Create<T>(ReadOnlySpan<T> items)
    {
        var bag = new Bag<T>();
        foreach (var item in items) bag.Add(item);
        return bag;
    }
}

