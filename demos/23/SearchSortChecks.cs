using System;
using System.Linq;
using System.Collections.Generic;
var random=new Random(20261005);
for(int trial=0;trial<600;trial++)
{
 int n=random.Next(0,45);
 int[] original=Enumerable.Range(0,n).Select(_=>random.Next(-8,9)).ToArray();
 int[] reference=original.OrderBy(x=>x).ToArray();
 long inversions=0;
 for(int i=0;i<n;i++)for(int j=i+1;j<n;j++)if(original[i]>original[j])inversions++;
 foreach(string algorithm in new[]{"selection","insertion","bubble"})
 {
  int[] copy=original.ToArray();
  ElementarySort.Counts counts=algorithm=="selection"?ElementarySort.Selection(copy,Comparer<int>.Default):algorithm=="insertion"?ElementarySort.Insertion(copy,Comparer<int>.Default):ElementarySort.Bubble(copy,Comparer<int>.Default);
  if(!copy.SequenceEqual(reference))throw new Exception("Sorted permutation.");
  if(algorithm=="selection"&&(counts.Comparisons!=(long)n*(n-1)/2||counts.Swaps>Math.Max(0,n-1)))throw new Exception("Selection counts.");
  if(algorithm=="insertion"&&counts.Shifts!=inversions)throw new Exception("Insertion inversions.");
  if(algorithm=="bubble"&&counts.Swaps!=inversions)throw new Exception("Bubble inversions.");
 }
 foreach(int target in new[]{-10,-3,0,5,10})
 {
  int linear=ReportSearch.LinearFirst(original,target,EqualityComparer<int>.Default,out long lp);
  if(linear!=Array.IndexOf(original,target)||lp!=(linear<0?n:linear+1))throw new Exception("Linear contract/count.");
  int binary=ReportSearch.BinaryAny(reference,target,Comparer<int>.Default,out long bp);
  if((binary>=0)!=(Array.IndexOf(reference,target)>=0)||binary>=0&&reference[binary]!=target)throw new Exception("Any-match contract.");
  if(bp>(n==0?0:(int)Math.Floor(Math.Log2(n))+1))throw new Exception("Binary probe bound.");
  int lower=ReportSearch.LowerBound(reference,target,Comparer<int>.Default,out _);
  int upper=ReportSearch.UpperBound(reference,target,Comparer<int>.Default,out _);
  if(lower!=reference.Count(x=>x<target)||upper!=reference.Count(x=>x<=target))throw new Exception("Boundary contract.");
 }
 var records=original.Select((key,id)=>(key,id)).ToArray();
 var comparer=Comparer<(int key,int id)>.Create((a,b)=>a.key.CompareTo(b.key));
 var expected=records.OrderBy(x=>x.key).ToArray();
 var a=records.ToArray();var b=records.ToArray();
 ElementarySort.Insertion(a,comparer);ElementarySort.Bubble(b,comparer);
 if(!a.SequenceEqual(expected)||!b.SequenceEqual(expected))throw new Exception("Stable ties.");
}
foreach(int n in new[]{0,1,2,8,32})
{
 var input=Enumerable.Range(0,n).ToArray();
 var insertion=ElementarySort.Insertion(input.ToArray(),Comparer<int>.Default);
 var bubble=ElementarySort.Bubble(input.ToArray(),Comparer<int>.Default);
 if(insertion.Comparisons!=Math.Max(0,n-1)||insertion.Shifts!=0||bubble.Comparisons!=Math.Max(0,n-1)||bubble.Swaps!=0)throw new Exception("Adaptive sorted boundary.");
}
foreach(string algorithm in new[]{"selection","insertion","bubble"})
{
 int[] copy={int.MaxValue,0,int.MinValue,int.MaxValue};
 if(algorithm=="selection")ElementarySort.Selection(copy,Comparer<int>.Default);
 else if(algorithm=="insertion")ElementarySort.Insertion(copy,Comparer<int>.Default);
 else ElementarySort.Bubble(copy,Comparer<int>.Default);
 if(!copy.SequenceEqual(new[]{int.MinValue,0,int.MaxValue,int.MaxValue}))throw new Exception("Extreme compare.");
}
int found=ReportSearch.LinearFirst(new[]{"Acme","acme"},"ACME",StringComparer.OrdinalIgnoreCase,out long probes);
if(found!=0||probes!=1)throw new Exception("String policy.");
try{ElementarySort.Insertion<int>(null!,Comparer<int>.Default);throw new Exception("Null accepted.");}
catch(ArgumentNullException){}
Console.WriteLine("1800 elementary sorts, 3000 search targets, and stable/count boundaries passed.");
public static class ReportSearch
{
    public static int LinearFirst<T>(T[] values,T target,IEqualityComparer<T> equality,out long probes)
    {
        ArgumentNullException.ThrowIfNull(values);ArgumentNullException.ThrowIfNull(equality);
        probes=0;
        for(int i=0;i<values.Length;i++)
        {
            probes++;
            if(equality.Equals(values[i],target))return i;
        }
        return -1;
    }
    // Sorted under the same comparer. Returns any match, or -1.
    public static int BinaryAny<T>(T[] values,T target,IComparer<T> comparer,out long probes)
    {
        ArgumentNullException.ThrowIfNull(values);ArgumentNullException.ThrowIfNull(comparer);
        probes=0;int low=0,high=values.Length;
        while(low<high)
        {
            int middle=low+(high-low)/2;
            probes++;int order=comparer.Compare(values[middle],target);
            if(order==0)return middle;
            if(order<0)low=middle+1;else high=middle;
        }
        return -1;
    }
    // First position >= target, or Length. Equality does not stop the loop.
    public static int LowerBound<T>(T[] values,T target,IComparer<T> comparer,out long probes)
        => Bound(values,target,comparer,false,out probes);
    // First position > target, or Length.
    public static int UpperBound<T>(T[] values,T target,IComparer<T> comparer,out long probes)
        => Bound(values,target,comparer,true,out probes);
    private static int Bound<T>(T[] values,T target,IComparer<T> comparer,bool upper,out long probes)
    {
        ArgumentNullException.ThrowIfNull(values);ArgumentNullException.ThrowIfNull(comparer);
        probes=0;int low=0,high=values.Length;
        while(low<high)
        {
            int middle=low+(high-low)/2;
            probes++;int order=comparer.Compare(values[middle],target);
            if(order<0 || upper && order==0)low=middle+1;
            else high=middle;
        }
        return low;
    }
}
public static class ElementarySort
{
    public sealed class Counts
    {
        public long Comparisons,Swaps,Shifts;
    }
    public static Counts Selection<T>(T[] values,IComparer<T> comparer)
    {
        ArgumentNullException.ThrowIfNull(values);ArgumentNullException.ThrowIfNull(comparer);
        var counts=new Counts();
        for(int start=0;start<values.Length-1;start++)
        {
            int smallest=start;
            for(int i=start+1;i<values.Length;i++)
            {
                counts.Comparisons++;
                if(comparer.Compare(values[i],values[smallest])<0)smallest=i;
            }
            if(smallest!=start){Swap(values,start,smallest);counts.Swaps++;}
        }
        return counts;
    }
    public static Counts Insertion<T>(T[] values,IComparer<T> comparer)
    {
        ArgumentNullException.ThrowIfNull(values);ArgumentNullException.ThrowIfNull(comparer);
        var counts=new Counts();
        for(int i=1;i<values.Length;i++)
        {
            T current=values[i];int j=i-1;
            while(j>=0)
            {
                counts.Comparisons++;
                if(comparer.Compare(values[j],current)<=0)break;
                values[j+1]=values[j];counts.Shifts++;j--;
            }
            values[j+1]=current;
        }
        return counts;
    }
    public static Counts Bubble<T>(T[] values,IComparer<T> comparer)
    {
        ArgumentNullException.ThrowIfNull(values);ArgumentNullException.ThrowIfNull(comparer);
        var counts=new Counts();
        for(int end=values.Length-1;end>0;end--)
        {
            bool swapped=false;
            for(int i=0;i<end;i++)
            {
                counts.Comparisons++;
                if(comparer.Compare(values[i],values[i+1])>0)
                {Swap(values,i,i+1);counts.Swaps++;swapped=true;}
            }
            if(!swapped)break;
        }
        return counts;
    }
    private static void Swap<T>(T[] values,int a,int b)
        => (values[a],values[b])=(values[b],values[a]);
}
