public class BinaryMinHeap<T>
{
    private readonly List<T> items = new List<T>();
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
