namespace Leetcode.Graphs;

public class UnionFind
{
    private readonly int[] _id;
    private readonly int[] _sz;
    public int NumIslands { get; private set; }

    public UnionFind(int size)
    {
        _id = new int[size];
        _sz = new int[size];
        NumIslands = size;

        for (int i = 0; i < size; i++)
        {
            _id[i] = i;
            _sz[i] = 1;
        }
    }

    public bool IsConnected(int p, int q) => Find(p) == Find(q);

    private int Find(int p)
    {
        int root = p;

        // Find root
        while (_id[root] != root)
        {
            root = _id[root];
        }

        // Path compression
        while (p != root)
        {
            int next = _id[p];
            _id[p] = root;
            p = next;
        }

        return p;
    }

    public void Unify(int p, int q)
    {
        int root1 = Find(p);
        int root2 = Find(q);

        if (root1 == root2)
            return;

        if (_sz[root1] >= _sz[root2])
        {
            _id[root2] = root1;
            _sz[root1] += _sz[root2];
        }
        else
        {
            _id[root1] = root2;
            _sz[root2] += _sz[root1];
        }

        NumIslands--;
    }
}
