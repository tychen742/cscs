var map=new TicketMap();var expected=new Dictionary<int,string>();var random=new Random(2001);int checks=0;
for(int step=0;step<600;step++)
{
    int id=random.Next(-30,31);
    if(random.Next(3)>0){string owner="Owner"+step;bool inserted=map.Put(id,owner);Check(inserted==!expected.ContainsKey(id),"insert/update");expected[id]=owner;}
    else Check(map.Remove(id)==expected.Remove(id),"removal");
    Check(map.Count==expected.Count,"map invariant");
    foreach(var pair in expected)Check(map.TryGetValue(pair.Key,out string value)&&value==pair.Value,"lookup");
}
var a=new HashSet<string>(new[]{"A","B"},StringComparer.Ordinal);var b=new HashSet<string>(new[]{"B","C"},StringComparer.Ordinal);
var both=new HashSet<string>(a,StringComparer.Ordinal);both.IntersectWith(b);Check(both.SetEquals(new[]{"B"}),"intersection");
Check(a.SetEquals(new[]{"A","B"}),"source preserved");
Console.WriteLine($"{checks} hash/set checks passed.");
void Check(bool valid,string message){if(!valid)throw new Exception(message);checks++;}
