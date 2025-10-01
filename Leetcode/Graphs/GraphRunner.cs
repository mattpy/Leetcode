namespace Leetcode.Graphs;

public class GraphRunner
{
    public static void Run()
    {
        var graph = new BidirectionalWeightedGraph();

        graph.AddUndirectedEdge('A', 'D', 4);
        graph.AddUndirectedEdge('A', 'B', 2);
        graph.AddUndirectedEdge('A', 'F', 5);
        graph.AddUndirectedEdge('B', 'D', 1);
        graph.AddUndirectedEdge('B', 'E', 3);
        graph.AddUndirectedEdge('B', 'C', 7);
        graph.AddUndirectedEdge('B', 'G', 4);
        graph.AddUndirectedEdge('B', 'F', 8);
        graph.AddUndirectedEdge('D', 'E', 2);
        graph.AddUndirectedEdge('C', 'E', 10);
        graph.AddUndirectedEdge('C', 'G', 6);
        graph.AddUndirectedEdge('F', 'G', 1);

        var result = graph.Kruskals();
        Console.WriteLine(string.Join(", ", result.edges));

        var primsResult = graph.Prims('A');
        Console.WriteLine(string.Join(", ", primsResult));
    }
}
