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
        {
            var ids = new List<int>();
            foreach (Entry entry in buckets[i]) ids.Add(entry.Id);
            lines.Add($"{i}: {string.Join(", ", ids)}");
        }
        return string.Join(" | ", lines);
    }

    private class Entry
    {
        public int Id { get; }
        public string Owner { get; }
        public Entry(int id, string owner) { Id = id; Owner = owner; }
    }
}
