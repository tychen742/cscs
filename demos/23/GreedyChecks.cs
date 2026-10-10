using System;
using System.Linq;
using System.Collections.Generic;
var random=new Random(20261005);
for(int trial=0;trial<300;trial++)
{
 int n=random.Next(0,6);string[] vertices=Enumerable.Range(0,n).Select(i=>i.ToString()).ToArray();
 var edges=new List<GreedyGraph.Edge>();
 for(int i=0;i<n;i++)for(int j=i+1;j<n;j++)if(random.Next(3)==0)edges.Add(new(vertices[i],vertices[j],random.Next(-3,9)));
 if(edges.Count>0&&random.Next(2)==0)edges.Add(edges[0] with {Weight=random.Next(-3,9)});
 int components=Components(vertices,edges.ToArray());long optimum=long.MaxValue;
 for(int mask=0;mask<(1<<edges.Count);mask++)
 {
  if(System.Numerics.BitOperations.PopCount((uint)mask)!=n-components)continue;
  var subset=edges.Where((e,i)=>(mask&(1<<i))!=0).ToArray();
  if(Components(vertices,subset)==components)optimum=Math.Min(optimum,subset.Sum(e=>(long)e.Weight));
 }
 var forest=GreedyGraph.Kruskal(vertices,edges.ToArray());
 if(forest.Cost!=optimum||forest.Components!=components||forest.Edges.Length!=n-components||Components(vertices,forest.Edges)!=components)throw new Exception("Exhaustive forest mismatch.");
}
for(int trial=0;trial<300;trial++)
{
 int n=random.Next(1,7);string[] vertices=Enumerable.Range(0,n).Select(i=>i.ToString()).ToArray();
 var arcs=new List<GreedyGraph.Edge>();
 for(int i=0;i<n;i++)for(int j=0;j<n;j++)if(i!=j&&random.Next(4)==0)arcs.Add(new(vertices[i],vertices[j],random.Next(0,10)));
 string source=vertices[random.Next(n)];
 var expected=vertices.ToDictionary(v=>v,_=>(long?)null);expected[source]=0;
 // Repeated edge relaxation is an independent small-input distance oracle.
 for(int pass=0;pass<n-1;pass++)
 foreach(var edge in arcs)
  if(expected[edge.From] is long d && (expected[edge.To] is null||d+edge.Weight<expected[edge.To]))expected[edge.To]=d+edge.Weight;
 var routes=GreedyGraph.Dijkstra(vertices,arcs.ToArray(),source);
 foreach(string target in vertices)
 {
  if(routes.Distance[target]!=expected[target])throw new Exception("Distance reference mismatch.");
  string[] path=routes.PathTo(target);
  if(expected[target] is null){if(path.Length!=0)throw new Exception("Unreachable path.");continue;}
  if(path.Length==0||path[0]!=source||path[^1]!=target||path.Distinct().Count()!=path.Length)throw new Exception("Path shape.");
  long cost=0;
  for(int i=1;i<path.Length;i++)cost+=arcs.Where(e=>e.From==path[i-1]&&e.To==path[i]).Min(e=>e.Weight);
  if(cost!=expected[target])throw new Exception("Path cost.");
 }
}
for(int trial=0;trial<300;trial++)
{
 int n=random.Next(0,9);var meetings=Enumerable.Range(0,n).Select(i=>{int start=random.Next(-3,8);return new MeetingSchedule.Meeting(i.ToString(),start,start+random.Next(1,5));}).ToArray();
 int optimum=0;
 for(int mask=0;mask<(1<<n);mask++)
 {
  var subset=meetings.Where((m,i)=>(mask&(1<<i))!=0).OrderBy(m=>m.Start).ToArray();
  bool feasible=true;
  for(int i=1;i<subset.Length;i++)if(subset[i].Start<subset[i-1].End)feasible=false;
  if(feasible)optimum=Math.Max(optimum,subset.Length);
 }
 var chosen=MeetingSchedule.Select(meetings);
 if(chosen.Length!=optimum)throw new Exception("Exhaustive scheduling mismatch.");
 for(int i=1;i<chosen.Length;i++)if(chosen[i].Start<chosen[i-1].End)throw new Exception("Schedule feasibility.");
}
string[] wideVertices={"A","B","C","Remote"};
var wideArcs=new[]{new GreedyGraph.Edge("A","B",int.MaxValue),new GreedyGraph.Edge("B","C",int.MaxValue)};
var wide=GreedyGraph.Dijkstra(wideVertices,wideArcs,"A");
if(wide.Distance["C"]!=2L*int.MaxValue||wide.PathTo("Remote").Length!=0)throw new Exception("Wide/unreachable boundary.");
try{GreedyGraph.Dijkstra(wideVertices,wideArcs.Append(new GreedyGraph.Edge("Remote","C",-1)).ToArray(),"A");throw new Exception("Negative accepted.");}catch(ArgumentOutOfRangeException){}
try{GreedyGraph.Kruskal(new[]{"A","A"},Array.Empty<GreedyGraph.Edge>());throw new Exception("Duplicate accepted.");}catch(ArgumentException){}
try{GreedyGraph.Dijkstra(wideVertices,wideArcs,"Missing");throw new Exception("Unknown source accepted.");}catch(KeyNotFoundException){}
try{((IDictionary<string,long?>)wide.Distance)["A"]=7;throw new Exception("Mutable result.");}catch(NotSupportedException){}
Console.WriteLine("300 exhaustive schedules, 300 exhaustive forests, 300 distance/path references, and boundaries passed.");
int Components(string[] vertices,GreedyGraph.Edge[] edges)
{
 var label=vertices.ToDictionary(v=>v,v=>v);
 foreach(var edge in edges)
 {
  string a=label[edge.From],b=label[edge.To];
  if(a==b)continue;
  foreach(string v in vertices)if(label[v]==b)label[v]=a;
 }
 return label.Values.Distinct().Count();
}
public static class MeetingSchedule
{
    public record Meeting(string Id,int Start,int End,int Value=1);
    // Half-open, positive-duration intervals. Objective: maximum count.
    public static Meeting[] Select(Meeting[] meetings)
    {
        ArgumentNullException.ThrowIfNull(meetings);
        var ids=new HashSet<string>(StringComparer.Ordinal);
        foreach(var meeting in meetings)
            if(meeting is null||meeting.Id is null||!ids.Add(meeting.Id)||meeting.Start>=meeting.End)
                throw new ArgumentException("Unique IDs and Start < End required.");
        var chosen=new List<Meeting>();int lastEnd=int.MinValue;
        foreach(var meeting in meetings.OrderBy(m=>m.End).ThenBy(m=>m.Start).ThenBy(m=>m.Id,StringComparer.Ordinal))
            if(meeting.Start>=lastEnd){chosen.Add(meeting);lastEnd=meeting.End;}
        return chosen.ToArray();
    }
}
public static class GreedyGraph
{
    public record Edge(string From,string To,int Weight);
    public record Forest(Edge[] Edges,long Cost,int Components);
    public sealed class Routes
    {
        public string Source { get; }
        public IReadOnlyDictionary<string,long?> Distance { get; }
        public IReadOnlyDictionary<string,string?> Previous { get; }
        internal Routes(string source,Dictionary<string,long?> distance,Dictionary<string,string?> previous)
        {
            Source=source;
            Distance=new System.Collections.ObjectModel.ReadOnlyDictionary<string,long?>(distance);
            Previous=new System.Collections.ObjectModel.ReadOnlyDictionary<string,string?>(previous);
        }
        public string[] PathTo(string target)
        {
            if(!Distance.ContainsKey(target))throw new KeyNotFoundException(target);
            if(Distance[target] is null)return Array.Empty<string>();
            var path=new Stack<string>();string? at=target;
            for(int steps=0;at is not null;steps++)
            {
                if(steps>=Distance.Count)throw new InvalidOperationException("Invalid predecessor chain.");
                path.Push(at);at=Previous[at];
            }
            if(path.Peek()!=Source)throw new InvalidOperationException("Path does not reach source.");
            return path.ToArray();
        }
    }
    // Undirected edges; parallel edges allowed. Negative MST weights are valid.
    public static Forest Kruskal(string[] vertices,Edge[] edges,Action<string>? trace=null)
    {
        Validate(vertices,edges,false);
        var parent=vertices.ToDictionary(v=>v,v=>v,StringComparer.Ordinal);
        var size=vertices.ToDictionary(v=>v,_=>1,StringComparer.Ordinal);
        int components=vertices.Length;long cost=0;var chosen=new List<Edge>();
        foreach(var edge in edges.OrderBy(e=>e.Weight).ThenBy(e=>e.From,StringComparer.Ordinal).ThenBy(e=>e.To,StringComparer.Ordinal))
        {
            string a=Find(edge.From),b=Find(edge.To);
            if(a==b){trace?.Invoke($"reject {edge.From}-{edge.To} ({edge.Weight}): cycle");continue;}
            if(size[a]<size[b])(a,b)=(b,a);
            parent[b]=a;size[a]+=size[b];components--;
            chosen.Add(edge);cost=checked(cost+edge.Weight);
            trace?.Invoke($"accept {edge.From}-{edge.To} ({edge.Weight}): components={components}");
        }
        return new Forest(chosen.ToArray(),cost,components);
        string Find(string vertex)
        {
            while(parent[vertex]!=vertex)
            {parent[vertex]=parent[parent[vertex]];vertex=parent[vertex];}
            return vertex;
        }
    }
    // Directed arcs; nonnegative weights required, including unreachable arcs.
    public static Routes Dijkstra(string[] vertices,Edge[] arcs,string source,Action<string>? trace=null)
    {
        Validate(vertices,arcs,true);
        var graph=vertices.ToDictionary(v=>v,_=>new List<Edge>(),StringComparer.Ordinal);
        if(!graph.ContainsKey(source))throw new KeyNotFoundException("Unknown source.");
        foreach(var edge in arcs)graph[edge.From].Add(edge);
        var distance=vertices.ToDictionary(v=>v,_=>(long?)null,StringComparer.Ordinal);
        var previous=vertices.ToDictionary(v=>v,_=>(string?)null,StringComparer.Ordinal);
        var queue=new PriorityQueue<string,long>();distance[source]=0;queue.Enqueue(source,0);
        while(queue.TryDequeue(out string? current,out long queued))
        {
            if(distance[current]!=queued){trace?.Invoke($"skip stale {current} ({queued})");continue;}
            trace?.Invoke($"settle {current} ({queued})");
            foreach(var edge in graph[current])
            {
                long candidate=checked(queued+edge.Weight);
                if(distance[edge.To] is null || candidate<distance[edge.To])
                {
                    distance[edge.To]=candidate;previous[edge.To]=current;
                    queue.Enqueue(edge.To,candidate);
                    trace?.Invoke($"relax {current}->{edge.To}: {candidate}");
                }
            }
        }
        return new Routes(source,distance,previous);
    }
    private static void Validate(string[] vertices,Edge[] edges,bool nonnegative)
    {
        ArgumentNullException.ThrowIfNull(vertices);ArgumentNullException.ThrowIfNull(edges);
        var known=new HashSet<string>(StringComparer.Ordinal);
        foreach(string vertex in vertices)
            if(vertex is null||!known.Add(vertex))throw new ArgumentException("Vertices must be distinct non-null labels.");
        foreach(var edge in edges)
        {
            if(edge is null||!known.Contains(edge.From)||!known.Contains(edge.To))throw new ArgumentException("Unknown endpoint.");
            if(edge.From==edge.To)throw new ArgumentException("This graph contract excludes self-loops.");
            if(nonnegative&&edge.Weight<0)throw new ArgumentOutOfRangeException(nameof(edges),"Dijkstra requires nonnegative weights.");
        }
    }
}
