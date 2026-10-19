public static class BasicSearch
{
    public static int LinearFirst<T>(T[] values, T target, IEqualityComparer<T> equality)
    {
        for (int i = 0; i < values.Length; i++)
            if (equality.Equals(values[i], target)) return i;
        return -1;
    }
    public static int BinaryAny<T>(T[] sorted, T target, IComparer<T> comparer)
    {
        int low = 0, high = sorted.Length;
        while (low < high)
        {
            int middle = low + (high - low) / 2;
            int comparison = comparer.Compare(sorted[middle], target);
            if (comparison == 0) return middle;
            if (comparison < 0) low = middle + 1;
            else high = middle;
        }
        return -1;
    }
}

public static class BasicSort
{
    public static long InsertionSort<T>(T[] values, IComparer<T> comparer)
    {
        long comparisons = 0;
        for (int i = 1; i < values.Length; i++)
        {
            T current = values[i];
            int position = i;
            while (position > 0)
            {
                comparisons++;
                if (comparer.Compare(values[position - 1], current) <= 0) break;
                values[position] = values[position - 1];
                position--;
            }
            values[position] = current;
        }
        return comparisons;
    }
}
