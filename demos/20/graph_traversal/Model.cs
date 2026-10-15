public class SimpleGraph
{
    private readonly Dictionary<string, List<string>> adjacency
        = new Dictionary<string, List<string>>(StringComparer.Ordinal);
    private readonly List<string> vertexOrder = new List<string>();
    public bool IsDirected { get; }
    public SimpleGraph(bool directed = false) { IsDirected = directed; }
    public void AddVertex(string vertex)
    {
        if (string.IsNullOrWhiteSpace(vertex)) throw new ArgumentException("Vertex required.");
        if (adjacency.ContainsKey(vertex)) return;
        adjacency.Add(vertex, new List<string>());
        vertexOrder.Add(vertex);
    }
    public void AddEdge(string from, string to)
    {
        RequireVertex(from); RequireVertex(to);
        if (!adjacency[from].Contains(to)) adjacency[from].Add(to);
        if (!IsDirected && !adjacency[to].Contains(from)) adjacency[to].Add(from);
    }
    public string[] Vertices() { return vertexOrder.ToArray(); }
    public string[] Neighbors(string vertex)
    {
        RequireVertex(vertex);
        return adjacency[vertex].ToArray();
    }
    private void RequireVertex(string vertex)
    {
        if (!adjacency.ContainsKey(vertex)) throw new ArgumentException("Unknown vertex: " + vertex);
    }
    public SearchResult Bfs(string source)
    {
        RequireVertex(source);
        var distance = new Dictionary<string, int>(StringComparer.Ordinal);
        var previous = new Dictionary<string, string?>(StringComparer.Ordinal);
        var order = new List<string>();
        var waiting = new Queue<string>();
        distance.Add(source, 0); previous.Add(source, null); waiting.Enqueue(source);
        while (waiting.Count > 0)
        {
            string current = waiting.Dequeue();
            order.Add(current);
            foreach (string next in adjacency[current])
            {
                if (distance.ContainsKey(next)) continue;
                distance.Add(next, distance[current] + 1);
                previous.Add(next, current);
                waiting.Enqueue(next);
            }
        }
        return new SearchResult(distance, previous, order);
    }
    public string[] Dfs(string source)
    {
        RequireVertex(source);
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var order = new List<string>();
        Visit(source, seen, order);
        return order.ToArray();
    }
    private void Visit(string current, HashSet<string> seen, List<string> order)
    {
        if (!seen.Add(current)) return;
        order.Add(current);
        foreach (string next in adjacency[current]) Visit(next, seen, order);
    }
    public List<string[]> Components()
    {
        if (IsDirected) throw new InvalidOperationException("Components requires an undirected graph.");
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var groups = new List<string[]>();
        foreach (string vertex in vertexOrder)
        {
            if (seen.Contains(vertex)) continue;
            string[] group = Bfs(vertex).VisitOrder();
            foreach (string member in group) seen.Add(member);
            groups.Add(group);
        }
        return groups;
    }
}

public class SearchResult
{
    private readonly Dictionary<string, int> distance;
    private readonly Dictionary<string, string?> previous;
    private readonly List<string> order;
    internal SearchResult(Dictionary<string, int> distance,
        Dictionary<string, string?> previous, List<string> order)
    {
        this.distance = distance; this.previous = previous; this.order = order;
    }
    public int? DistanceTo(string target)
    {
        return distance.TryGetValue(target, out int value) ? value : null;
    }
    public string[] VisitOrder() { return order.ToArray(); }
    public string[] PathTo(string target)
    {
        if (!distance.ContainsKey(target)) return Array.Empty<string>();
        var reverse = new List<string>();
        string? current = target;
        while (current is not null)
        {
            reverse.Add(current);
            current = previous[current];
        }
        reverse.Reverse();
        return reverse.ToArray();
    }
}
