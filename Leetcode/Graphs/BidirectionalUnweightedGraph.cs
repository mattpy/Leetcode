namespace Leetcode.Graphs;

using WeightedEdge = (char vertex, int weight);

public partial class BidirectionalWeightedGraph
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

    private bool DoesEdgeExist(char v1, char v2)
    {
        if (!_graph.TryGetValue(v1, out var list))
        {
            return false;
        }

        return list.Any(edge => edge.vertex == v2);
    }
}
