using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

var random=new Random(2505);
for(int test=0;test<500;test++)
{
 int n=random.Next(1,9);string[] labels=Enumerable.Range(0,n).Select(i=>"v"+i).ToArray();
 var adjacency=labels.ToDictionary(v=>v,_=>new List<string>());
 for(int i=0;i<n;i++)for(int j=0;j<n;j++)if(random.Next(4)==0){adjacency[labels[i]].Add(labels[j]);if(random.Next(3)==0)adjacency[labels[i]].Add(labels[j]);}
 var input=adjacency.ToDictionary(p=>p.Key,p=>p.Value.ToArray());var walk=new GraphWalk(input);
 int[,] distance=new int[n,n];for(int i=0;i<n;i++)for(int j=0;j<n;j++)distance[i,j]=i==j?0:1000;
 for(int i=0;i<n;i++)foreach(string to in input[labels[i]])distance[i,Array.IndexOf(labels,to)]=Math.Min(distance[i,Array.IndexOf(labels,to)],1);
 for(int k=0;k<n;k++)for(int i=0;i<n;i++)for(int j=0;j<n;j++)distance[i,j]=Math.Min(distance[i,j],distance[i,k]+distance[k,j]);
 int source=random.Next(n);var bfs=walk.Bfs(labels[source]);var dfs=walk.Dfs(labels[source]);
 Check(bfs.Order.Distinct().Count()==bfs.Order.Length,"unique BFS discovery");
 for(int target=0;target<n;target++)
 {
  int? expected=distance[source,target]==1000?null:distance[source,target];Check(bfs.Distance[labels[target]]==expected,"BFS distance");
  var path=bfs.PathTo(labels[target]);
  if(expected is null)Check(path.Length==0,"unreachable path");
  else Check(path.Length==expected+1&&path[0]==labels[source]&&path[^1]==labels[target]&&Enumerable.Range(0,path.Length-1).All(i=>input[path[i]].Contains(path[i+1])),"path witness");
 }
 var pre=new List<string>();var finish=new List<string>();var seen=new HashSet<string>();
 void Reference(string at){if(!seen.Add(at))return;pre.Add(at);foreach(string next in input[at])Reference(next);finish.Add(at);}
 Reference(labels[source]);Check(dfs.Preorder.SequenceEqual(pre)&&dfs.FinishOrder.SequenceEqual(finish),"DFS frame semantics");
 long arcs=bfs.Order.Sum(v=>(long)input[v].Distinct().Count());Check(bfs.EdgesExamined==arcs&&dfs.EdgesExamined==arcs,"traversal edge counts");
 Check(bfs.Order.ToHashSet().SetEquals(dfs.Preorder),"reached sets");
}
for(int test=0;test<500;test++)
{
 int n=random.Next(9);string[] labels=Enumerable.Range(0,n).Select(i=>"v"+i).ToArray();var sets=labels.ToDictionary(v=>v,_=>new HashSet<string>());int[] group=Enumerable.Range(0,n).ToArray();
 for(int i=0;i<n;i++)for(int j=i;j<n;j++)if(random.Next(4)==0)
 {
  sets[labels[i]].Add(labels[j]);sets[labels[j]].Add(labels[i]);int from=group[j],to=group[i];for(int k=0;k<n;k++)if(group[k]==from)group[k]=to;
 }
 var groups=new GraphWalk(sets.ToDictionary(p=>p.Key,p=>p.Value.ToArray())).UndirectedComponents();
 Check(groups.Length==group.Distinct().Count()&&groups.SelectMany(g=>g).Distinct().Count()==n,"component partition");
 for(int i=0;i<n;i++)for(int j=0;j<n;j++)Check(groups.Any(g=>g.Contains(labels[i])&&g.Contains(labels[j]))==(group[i]==group[j]),"component equivalence");
}
char[] alphabet={'a','b','A','\0','é','\ud83d','\ude00'};
for(int test=0;test<2000;test++)
{
 string text=new string(Enumerable.Range(0,random.Next(41)).Select(_=>alphabet[random.Next(alphabet.Length)]).ToArray());
 string pattern=new string(Enumerable.Range(0,random.Next(9)).Select(_=>alphabet[random.Next(alphabet.Length)]).ToArray());
 var expected=new List<int>();
 if(pattern.Length==0)expected.AddRange(Enumerable.Range(0,text.Length+1));
 else for(int start=0;start<=text.Length;)
 {int at=text.IndexOf(pattern,start,StringComparison.Ordinal);if(at<0)break;expected.Add(at);start=at+1;}
 var prepared=new PatternScan(pattern);var direct=PatternScan.Direct(text,pattern);var kmp=prepared.Search(text);
 Check(direct.Positions.SequenceEqual(expected)&&kmp.Positions.SequenceEqual(expected),"all ordinal matches");
 Check(prepared.PreparationComparisons<=2L*pattern.Length&&kmp.Comparisons<=2L*text.Length,"linear comparison bounds");
 int[] prefix=prepared.Prefix;
 for(int i=0;i<pattern.Length;i++)
 {int longest=0;for(int length=1;length<=i;length++)if(pattern.Substring(0,length)==pattern.Substring(i-length+1,length))longest=length;Check(prefix[i]==longest,"prefix reference");}
 Check(prepared.Search(text).Comparisons==kmp.Comparisons,"fresh scan counters");
}
for(int test=0;test<500;test++)
{
 int requirements=random.Next(7),full=(1<<requirements)-1;int[] teams=Enumerable.Range(0,random.Next(10)).Select(_=>random.Next(full+1)).ToArray();
 var best=new Dictionary<int,int>{{0,0}};
 foreach(int team in teams)
  foreach(var state in best.ToArray())
  {int next=state.Key|team,candidate=state.Value+1;if(!best.TryGetValue(next,out int old)||candidate<old)best[next]=candidate;}
 int? expected=best.TryGetValue(full,out int count)?count:null;
 var exact=TeamCover.Exact(requirements,teams);var greedy=TeamCover.Greedy(requirements,teams);
 Check(exact?.Indices.Length==expected,"cover optimum");
 foreach(var plan in new[]{greedy,exact}.Where(p=>p is not null))
  Check(plan!.Indices.Distinct().Count()==plan.Indices.Length&&plan.Indices.All(i=>i>=0&&i<teams.Length)&&plan.Indices.Aggregate(0,(mask,i)=>mask|teams[i])==plan.Covered,"cover witness");
 Check((greedy.Covered==full)==(expected is not null),"greedy feasibility");
 if(expected is not null)Check(greedy.Indices.Length>=expected,"greedy lower bound");
}
var owned=new GraphWalk(new Dictionary<string,string[]>{["A"]=new[]{"A"},["Remote"]=Array.Empty<string>()});var routes=owned.Bfs("A");
Reject<NotSupportedException>(()=>((IDictionary<string,int?>)routes.Distance)["A"]=9);
Reject<KeyNotFoundException>(()=>routes.PathTo("Missing"));Reject<KeyNotFoundException>(()=>owned.Dfs("Missing"));
Reject<ArgumentException>(()=>new GraphWalk(new Dictionary<string,string[]>{["A"]=new[]{"Missing"}}));
Reject<ArgumentException>(()=>new GraphWalk(new Dictionary<string,string[]>{["A"]=new[]{"B"},["B"]=Array.Empty<string>()}).UndirectedComponents());
var prefixOwner=new PatternScan("aaa");var prefixCopy=prefixOwner.Prefix;prefixCopy[1]=99;Check(prefixOwner.Search("aaaa").Positions.SequenceEqual(new[]{0,1}),"prefix ownership");
Check(new PatternScan("😀").Search("A😀B").Positions.SequenceEqual(new[]{1}),"surrogate pair match");
Check(new PatternScan("é").Search("e\u0301").Positions.Length==0,"normalization policy");
Reject<ArgumentNullException>(()=>new PatternScan(null!));Reject<ArgumentNullException>(()=>PatternScan.Direct(null!,"a"));
Reject<ArgumentException>(()=>TeamCover.Exact(1,new int[21]));Reject<ArgumentException>(()=>TeamCover.Greedy(2,new[]{4}));
var gapTeams=new[]{0b001111,0b010011,0b101100};Check(TeamCover.Greedy(6,gapTeams).Indices.Length==3&&TeamCover.Exact(6,gapTeams)!.Indices.Length==2,"greedy counterexample");
Console.WriteLine("500 directed traversals, 500 component graphs, 2000 ordinal matches, 500 cover optima, and boundaries passed.");
void Check(bool condition,string message){if(!condition)throw new Exception(message);}
void Reject<T>(Action action)where T:Exception{try{action();}catch(T){return;}throw new Exception("Expected "+typeof(T).Name);}

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
public sealed class PatternScan
{
    public record Matches(int[] Positions,long Comparisons);
    private readonly string pattern;
    private readonly int[] prefix;
    public long PreparationComparisons { get; }
    public int[] Prefix => (int[])prefix.Clone();
    public PatternScan(string pattern)
    {
        ArgumentNullException.ThrowIfNull(pattern);this.pattern=pattern;
        prefix=new int[pattern.Length];long comparisons=0;int matched=0;
        for(int i=1;i<pattern.Length;i++)
        {
            while(true)
            {
                comparisons++;
                if(pattern[i]==pattern[matched]){prefix[i]=++matched;break;}
                if(matched==0)break;
                matched=prefix[matched-1];
            }
        }
        PreparationComparisons=comparisons;
    }
    // Ordinal UTF-16 code units; all overlapping matches, including empty boundaries.
    public Matches Search(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if(pattern.Length==0)return new Matches(Enumerable.Range(0,text.Length+1).ToArray(),0);
        var positions=new List<int>();int matched=0;long comparisons=0;
        for(int i=0;i<text.Length;i++)
        {
            while(true)
            {
                comparisons++;
                if(text[i]==pattern[matched])
                {
                    matched++;
                    if(matched==pattern.Length){positions.Add(i-pattern.Length+1);matched=prefix[matched-1];}
                    break;
                }
                if(matched==0)break;
                matched=prefix[matched-1];
            }
        }
        return new Matches(positions.ToArray(),comparisons);
    }
    public static Matches Direct(string text,string pattern)
    {
        ArgumentNullException.ThrowIfNull(text);ArgumentNullException.ThrowIfNull(pattern);
        var positions=new List<int>();long comparisons=0;
        for(int start=0;start<=text.Length-pattern.Length;start++)
        {
            int offset=0;
            while(offset<pattern.Length)
            {comparisons++;if(text[start+offset]!=pattern[offset])break;offset++;}
            if(offset==pattern.Length)positions.Add(start);
        }
        return new Matches(positions.ToArray(),comparisons);
    }
}
public static class TeamCover
{
    public record Plan(int[] Indices,int Covered);
    // Teams are positions; each mask identifies covered requirements, up to 20.
    public static Plan Greedy(int requirements,int[] teams)
    {
        int full=Validate(requirements,teams);int covered=0;var chosen=new List<int>();
        while(covered!=full)
        {
            int best=-1,gain=0;
            for(int i=0;i<teams.Length;i++)
            {int next=System.Numerics.BitOperations.PopCount((uint)(teams[i]&~covered));if(next>gain){best=i;gain=next;}}
            if(best<0)break;
            chosen.Add(best);covered|=teams[best];
        }
        return new Plan(chosen.ToArray(),covered);
    }
    public static Plan? Exact(int requirements,int[] teams)
    {
        int full=Validate(requirements,teams);
        if(teams.Length>20)throw new ArgumentException("Exact teaching search is capped at 20 teams.");
        int bestCount=int.MaxValue,bestMask=0;
        for(int mask=0;mask<(1<<teams.Length);mask++)
        {
            int count=System.Numerics.BitOperations.PopCount((uint)mask);
            if(count>=bestCount)continue;
            int covered=0;for(int i=0;i<teams.Length;i++)if((mask&(1<<i))!=0)covered|=teams[i];
            if(covered==full){bestCount=count;bestMask=mask;}
        }
        return bestCount==int.MaxValue?null:new Plan(Enumerable.Range(0,teams.Length).Where(i=>(bestMask&(1<<i))!=0).ToArray(),full);
    }
    private static int Validate(int requirements,int[] teams)
    {
        ArgumentNullException.ThrowIfNull(teams);
        if(requirements<0||requirements>20)throw new ArgumentOutOfRangeException(nameof(requirements));
        int full=(1<<requirements)-1;
        if(teams.Any(mask=>mask<0||(mask&~full)!=0))throw new ArgumentException("Unknown requirement bit.");
        return full;
    }
}
