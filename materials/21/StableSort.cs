using System;
using System.Linq;
var random=new Random(20261005);
for(int trial=0;trial<600;trial++)
{
 int n=random.Next(0,65);
 var records=Enumerable.Range(0,n).Select(i=>(id:i,key:random.Next(-5,6))).ToArray();
 var before=records.ToArray();var counts=new StableSort.Counts();
 var sorted=StableSort.Sort(records,(a,b)=>a.key.CompareTo(b.key),counts);
 if(!sorted.SequenceEqual(before.OrderBy(x=>x.key)))throw new Exception("Ascending order/preservation/stability.");
 if(!records.SequenceEqual(before)||ReferenceEquals(records,sorted))throw new Exception("Copy contract.");
 var descending=StableSort.Sort(records,(a,b)=>b.key.CompareTo(a.key),counts);
 if(!descending.SequenceEqual(before.OrderByDescending(x=>x.key)))throw new Exception("Descending stability.");
 int[] left=Enumerable.Range(0,random.Next(0,30)).Select(_=>random.Next(-8,9)).OrderBy(x=>x).ToArray();
 int[] right=Enumerable.Range(0,random.Next(0,30)).Select(_=>random.Next(-8,9)).OrderBy(x=>x).ToArray();
 int[] merged=StableSort.Merge(left,right,(a,b)=>a.CompareTo(b));
 if(!merged.SequenceEqual(left.Concat(right).OrderBy(x=>x)))throw new Exception("Merge preservation.");
}
foreach(int n in new[]{1,2,4,8,16,32,64})
{
 var counts=new StableSort.Counts();
 StableSort.Sort(Enumerable.Range(0,n).Reverse().ToArray(),(a,b)=>a.CompareTo(b),counts);
 if(counts.Writes!=2L*n*(int)Math.Log2(n)||counts.Calls!=2L*n-1||counts.PeakFrames!=(int)Math.Log2(n)+1)throw new Exception("Count formulas.");
 StableSort.Sort(Array.Empty<int>(),(a,b)=>a.CompareTo(b),counts);
 if(counts.Comparisons!=0||counts.Writes!=0||counts.Calls!=1||counts.PeakFrames!=1)throw new Exception("Counter reset.");
}
int[] extremes={int.MaxValue,int.MinValue,0,int.MaxValue};
var result=StableSort.Sort(extremes,(a,b)=>a.CompareTo(b),new StableSort.Counts());
if(!result.SequenceEqual(extremes.OrderBy(x=>x)))throw new Exception("Extreme ordering.");
int[] singleton={5};var copy=StableSort.Sort(singleton,(a,b)=>a.CompareTo(b),new StableSort.Counts());copy[0]=9;
if(singleton[0]!=5)throw new Exception("Singleton alias.");
try{StableSort.Sort<int>(null!, (a,b)=>a.CompareTo(b),new StableSort.Counts());throw new Exception("Null accepted.");}
catch(ArgumentNullException){}
Console.WriteLine("600 stable sort cases, 600 merge cases, and count/copy boundaries passed.");
public static class StableSort
{
    public sealed class Counts
    {
        public long Comparisons, Writes, Calls;
        public int PeakFrames;
    }
    // Inputs must already be sorted under compare. Equal left items win ties.
    public static T[] Merge<T>(T[] left, T[] right, Comparison<T> compare)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);
        ArgumentNullException.ThrowIfNull(compare);
        T[] result = new T[checked(left.Length + right.Length)];
        int i=0,j=0,k=0;
        while(i<left.Length && j<right.Length)
            result[k++]=compare(left[i],right[j])<=0?left[i++]:right[j++];
        while(i<left.Length)result[k++]=left[i++];
        while(j<right.Length)result[k++]=right[j++];
        return result;
    }
    // Fresh array even for empty/singleton input. Source order is unchanged.
    public static T[] Sort<T>(T[] input, Comparison<T> compare, Counts counts)
    {
        ArgumentNullException.ThrowIfNull(input);
        ArgumentNullException.ThrowIfNull(compare);
        ArgumentNullException.ThrowIfNull(counts);
        counts.Comparisons=counts.Writes=counts.Calls=0;counts.PeakFrames=0;
        T[] values=(T[])input.Clone();
        T[] buffer=new T[values.Length];
        SortRange(0,values.Length,1);
        return values;

        void SortRange(int start,int end,int depth)
        {
            counts.Calls++;counts.PeakFrames=Math.Max(counts.PeakFrames,depth);
            if(end-start<=1)return;
            int middle=start+(end-start)/2;
            SortRange(start,middle,depth+1);
            SortRange(middle,end,depth+1);
            int i=start,j=middle,k=start;
            while(i<middle && j<end)
            {
                counts.Comparisons++;
                buffer[k++]=compare(values[i],values[j])<=0?values[i++]:values[j++];
                counts.Writes++;
            }
            while(i<middle){buffer[k++]=values[i++];counts.Writes++;}
            while(j<end){buffer[k++]=values[j++];counts.Writes++;}
            for(int p=start;p<end;p++){values[p]=buffer[p];counts.Writes++;}
        }
    }
}
