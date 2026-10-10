using System;
using System.Collections.Generic;
void Assert(bool condition, string message)
{
    if (!condition) throw new Exception(message);
}
void MustThrow(Action action)
{
    try { action(); }
    catch (ArgumentOutOfRangeException) { return; }
    throw new Exception("Expected index validation failure");
}
var a = new WorkOrderArray<int>();
var l = new WorkOrderChain<int>();
var expected = new List<int>();
void Check()
{
    Assert(a.Count == expected.Count && l.Count == expected.Count, "count");
    Assert(a.Count <= a.Capacity, "capacity");
    for (int i = 0; i < expected.Count; i++)
        Assert(a[i] == expected[i] && l[i] == expected[i], "sequence");
}
MustThrow(() => { var x = a[0]; });
MustThrow(() => { var x = l[0]; });
// Reproducible mixed operations exercise growth, shifts, duplicates, and endpoints.
var random = new Random(15);
for (int step = 0; step < 600; step++)
{
    if (expected.Count == 0 || random.Next(2) == 0)
    {
        int index = random.Next(expected.Count + 1);
        int value = random.Next(6);
        a.Insert(index, value); l.Insert(index, value); expected.Insert(index, value);
    }
    else
    {
        int index = random.Next(expected.Count);
        int value = expected[index];
        Assert(a.RemoveAt(index) == value && l.RemoveAt(index) == value, "removed result");
        expected.RemoveAt(index);
    }
    Check();
}
foreach (int bad in new[] { -1, expected.Count + 1 })
{
    MustThrow(() => a.Insert(bad, 99)); MustThrow(() => l.Insert(bad, 99)); Check();
}
MustThrow(() => a.RemoveAt(a.Count)); MustThrow(() => l.RemoveAt(l.Count)); Check();
while (expected.Count > 0)
{
    int i = expected.Count - 1;
    a.RemoveAt(i); l.RemoveAt(i); expected.RemoveAt(i); Check();
}
a.Add(42); l.Add(42); expected.Add(42); Check();
a.RemoveAt(0); l.RemoveAt(0); expected.Clear(); Check();
a.Add(7); l.Add(7); expected.Add(7); Check();
int capacity = 2, copied = 0;
for (int count = 0; count < 9; count++)
    if (count == capacity) { copied += count; capacity *= 2; }
Assert(copied == 14 && capacity == 16, "growth trace");
Console.WriteLine("All linear-list checks passed.");

public class WorkOrderArray<T>
{
    private T[] items = new T[2];
    public int Count { get; private set; }
    public int Capacity => items.Length;
    public T this[int index]
    {
        get { CheckElement(index); return items[index]; }
    }
    private void CheckElement(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
    }
    private void EnsureRoom()
    {
        if (Count < Capacity) return;
        var larger = new T[Capacity * 2];
        Array.Copy(items, larger, Count);
        items = larger;
    }
    public void Add(T value) => Insert(Count, value);
    public void Insert(int index, T value)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        EnsureRoom();
        for (int i = Count; i > index; i--)
            items[i] = items[i - 1];
        items[index] = value;
        Count++;
    }
    public T RemoveAt(int index)
    {
        CheckElement(index);
        T removed = items[index];
        for (int i = index; i < Count - 1; i++)
            items[i] = items[i + 1];
        Count--;
        items[Count] = default!;
        return removed;
    }
}
public class WorkOrderChain<T>
{
    private sealed class Node
    {
        public T Value;
        public Node? Next;
        public Node(T value, Node? next = null) { Value = value; Next = next; }
    }
    private Node? head;
    private Node? tail;
    public int Count { get; private set; }
    public T this[int index] => NodeAt(index).Value;
    private Node NodeAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        Node current = head!;
        for (int i = 0; i < index; i++) current = current.Next!;
        return current;
    }
    public void Add(T value)
    {
        var added = new Node(value);
        if (tail is null) head = added;
        else tail.Next = added;
        tail = added;
        Count++;
    }
    public void Insert(int index, T value)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        if (index == Count) { Add(value); return; }
        if (index == 0) head = new Node(value, head);
        else
        {
            Node previous = NodeAt(index - 1);
            previous.Next = new Node(value, previous.Next);
        }
        Count++;
    }
    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));
        Node removed;
        if (index == 0)
        {
            removed = head!;
            head = removed.Next;
            if (head is null) tail = null;
        }
        else
        {
            Node previous = NodeAt(index - 1);
            removed = previous.Next!;
            previous.Next = removed.Next;
            if (ReferenceEquals(removed, tail)) tail = previous;
        }
        Count--;
        return removed.Value;
    }
}
