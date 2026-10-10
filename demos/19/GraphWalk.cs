using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

var adjacency=new Dictionary<string,string[]>{["HQ"]=new[]{"Warehouse","Helpdesk"},["Warehouse"]=new[]{"Depot"},["Helpdesk"]=new[]{"Client"},["Depot"]=new[]{"Client"},["Client"]=new[]{"Warehouse"},["Remote"]=Array.Empty<string>()};
var bfs=new GraphWalk(adjacency).Bfs("HQ",Console.WriteLine);
Console.WriteLine("order="+string.Join(",",bfs.Order));
Console.WriteLine($"Client layer={bfs.Distance["Client"]}, Remote unreachable={bfs.Distance["Remote"] is null}, arcs examined={bfs.EdgesExamined}");
public sealed class GraphWalk
{
    private readonly Dictionary<string,string[]> graph;
    private readonly string[] vertices;
    public GraphWalk(Dictionary<string,string[]> adjacency)
    {
        ArgumentNullException.ThrowIfNull(adjacency);
        graph=new Dictionary<string,string[]>(StringComparer.Ordinal);
        foreach(var pair in adjacency)
        {
            if(pair.Value is null)throw new ArgumentException("Null adjacency list.");
            graph.Add(pair.Key,pair.Value.Distinct(StringComparer.Ordinal).ToArray());
        }
        foreach(var neighbors in graph.Values)
            if(neighbors.Any(v=>v is null||!graph.ContainsKey(v)))throw new ArgumentException("Unknown endpoint.");
        vertices=graph.Keys.OrderBy(v=>v,StringComparer.Ordinal).ToArray();
    }
    public sealed class Layers
    {
        public string Source { get; }
        public string[] Order { get; }
        public IReadOnlyDictionary<string,int?> Distance { get; }
        public IReadOnlyDictionary<string,string?> Previous { get; }
        public long EdgesExamined { get; }
        internal Layers(string source,string[] order,Dictionary<string,int?> distance,Dictionary<string,string?> previous,long edges)
        {
            Source=source;Order=order;EdgesExamined=edges;
            Distance=new System.Collections.ObjectModel.ReadOnlyDictionary<string,int?>(distance);
            Previous=new System.Collections.ObjectModel.ReadOnlyDictionary<string,string?>(previous);
        }
        public string[] PathTo(string target)
        {
            if(!Distance.ContainsKey(target))throw new KeyNotFoundException(target);
            if(Distance[target] is null)return Array.Empty<string>();
            var path=new Stack<string>();string? at=target;
            while(at is not null)
            {
                if(path.Count>=Distance.Count)throw new InvalidOperationException("Predecessor cycle.");
                path.Push(at);at=Previous[at];
            }
            if(path.Peek()!=Source)throw new InvalidOperationException("Invalid source path.");
            return path.ToArray();
        }
    }
    public Layers Bfs(string source,Action<string>? trace=null)
    {
        if(!graph.ContainsKey(source))throw new KeyNotFoundException(source);
        var distance=vertices.ToDictionary(v=>v,_=>(int?)null,StringComparer.Ordinal);
        var previous=vertices.ToDictionary(v=>v,_=>(string?)null,StringComparer.Ordinal);
        var queue=new Queue<string>();var order=new List<string>();long edges=0;
        distance[source]=0;queue.Enqueue(source);
        while(queue.Count>0)
        {
            string at=queue.Dequeue();order.Add(at);trace?.Invoke($"visit {at}: layer={distance[at]}");
            foreach(string next in graph[at])
            {
                edges++;
                if(distance[next] is not null)continue;
                distance[next]=distance[at]!.Value+1;previous[next]=at;queue.Enqueue(next);
            }
        }
        return new Layers(source,order.ToArray(),distance,previous,edges);
    }
    public record Depth(string[] Preorder,string[] FinishOrder,long EdgesExamined);
    public Depth Dfs(string source,Action<string>? trace=null)
    {
        if(!graph.ContainsKey(source))throw new KeyNotFoundException(source);
        var color=vertices.ToDictionary(v=>v,_=>0,StringComparer.Ordinal);
        var stack=new Stack<(string Vertex,int Next)>();var pre=new List<string>();var finish=new List<string>();long edges=0;
        Enter(source);
        while(stack.Count>0)
        {
            var frame=stack.Pop();
            if(frame.Next==graph[frame.Vertex].Length)
            {color[frame.Vertex]=2;finish.Add(frame.Vertex);trace?.Invoke($"exit {frame.Vertex}");continue;}
            stack.Push((frame.Vertex,frame.Next+1));string next=graph[frame.Vertex][frame.Next];edges++;
            if(color[next]==0)Enter(next);
            else if(color[next]==1)trace?.Invoke($"active edge {frame.Vertex}->{next}");
        }
        return new Depth(pre.ToArray(),finish.ToArray(),edges);
        void Enter(string vertex){color[vertex]=1;pre.Add(vertex);stack.Push((vertex,0));trace?.Invoke($"enter {vertex}");}
    }
    public string[][] UndirectedComponents()
    {
        var neighbors=graph.ToDictionary(p=>p.Key,p=>p.Value.ToHashSet(StringComparer.Ordinal),StringComparer.Ordinal);
        foreach(var pair in graph)
            foreach(string next in pair.Value)
                if(!neighbors[next].Contains(pair.Key))throw new ArgumentException("Components require symmetric adjacency.");
        var seen=new HashSet<string>(StringComparer.Ordinal);var groups=new List<string[]>();
        foreach(string root in vertices)
        {
            if(!seen.Add(root))continue;
            var queue=new Queue<string>();var group=new List<string>();queue.Enqueue(root);
            while(queue.Count>0)
            {
                string at=queue.Dequeue();group.Add(at);
                foreach(string next in graph[at])if(seen.Add(next))queue.Enqueue(next);
            }
            groups.Add(group.ToArray());
        }
        return groups.ToArray();
    }
}
