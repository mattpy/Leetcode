using System.Text;

namespace Leetcode.Tries;

public class ImplementTriePrefixTree
{
    public void Run()
    {
        Trie t = new();

        t.Insert("hello");
        Console.WriteLine(t.Search("hello"));
        Console.WriteLine(t.StartsWith("hel"));

        t.Insert("toothbrush");
        Console.WriteLine(t.Search("tooth"));
        Console.WriteLine(t.Search("teetth"));
        Console.WriteLine(t.StartsWith("too"));
    }
}

public class Trie
{
    class Node
    {
        public Dictionary<char, Node> Children = new();
        public bool IsEnd { get; set; }
    }

    private readonly Node _root;

    public Trie()
    {
        _root = new();
    }

    public void Insert(string word)
    {
        Node current = _root;

        foreach (char c in word)
        {
            current.Children.TryAdd(c, new Node());
            current = current.Children[c];
        }

        current.IsEnd = true;
    }

    public bool Search(string word)
    {
        Node current = _root;

        foreach (char c in word)
        {
            if (!current.Children.TryGetValue(c, out Node? node))
            {
                return false;
            }
            current = node;
        }

        return current.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        Node current = _root;

        foreach (char c in prefix)
        {
            if (!current.Children.TryGetValue(c, out Node? node))
            {
                return false;
            }
            current = node;
        }

        return true;
    }
}
