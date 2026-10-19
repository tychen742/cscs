SimpleGraph graph=new SimpleGraph();foreach(string v in new[]{"A","B","C","D","Remote"})graph.AddVertex(v);
graph.AddEdge("A","B");graph.AddEdge("A","C");graph.AddEdge("B","D");graph.AddEdge("C","D");graph.AddEdge("A","B");
int checks=0;SearchResult bfs=graph.Bfs("A");
Check(bfs.DistanceTo("A")==0,"source layer");Check(bfs.DistanceTo("D")==2,"minimum hops");
Check(bfs.DistanceTo("Remote") is null && bfs.PathTo("Remote").Length==0,"unreachable");
Check(string.Join(",",bfs.PathTo("D"))=="A,B,D","predecessor path");
Check(new HashSet<string>(graph.Dfs("A"),StringComparer.Ordinal).SetEquals(new[]{"A","B","C","D"}),"DFS reachability");
Check(graph.Components().Count==2,"components");
string[] snapshot=bfs.VisitOrder();snapshot[0]="Changed";Check(bfs.VisitOrder()[0]=="A","result snapshot");
var directed=new SimpleGraph(true);directed.AddVertex("A");directed.AddVertex("B");directed.AddEdge("A","B");
Check(directed.Bfs("B").DistanceTo("A") is null,"direction");
bool rejected=false;try{directed.Components();}catch(InvalidOperationException){rejected=true;}Check(rejected,"component precondition");
rejected=false;try{graph.Bfs("Missing");}catch(ArgumentException){rejected=true;}Check(rejected,"source validation");
var empty=new SimpleGraph();Check(empty.Components().Count==0,"empty graph");
var loop=new SimpleGraph();loop.AddVertex("Solo");loop.AddEdge("Solo","Solo");Check(loop.Dfs("Solo").Length==1,"cycle discovery");
Console.WriteLine($"{checks} graph checks passed.");
void Check(bool valid,string message){if(!valid)throw new Exception(message);checks++;}
