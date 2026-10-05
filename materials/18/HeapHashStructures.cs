using System;
using System.Linq;
using System.Collections.Generic;

var heap = new BinaryMinHeap<int>();
var expected = new List<int>();
void CheckHeap()
{
    if (!heap.IsValid() || heap.Count != expected.Count) throw new Exception("Heap invariant/count mismatch.");
    if (expected.Count > 0 && heap.Peek() != expected.Min()) throw new Exception("Minimum mismatch.");
    if (!heap.Snapshot().OrderBy(x => x).SequenceEqual(expected.OrderBy(x => x)))
        throw new Exception("Heap membership mismatch.");
}
void AddPriority(int value) { heap.Enqueue(value); expected.Add(value); CheckHeap(); }
void PopPriority()
{
    bool actual = heap.TryDequeue(out int value);
    if (actual != (expected.Count > 0)) throw new Exception("Empty result mismatch.");
    if (actual)
    {
        int minimum = expected.Min();
        if (value != minimum) throw new Exception("Removal mismatch.");
        expected.Remove(minimum);
    }
    CheckHeap();
}
PopPriority();
try { heap.Peek(); throw new Exception("Empty Peek accepted."); }
catch (InvalidOperationException) { }
try { heap.Dequeue(); throw new Exception("Empty Dequeue accepted."); }
catch (InvalidOperationException) { }
foreach (int value in new[] { 0, 0, int.MinValue, int.MaxValue, 2, 1 }) AddPriority(value);
while (expected.Count > 0) PopPriority();
foreach (int value in Enumerable.Range(0, 21).Reverse()) AddPriority(value);
while (expected.Count > 0) PopPriority();
var random = new Random(1805);
for (int step = 0; step < 600; step++)
{
    if (random.Next(3) > 0) AddPriority(random.Next(-30,31)); else PopPriority();
}
while (expected.Count > 0) PopPriority();
AddPriority(0); PopPriority(); PopPriority();
var maxHeap = new BinaryMinHeap<int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
foreach (int value in new[] { int.MinValue, 0, int.MaxValue, 0 }) maxHeap.Enqueue(value);
foreach (int value in new[] { int.MaxValue, 0, 0, int.MinValue })
    if (maxHeap.Dequeue() != value) throw new Exception("Comparer mismatch.");
var stable = new BinaryMinHeap<(int Urgency, long Arrival, int Id)>();
stable.Enqueue((2,0,101)); stable.Enqueue((0,1,105)); stable.Enqueue((2,2,109));
foreach (int id in new[] {105,101,109}) if (stable.Dequeue().Id != id) throw new Exception("Stable tuple mismatch.");

var owners = new TicketMap();
var model = new Dictionary<int,string>();
var known = new HashSet<int>();
void CheckMap()
{
    if (owners.Count != model.Count || owners.LoadFactor > 0.75) throw new Exception("Map count/load mismatch.");
    foreach (int id in known)
    {
        bool actual = owners.TryGetValue(id,out string owner);
        bool found = model.TryGetValue(id,out string? expectedOwner);
        if (actual != found || (actual && owner != expectedOwner)) throw new Exception("Map membership/value mismatch.");
    }
}
void Put(int id,string owner)
{
    known.Add(id);
    bool added = !model.ContainsKey(id);
    if (owners.Put(id,owner) != added) throw new Exception("Put result mismatch.");
    model[id]=owner; CheckMap();
}
void Remove(int id)
{
    known.Add(id);
    if (owners.Remove(id) != model.Remove(id)) throw new Exception("Map remove mismatch.");
    CheckMap();
}
CheckMap(); Remove(1);
Put(1,"A"); Put(5,"B"); Put(9,"C"); Put(5,"Updated");
if (owners.BucketCount != 4) throw new Exception("Replacement triggered growth.");
Remove(5); Put(13,"D"); Put(17,"E");
if (owners.BucketCount != 8) throw new Exception("Growth boundary mismatch.");
Put(int.MinValue,"Min"); Put(int.MaxValue,"Max"); Put(-1,"Negative");
for (int step=0;step<600;step++)
{
    int id=random.Next(-80,81);
    switch(random.Next(3))
    {
        case 0: Put(id,$"Owner {step}"); break;
        case 1: Remove(id); break;
        default: known.Add(id); CheckMap(); break;
    }
}
int retainedCapacity=owners.BucketCount;
foreach (int id in model.Keys.ToArray()) Remove(id);
Put(0,"Zero"); Remove(0);
if (owners.BucketCount!=retainedCapacity) throw new Exception("Unexpected shrink.");
Console.WriteLine("600 heap operations and 600 map operations plus boundary checks passed.");

public class BinaryMinHeap<T>
{
    private readonly List<T> items = new();
    private readonly IComparer<T> comparer;
    public int Count => items.Count;
    public int Capacity => items.Capacity;
    public BinaryMinHeap(IComparer<T>? comparer = null)
        => this.comparer = comparer ?? Comparer<T>.Default;

    public void Enqueue(T item)
    {
        items.Add(item);
        int child = items.Count - 1;
        while (child > 0)
        {
            int parent = (child - 1) / 2;
            if (comparer.Compare(items[parent], items[child]) <= 0) break;
            (items[parent], items[child]) = (items[child], items[parent]);
            child = parent;
        }
    }

    public T Peek()
    {
        if (items.Count == 0) throw new InvalidOperationException("Heap is empty.");
        return items[0];
    }

    public T Dequeue()
    {
        T minimum = Peek();
        T last = items[^1];
        items.RemoveAt(items.Count - 1);
        if (items.Count == 0) return minimum;
        items[0] = last;
        int parent = 0;
        while (parent < items.Count / 2)
        {
            int left = 2 * parent + 1;
            int right = left + 1;
            int smaller = left;
            if (right < items.Count && comparer.Compare(items[right], items[left]) < 0)
                smaller = right;
            if (comparer.Compare(items[parent], items[smaller]) <= 0) break;
            (items[parent], items[smaller]) = (items[smaller], items[parent]);
            parent = smaller;
        }
        return minimum;
    }

    public bool TryDequeue(out T item)
    {
        if (items.Count == 0) { item = default!; return false; }
        item = Dequeue();
        return true;
    }

    public bool IsValid()
    {
        for (int child = 1; child < items.Count; child++)
            if (comparer.Compare(items[(child - 1) / 2], items[child]) > 0) return false;
        return true;
    }

    public T[] Snapshot() => items.ToArray();
}

public class TicketMap
{
    private List<Entry>[] buckets = CreateBuckets(4);
    public int Count { get; private set; }
    public int BucketCount => buckets.Length;
    public double LoadFactor => (double)Count / buckets.Length;

    public bool Put(int id, string owner)
    {
        int index = Bucket(id, buckets.Length);
        for (int i = 0; i < buckets[index].Count; i++)
        {
            if (buckets[index][i].Id == id)
            {
                buckets[index][i] = new Entry(id, owner);
                return false;
            }
        }
        if ((Count + 1.0) / buckets.Length > 0.75)
        {
            Grow();
            index = Bucket(id, buckets.Length);
        }
        buckets[index].Add(new Entry(id, owner));
        Count++;
        return true;
    }

    public bool TryGetValue(int id, out string owner)
    {
        foreach (Entry entry in buckets[Bucket(id, buckets.Length)])
        {
            if (entry.Id == id) { owner = entry.Owner; return true; }
        }
        owner = default!;
        return false;
    }

    public bool Remove(int id)
    {
        List<Entry> chain = buckets[Bucket(id, buckets.Length)];
        for (int i = 0; i < chain.Count; i++)
        {
            if (chain[i].Id != id) continue;
            chain.RemoveAt(i);
            Count--;
            return true;
        }
        return false;
    }

    private void Grow()
    {
        List<Entry>[] replacement = CreateBuckets(buckets.Length * 2);
        foreach (List<Entry> chain in buckets)
            foreach (Entry entry in chain)
                replacement[Bucket(entry.Id, replacement.Length)].Add(entry);
        buckets = replacement;
    }

    private static int Bucket(int id, int length) => (int)(unchecked((uint)id) % (uint)length);

    private static List<Entry>[] CreateBuckets(int length)
    {
        var result = new List<Entry>[length];
        for (int i = 0; i < length; i++) result[i] = new List<Entry>();
        return result;
    }

    public string DescribeBuckets()
    {
        var lines = new List<string>();
        for (int i = 0; i < buckets.Length; i++)
            lines.Add($"{i}: {string.Join(", ", buckets[i].Select(e => e.Id))}");
        return string.Join(" | ", lines);
    }

    private class Entry
    {
        public int Id { get; }
        public string Owner { get; }
        public Entry(int id, string owner) { Id = id; Owner = owner; }
    }
}
