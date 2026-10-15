var heap=new BinaryMinHeap<int>();var expected=new List<int>();var random=new Random(1901);int checks=0;
for(int step=0;step<600;step++)
{
    if(random.Next(3)>0){int value=random.Next(-20,21);heap.Enqueue(value);expected.Add(value);}
    else
    {
        expected.Sort();bool removed=heap.TryDequeue(out int actual);
        Check(removed==(expected.Count>0),"empty state");
        if(removed){Check(actual==expected[0],"minimum");expected.RemoveAt(0);}
    }
    Check(heap.Count==expected.Count && heap.IsValid(),"heap/count invariant");
}
Console.WriteLine($"{checks} heap checks passed.");
void Check(bool valid,string message){if(!valid)throw new Exception(message);checks++;}
