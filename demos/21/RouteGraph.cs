using System;
using System.Collections.Generic;
using System.Linq;

var graph = new RouteGraph();
var vertices = new HashSet<string>(StringComparer.Ordinal);
var edges = new Dictionary<(string A, string B), int>();
string[] labels = Enumerable.Range(0,8).Select(i => $"R{i}").ToArray();
(string A,string B) Key(string a,string b) => StringComparer.Ordinal.Compare(a,b)<0 ? (a,b) : (b,a);
void Check()
{
    if (!graph.IsValid() || graph.VertexCount!=vertices.Count || graph.EdgeCount!=edges.Count
        || !graph.Vertices().OrderBy(x=>x,StringComparer.Ordinal).SequenceEqual(vertices.OrderBy(x=>x,StringComparer.Ordinal)))
        throw new Exception("Counts/vertices/invariant mismatch.");
    foreach (string a in labels)
    {
        if (vertices.Contains(a))
        {
            var expected = edges.Where(e=>e.Key.A==a||e.Key.B==a)
                .ToDictionary(e=>e.Key.A==a ? e.Key.B : e.Key.A,e=>e.Value);
            var actual = graph.Neighbors(a);
            if (graph.Degree(a)!=expected.Count || actual.Length!=expected.Count
                || actual.Any(e=>!expected.TryGetValue(e.Key,out int w)||w!=e.Value))
                throw new Exception("Degree/neighbor mismatch.");
        }
        foreach (string b in labels)
        {
            bool expectedFound = a!=b && edges.TryGetValue(Key(a,b),out _);
            bool found=graph.TryGetWeight(a,b,out int weight);
            if(found!=expectedFound||(found&&weight!=edges[Key(a,b)]))
                throw new Exception("Edge/weight mismatch.");
        }
    }
}
void Add(string a)
{
    if(graph.AddVertex(a)!=vertices.Add(a))throw new Exception("Add vertex result mismatch.");
    Check();
}
void Set(string a,string b,int weight)
{
    bool added=!edges.ContainsKey(Key(a,b));
    if(graph.SetEdge(a,b,weight)!=added)throw new Exception("Set edge result mismatch.");
    edges[Key(a,b)]=weight;Check();
}
void RemoveEdge(string a,string b)
{
    if(graph.RemoveEdge(a,b)!=edges.Remove(Key(a,b)))throw new Exception("Remove edge result mismatch.");
    Check();
}
void RemoveVertex(string a)
{
    bool expected=vertices.Remove(a);
    foreach(var edge in edges.Keys.Where(e=>e.A==a||e.B==a).ToArray())edges.Remove(edge);
    if(graph.RemoveVertex(a)!=expected)throw new Exception("Remove vertex result mismatch.");
    Check();
}
Check();RemoveVertex("R0");RemoveEdge("R0","R1");
Add("R0");Add("R1");Add("R0");
Set("R0","R1",0);Set("R1","R0",int.MaxValue);
var snapshot=graph.Neighbors("R0");snapshot[0]=new KeyValuePair<string,int>("Ghost",-1);Check();
var vertexSnapshot=graph.Vertices();vertexSnapshot[0]="Ghost";Check();
try {graph.SetEdge("R0","R0",0);throw new Exception("Loop accepted.");}catch(ArgumentException){}
try {graph.SetEdge("R0","R1",-1);throw new Exception("Negative minutes accepted.");}catch(ArgumentOutOfRangeException){}
try {graph.SetEdge("R0","Missing",1);throw new Exception("Unknown endpoint accepted.");}catch(KeyNotFoundException){}
try {graph.Degree("Missing");throw new Exception("Unknown degree accepted.");}catch(KeyNotFoundException){}
try {graph.Neighbors("Missing");throw new Exception("Unknown neighbors accepted.");}catch(KeyNotFoundException){}
Check();RemoveVertex("R0");Add("R0");
if(graph.Degree("R0")!=0)throw new Exception("Removed edges resurrected.");
var random=new Random(1905);
for(int step=0;step<600;step++)
{
    string a=labels[random.Next(labels.Length)],b=labels[random.Next(labels.Length)];
    switch(random.Next(4))
    {
        case 0:Add(a);break;
        case 1:RemoveVertex(a);break;
        case 2:RemoveEdge(a,b);break;
        default:
            if(a==b){Check();break;}
            Add(a);Add(b);Set(a,b,random.Next(0,20));break;
    }
}
foreach(string vertex in vertices.ToArray())RemoveVertex(vertex);
Add("R0");Add("R1");Set("R0","R1",0);RemoveEdge("R1","R0");Check();
Console.WriteLine("600 graph updates and explicit boundary/snapshot checks passed.");

public class RouteGraph
{
    private readonly Dictionary<string, Dictionary<string, int>> adjacency
        = new(StringComparer.Ordinal);
    public int VertexCount => adjacency.Count;
    public int EdgeCount { get; private set; }

    public bool AddVertex(string vertex)
        => adjacency.TryAdd(vertex, new Dictionary<string, int>(StringComparer.Ordinal));

    public bool SetEdge(string a, string b, int minutes)
    {
        if (a == b) throw new ArgumentException("Self-loops are not allowed.");
        if (minutes < 0) throw new ArgumentOutOfRangeException(nameof(minutes));
        RequireVertex(a);
        RequireVertex(b);
        bool added = !adjacency[a].ContainsKey(b);
        adjacency[a][b] = minutes;
        adjacency[b][a] = minutes;
        if (added) EdgeCount++;
        return added;
    }

    public bool TryGetWeight(string a, string b, out int minutes)
    {
        minutes = default;
        return adjacency.TryGetValue(a, out var neighbors)
            && neighbors.TryGetValue(b, out minutes);
    }

    public int Degree(string vertex)
    {
        RequireVertex(vertex);
        return adjacency[vertex].Count;
    }

    public KeyValuePair<string, int>[] Neighbors(string vertex)
    {
        RequireVertex(vertex);
        return adjacency[vertex].ToArray();
    }

    public string[] Vertices() => adjacency.Keys.ToArray();

    public bool RemoveEdge(string a, string b)
    {
        if (!adjacency.TryGetValue(a, out var neighbors) || !neighbors.Remove(b)) return false;
        adjacency[b].Remove(a);
        EdgeCount--;
        return true;
    }

    public bool RemoveVertex(string vertex)
    {
        if (!adjacency.TryGetValue(vertex, out var neighbors)) return false;
        foreach (string neighbor in neighbors.Keys) adjacency[neighbor].Remove(vertex);
        EdgeCount -= neighbors.Count;
        adjacency.Remove(vertex);
        return true;
    }

    public bool IsValid()
    {
        long degreeSum = 0;
        foreach (var (vertex, neighbors) in adjacency)
        {
            degreeSum += neighbors.Count;
            foreach (var (neighbor, minutes) in neighbors)
            {
                if (vertex == neighbor || minutes < 0
                    || !adjacency.TryGetValue(neighbor, out var reverse)
                    || !reverse.TryGetValue(vertex, out int reverseMinutes)
                    || reverseMinutes != minutes) return false;
            }
        }
        return degreeSum == 2L * EdgeCount;
    }

    private void RequireVertex(string vertex)
    {
        if (!adjacency.ContainsKey(vertex)) throw new KeyNotFoundException($"Unknown vertex: {vertex}");
    }
}
