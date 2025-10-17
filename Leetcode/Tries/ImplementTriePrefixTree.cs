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
    private class Node
    {
        public Dictionary<char, Node> Children = new();
        public bool IsEnd { get; set; }
    }

    private Node _root = new();

    public Trie()
    {
    }

    public void Insert(string word)
    {
        Node node = _root;

        foreach (char c in word)
        {
            if (!node.Children.TryGetValue(c, out Node? next))
            {
                next = new();
                node.Children[c] = next;
            }
            node = next;
        }

        node.IsEnd = true;
    }

    public bool Search(string word)
    {
        Node? node = _root;

        foreach (char c in word)
        {
            if (!node.Children.TryGetValue(c, out node))
            {
                return false;
            }
        }

        return node.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        Node? node = _root;

        foreach (char c in prefix)
        {
            if (!node.Children.TryGetValue(c, out node))
            {
                return false;
            }
        }

        return true;
    }
}
