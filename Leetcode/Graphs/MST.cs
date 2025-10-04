namespace Leetcode.Graphs;

public partial class BidirectionalWeightedGraph
{
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
}
