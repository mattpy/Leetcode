namespace Leetcode.Graphs;

using WeightedEdge = (char vertex, int weight);

public class BidirectionalWeightedGraph
{
    private readonly Dictionary<char, List<WeightedEdge>> _graph = new();

    public bool HasCycle { get; private set; }

    public void AddVertex(char vertex)
    {
        _graph.TryAdd(vertex, new());
    }

    public void AddDirectedEdge(char v1, char v2, int weight)
    {
        AddVertex(v1);
        AddVertex(v2);

        if (!DoesEdgeExist(v1, v2))
        {
            _graph[v1].Add((v2, weight));
        }

        UpdateHasCycle();
    }

    public void AddUndirectedEdge(char v1, char v2, int weight)
    {
        AddVertex(v1);
        AddVertex(v2);

        if (!DoesEdgeExist(v1, v2))
        {
            _graph[v1].Add((v2, weight));
        }

        if (!DoesEdgeExist(v2, v1))
        {
            _graph[v2].Add((v1, weight));
        }

        UpdateHasCycle();
    }

    private void UpdateHasCycle()
    {
        HashSet<char> current = new();
        HashSet<char> visited = new();

        foreach (var entry in _graph)
        {
            if (CheckForCycle(entry.Key))
            {
                HasCycle = true;
                break;
            }
        }

        HasCycle = false;

        bool CheckForCycle(char node)
        {
            if (current.Contains(node))
                return true;

            if (visited.Contains(node))
                return false;

            current.Add(node);
            foreach (var neighbor in _graph[node])
            {
                if (CheckForCycle(neighbor.vertex))
                {
                    return true;
                }
            }

            current.Remove(node);
            return false;
        }
    }

    public List<char> DFSIterative(char start)
    {
        Stack<char> stack = new();
        stack.Push(start);

        HashSet<char> visited = new();
        List<char> output = new();

        while (stack.Count > 0)
        {
            char node = stack.Pop();

            if (visited.Contains(node)) continue;
            visited.Add(node);
            output.Add(node);

            foreach (var neighbor in _graph[node])
            {
                stack.Push(neighbor.vertex);
            }
        }

        return output;
    }

    public List<char> DFSRecursive(char start)
    {
        HashSet<char> visited = new();
        List<char> output = new();

        DFS(start);
        return output;

        void DFS(char node)
        {
            if (visited.Contains(node)) return;
            visited.Add(node);
            output.Add(node);

            foreach (var neighbor in _graph[node])
            {
                DFS(neighbor.vertex);
            }
        }
    }

    public List<char> BFS(char start)
    {
        Queue<char> queue = new();
        queue.Enqueue(start);

        HashSet<char> visited = new();
        List<char> output = new();

        while (queue.Count > 0)
        {
            char node = queue.Dequeue();

            if (visited.Contains(node)) continue;
            visited.Add(node);
            output.Add(node);

            foreach (var neighbor in _graph[node])
            {
                queue.Enqueue(neighbor.vertex);
            }
        }

        return output;
    }

    public List<(char, char)> Prims(char start)
    {
        PriorityQueue<(char from, char to, int weight), int> pq = new();

        List<(char from, char to)> mst = new();
        HashSet<char> visited = new(_graph.Count) { start };

        foreach (var (v, w) in _graph[start])
        {
            pq.Enqueue((start, v, w), w);
        }

        while (pq.Count > 0 && mst.Count < _graph.Count - 1)
        {
            var (from, to, _) = pq.Dequeue();

            if (visited.Contains(to)) continue;
            visited.Add(to);
            mst.Add((from, to));

            foreach (var neighbor in _graph[to])
            {
                pq.Enqueue((to, neighbor.vertex, neighbor.weight), neighbor.weight);
            }
        }

        return mst;
    }

    public (List<(char, char)> edges, int totalWeight) Kruskals()
    {
        // Add all edges in the graph to the priority queue
        HashSet<string> seen = new();
        PriorityQueue<(char v1, char v2, int weight), int> pq = new(Comparer<int>.Create((x, y)
            => x.CompareTo(y)));

        foreach (var (from, adj) in _graph)
        {
            foreach (var edge in adj)
            {
                var vertices = from < edge.vertex ? (from, edge.vertex) : (edge.vertex, from);
                int weight = edge.weight;

                string key = $"{vertices.Item1}-{vertices.Item2}";
                if (seen.Contains(key)) continue;
                seen.Add(key);

                pq.Enqueue((vertices.Item1, vertices.Item2, weight), weight);
            }
        }

        List<(char, char)> mst = new();
        UnionFind uf = new(_graph.Count);

        // Create mapping between chars and ints for the UnionFind
        Dictionary<char, int> map = new();
        int index = 0;
        foreach (char node in _graph.Keys)
        {
            map[node] = index++;
        }

        int totalWeight = 0;

        while (pq.Count > 0)
        {
            var edge = pq.Dequeue();
            int p = map[edge.v1];
            int q = map[edge.v2];

            if (!uf.IsConnected(p, q))
            {
                uf.Unify(p, q);
                mst.Add((edge.v1, edge.v2));
                totalWeight += edge.weight;

                if (mst.Count == map.Count - 1)
                    break;
            }
        }

        return (mst, totalWeight);
    }

    private bool DoesEdgeExist(char v1, char v2)
    {
        if (!_graph.TryGetValue(v1, out var list))
        {
            return false;
        }

        return list.Any(edge => edge.vertex == v2);
    }
}
