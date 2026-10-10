using System;
using System.Collections.Generic;
void Check(bool condition, string message)
{
    if (!condition) throw new Exception(message);
}
void MustThrow(Action action)
{
    try { action(); }
    catch (InvalidOperationException) { return; }
    throw new Exception("Expected full/empty failure");
}
var stack = new ArrayStack<int>();
var expectedStack = new Stack<int>();
var queue = new RingQueue<int>(7);
var linked = new LinkedQueue<int>();
var expectedQueue = new Queue<int>();
var random = new Random(16);
for (int step = 0; step < 600; step++)
{
    if (expectedStack.Count == 0 || random.Next(2) == 0)
    {
        int value = random.Next(6); stack.Push(value); expectedStack.Push(value);
    }
    else Check(stack.Pop() == expectedStack.Pop(), "Stack order");
    Check(stack.Count == expectedStack.Count, "Stack count");
    if (stack.Count > 0) Check(stack.Peek() == expectedStack.Peek(), "Stack peek");
    if (expectedQueue.Count == 0 || (expectedQueue.Count < queue.Capacity && random.Next(2) == 0))
    {
        int value = random.Next(6); queue.Enqueue(value); linked.Enqueue(value); expectedQueue.Enqueue(value);
    }
    else
    {
        int expected = expectedQueue.Dequeue();
        Check(queue.Dequeue() == expected && linked.Dequeue() == expected, "Queue order");
    }
    Check(queue.Count == expectedQueue.Count && linked.Count == expectedQueue.Count, "Queue count");
    if (queue.Count > 0) Check(queue.Peek() == expectedQueue.Peek() && linked.Peek() == expectedQueue.Peek(), "Queue peek");
}
while (stack.Count > 0) Check(stack.Pop() == expectedStack.Pop(), "Drain stack");
Check(!stack.TryPop(out _), "Empty TryPop"); MustThrow(() => stack.Pop()); MustThrow(() => stack.Peek());
stack.Push(0); Check(stack.TryPop(out int zero) && zero == 0, "Zero is valid");
while (queue.Count > 0)
{
    int expected = expectedQueue.Dequeue(); Check(queue.Dequeue() == expected && linked.Dequeue() == expected, "Drain queue");
}
MustThrow(() => queue.Dequeue()); MustThrow(() => queue.Peek()); MustThrow(() => linked.Dequeue());
Check(!queue.TryDequeue(out _), "Empty TryDequeue");
queue.Enqueue(42); linked.Enqueue(42); Check(queue.Dequeue() == 42 && linked.Dequeue() == 42, "Reuse");
var one = new RingQueue<int>(1);
for (int i = 0; i < 10; i++)
{
    one.Enqueue(i); MustThrow(() => one.Enqueue(99));
    Check(one.Count == 1 && one.Dequeue() == i, "Full failure preserves state");
    MustThrow(() => one.Dequeue()); Check(one.Count == 0, "Empty failure preserves count");
}
foreach (int bad in new[] { 0, -1 })
{
    bool rejected = false;
    try { _ = new RingQueue<int>(bad); }
    catch (ArgumentOutOfRangeException) { rejected = true; }
    Check(rejected, "Invalid capacity");
}
Console.WriteLine("All stack and queue checks passed.");

public class ArrayStack<T>
{
    private T[] items = new T[2];
    public int Count { get; private set; }
    public int Capacity => items.Length;
    public void Push(T value)
    {
        if (Count == Capacity)
        {
            var larger = new T[Capacity * 2];
            Array.Copy(items, larger, Count);
            items = larger;
        }
        items[Count++] = value;
    }
    public T Peek()
    {
        if (Count == 0) throw new InvalidOperationException("Stack is empty.");
        return items[Count - 1];
    }
    public T Pop()
    {
        T value = Peek();
        items[--Count] = default!;
        return value;
    }
    public bool TryPop(out T value)
    {
        if (Count == 0) { value = default!; return false; }
        value = Pop();
        return true;
    }
}

public class RingQueue<T>
{
    private readonly T[] items;
    private int front;
    public int Count { get; private set; }
    public int Capacity => items.Length;
    public RingQueue(int capacity)
    {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        items = new T[capacity];
    }
    public void Enqueue(T value)
    {
        if (Count == Capacity) throw new InvalidOperationException("Queue is full.");
        int back = (front + Count) % Capacity;
        items[back] = value;
        Count++;
    }
    public T Peek()
    {
        if (Count == 0) throw new InvalidOperationException("Queue is empty.");
        return items[front];
    }
    public T Dequeue()
    {
        T value = Peek();
        items[front] = default!;
        front = (front + 1) % Capacity;
        Count--;
        return value;
    }
    public bool TryDequeue(out T value)
    {
        if (Count == 0) { value = default!; return false; }
        value = Dequeue();
        return true;
    }
}

public class LinkedQueue<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;
        public Node(T value) => Value = value;
    }
    private Node? head;
    private Node? tail;
    public int Count { get; private set; }
    public void Enqueue(T value)
    {
        var added = new Node(value);
        if (tail is null) head = added;
        else tail.Next = added;
        tail = added;
        Count++;
    }
    public T Peek()
    {
        if (head is null) throw new InvalidOperationException("Queue is empty.");
        return head.Value;
    }
    public T Dequeue()
    {
        T value = Peek();
        head = head!.Next;
        if (head is null) tail = null;
        Count--;
        return value;
    }
}
