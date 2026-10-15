using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

var random=new Random(2405);
for(int test=0;test<600;test++)
{
 int[] sizes=Enumerable.Range(0,random.Next(7)).Select(_=>random.Next(1,10)).ToArray();int target=random.Next(36);
 var distance=new Dictionary<int,int>{{0,0}};var queue=new Queue<int>();queue.Enqueue(0);
 while(queue.Count>0)
 {
  int at=queue.Dequeue();
  foreach(int size in sizes)
  {int next=at+size;if(next<=target&&!distance.ContainsKey(next)){distance[next]=distance[at]+1;queue.Enqueue(next);}}
 }
 var plan=CoinPlanning.MinimumCoins(sizes,target);int? expected=distance.TryGetValue(target,out int count)?count:null;
 Check(plan.Count==expected,"coin minimum");
 if(plan.Count is null)Check(plan.Coins.Length==0,"unreachable coin witness");
 else Check(plan.Coins.Length==plan.Count&&plan.Coins.Sum()==target&&plan.Coins.All(sizes.Contains),"coin witness");
 for(int amount=0;amount<=target;amount++)Check(plan.Best[amount]==(distance.TryGetValue(amount,out int d)?d:(int?)null),"all table states");
}
for(int test=0;test<600;test++)
{
 int[] values=Enumerable.Range(0,random.Next(11)).Select(_=>random.Next(-8,9)).ToArray();long target=random.Next(-30,31);
 bool expected=false;
 for(int mask=0;mask<(1<<values.Length);mask++)
 {long sum=0;for(int i=0;i<values.Length;i++)if((mask&(1<<i))!=0)sum+=values[i];if(sum==target){expected=true;break;}}
 foreach(var setting in new[]{(false,false),(true,false),(true,true)})
 {
  var r=SubsetPlanning.FindSubset(values,target,setting.Item1,setting.Item2);
  Check((r.Indices is not null)==expected,"subset existence");
  if(r.Indices is not null)Check(r.Indices.Distinct().Count()==r.Indices.Length&&r.Indices.All(i=>i>=0&&i<values.Length)&&r.Indices.Sum(i=>(long)values[i])==target,"subset witness");
 }
}
BigInteger a=0,b=1;
for(int n=0;n<=92;n++)
{
 long expected=(long)a;var memo=FibPlanning.Fibonacci(n);
 Check(memo.Value==expected&&FibPlanning.FibonacciTable(n)[n]==expected&&FibPlanning.FibonacciRolling(n)==expected,"Fibonacci methods");
 Check(memo.Calls==(n<2?1:2*n-1)&&memo.Computed==Math.Max(0,n-1)&&memo.Hits==Math.Max(0,n-3),"memo counters");
 if(n<=18){var raw=FibPlanning.Fibonacci(n,false);Check(raw.Value==expected&&raw.Calls==2*(long)b-1,"naive counts");}
 (a,b)=(b,a+b);
}
for(int n=0;n<=10;n++)
{
 var sets=ChoicePlanning.Subsets(n);Check(sets.Length==(1<<n),"subset cardinality");
 var masks=new HashSet<int>();
 foreach(var set in sets)
 {Check(set.Distinct().Count()==set.Length&&set.All(i=>i>=0&&i<n),"subset positions");int mask=0;foreach(int i in set)mask|=1<<i;Check(masks.Add(mask),"subset uniqueness");}
}
int factorial=1;
for(int n=0;n<=7;n++)
{
 if(n>0)factorial*=n;var orders=ChoicePlanning.Permutations(n);Check(orders.Length==factorial,"permutation cardinality");
 Check(orders.All(o=>o.Length==n&&o.Distinct().Count()==n&&o.All(i=>i>=0&&i<n)),"permutation positions");
 Check(orders.Select(o=>string.Join(",",o)).Distinct().Count()==factorial,"permutation uniqueness");
}
var wide=SubsetPlanning.FindSubset(new[]{int.MaxValue,int.MaxValue,-1},4294967293);
Check(wide.Indices!.Length==3,"wide sum");
Check(SubsetPlanning.FindSubset(new[]{int.MaxValue},long.MinValue).Indices is null,"extreme impossible target");
var first=SubsetPlanning.FindSubset(new[]{3,3},6);var second=SubsetPlanning.FindSubset(new[]{3,3},6);first.Indices![0]=99;Check(second.Indices![0]==0,"independent search snapshots");
var setsCopy=ChoicePlanning.Subsets(2);setsCopy[0][0]=99;Check(setsCopy[1][0]==0,"independent enumeration snapshots");
Reject<ArgumentOutOfRangeException>(()=>FibPlanning.Fibonacci(-1));Reject<ArgumentOutOfRangeException>(()=>FibPlanning.Fibonacci(93));Reject<ArgumentOutOfRangeException>(()=>FibPlanning.Fibonacci(26,false));
Reject<ArgumentException>(()=>CoinPlanning.MinimumCoins(new[]{0},0));Reject<ArgumentException>(()=>CoinPlanning.MinimumCoins(new[]{-1},5));Reject<ArgumentOutOfRangeException>(()=>CoinPlanning.MinimumCoins(new[]{1},1_000_001));
Reject<ArgumentException>(()=>SubsetPlanning.FindSubset(new int[129],0));Reject<ArgumentOutOfRangeException>(()=>SubsetPlanning.FindSubset(new[]{1},1,maxCalls:0));
Reject<InvalidOperationException>(()=>SubsetPlanning.FindSubset(new[]{2,2,2},3,false,false,1));
Reject<ArgumentOutOfRangeException>(()=>ChoicePlanning.Subsets(17));Reject<ArgumentOutOfRangeException>(()=>ChoicePlanning.Permutations(9));
Console.WriteLine("600 coin references, 600 signed subset references, 93 Fibonacci states, enumeration checks, and boundaries passed.");
void Check(bool condition,string message){if(!condition)throw new Exception(message);}
void Reject<T>(Action action)where T:Exception{try{action();}catch(T){return;}throw new Exception("Expected "+typeof(T).Name);}

public static class FibPlanning
{
    public record FibResult(long Value,int Calls,int Hits,int Computed);
    // F(0)=0, F(1)=1. F(92) is the last value representable by long.
    public static FibResult Fibonacci(int n,bool memoized=true)
    {
        if(n<0||n>92||(!memoized&&n>25))throw new ArgumentOutOfRangeException(nameof(n));
        var cache=new Dictionary<int,long>();int calls=0,hits=0,computed=0;
        long Solve(int k)
        {
            calls++;
            if(k<=1)return k;
            if(memoized&&cache.TryGetValue(k,out long saved)){hits++;return saved;}
            long value=checked(Solve(k-1)+Solve(k-2));computed++;
            if(memoized)cache[k]=value;
            return value;
        }
        return new FibResult(Solve(n),calls,hits,computed);
    }
    public static long[] FibonacciTable(int n)
    {
        if(n<0||n>92)throw new ArgumentOutOfRangeException(nameof(n));
        var table=new long[n+1];if(n>=1)table[1]=1;
        for(int i=2;i<=n;i++)table[i]=checked(table[i-1]+table[i-2]);
        return table;
    }
    public static long FibonacciRolling(int n)
    {
        if(n<0||n>92)throw new ArgumentOutOfRangeException(nameof(n));
        if(n==0)return 0;
        long before=0,current=1;
        for(int i=2;i<=n;i++)(before,current)=(current,checked(before+current));
        return current;
    }
}
public static class CoinPlanning
{
    public record CoinPlan(int? Count,int[] Coins,int?[] Best);
    // Unlimited positive denominations. A target cap bounds table allocation.
    public static CoinPlan MinimumCoins(int[] denominations,int target)
    {
        ArgumentNullException.ThrowIfNull(denominations);
        if(target<0||target>1_000_000)throw new ArgumentOutOfRangeException(nameof(target));
        if(denominations.Any(c=>c<=0))throw new ArgumentException("Coins must be positive.");
        int[] coins=denominations.Distinct().OrderBy(c=>c).ToArray();
        var best=new int?[target+1];var last=new int[target+1];best[0]=0;
        for(int amount=1;amount<=target;amount++)
        {
            foreach(int coin in coins)
            {
                if(coin>amount)break;
                if(best[amount-coin] is not int count)continue;
                int candidate=count+1;
                if(best[amount] is null||candidate<best[amount])
                {best[amount]=candidate;last[amount]=coin;}
            }
        }
        var chosen=new List<int>();
        if(best[target] is not null)
            for(int remaining=target;remaining>0;remaining-=last[remaining])chosen.Add(last[remaining]);
        return new CoinPlan(best[target],chosen.ToArray(),best);
    }
}
public static class SubsetPlanning
{
    public record SubsetResult(int[]? Indices,int Calls,int Hits,int Prunes,int FailedStates);
    // Signed values are allowed; positions are distinct and each is used once.
    public static SubsetResult FindSubset(int[] values,long target,bool prune=true,bool memoize=true,int maxCalls=1_000_000)
    {
        ArgumentNullException.ThrowIfNull(values);
        if(values.Length>128)throw new ArgumentException("At most 128 positions in this teaching implementation.");
        if(maxCalls<1)throw new ArgumentOutOfRangeException(nameof(maxCalls));
        int[] data=(int[])values.Clone();int n=data.Length;
        var lower=new long[n+1];var upper=new long[n+1];
        for(int i=n-1;i>=0;i--)
        {lower[i]=lower[i+1]+Math.Min(0,data[i]);upper[i]=upper[i+1]+Math.Max(0,data[i]);}
        var failed=new HashSet<(int Index,long Remaining)>();var chosen=new List<int>();
        int calls=0,hits=0,prunes=0;int[]? answer=null;
        bool Search(int index,long remaining)
        {
            if(calls==maxCalls)throw new InvalidOperationException("Search budget exhausted; feasibility is unknown.");
            calls++;
            if(remaining==0){answer=chosen.ToArray();return true;}
            if(index==n)return false;
            if(prune&&(remaining<lower[index]||remaining>upper[index])){prunes++;return false;}
            var state=(index,remaining);
            if(memoize&&failed.Contains(state)){hits++;return false;}
            chosen.Add(index);bool found;
            try{found=Search(index+1,remaining-data[index]);}
            finally{chosen.RemoveAt(chosen.Count-1);}
            if(found||Search(index+1,remaining))return true;
            if(memoize)failed.Add(state);
            return false;
        }
        // Even an unpruned trace rejects targets outside the total signed range.
        if(target<lower[0]||target>upper[0]){calls=1;prunes=1;}
        else Search(0,target);
        if(chosen.Count!=0)throw new InvalidOperationException("Undo failed.");
        return new SubsetResult(answer,calls,hits,prunes,failed.Count);
    }
}
public static class ChoicePlanning
{
    public static int[][] Subsets(int n)
    {
        if(n<0||n>16)throw new ArgumentOutOfRangeException(nameof(n));
        var result=new List<int[]>();var chosen=new List<int>();
        void Visit(int index)
        {
            if(index==n){result.Add(chosen.ToArray());return;}
            chosen.Add(index);Visit(index+1);chosen.RemoveAt(chosen.Count-1);
            Visit(index+1);
        }
        Visit(0);return result.ToArray();
    }
    public static int[][] Permutations(int n)
    {
        if(n<0||n>8)throw new ArgumentOutOfRangeException(nameof(n));
        var result=new List<int[]>();var chosen=new List<int>();var used=new bool[n];
        void Visit()
        {
            if(chosen.Count==n){result.Add(chosen.ToArray());return;}
            for(int i=0;i<n;i++)
            {
                if(used[i])continue;
                used[i]=true;chosen.Add(i);Visit();chosen.RemoveAt(chosen.Count-1);used[i]=false;
            }
        }
        Visit();return result.ToArray();
    }
}
