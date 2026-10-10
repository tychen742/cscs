using System;
using System.Linq;
using System.Collections.Generic;

var tree = new TicketTree();
var model = new SortedSet<int>();
void Check()
{
    if (!tree.IsValid() || tree.Count != model.Count || !tree.InOrder().SequenceEqual(model))
        throw new Exception("Membership/invariant mismatch.");
    bool found = tree.TryMinimum(out int minimum);
    if (found != (model.Count > 0) || (found && minimum != model.Min))
        throw new Exception("Minimum mismatch.");
    if (tree.Height < -1 || (tree.Count == 0 && tree.Height != -1))
        throw new Exception("Height boundary mismatch.");
}
void Add(int id)
{
    if (tree.Add(id) != model.Add(id)) throw new Exception("Add result mismatch.");
    Check();
}
void Remove(int id)
{
    if (tree.Remove(id) != model.Remove(id)) throw new Exception("Remove result mismatch.");
    Check();
}
Check(); Remove(0);
Add(0); Add(0); Remove(0); Remove(0);
Add(int.MinValue); Add(int.MaxValue); Remove(int.MinValue); Remove(int.MaxValue);
// Successor has a right child: 10 must be replaced with 11 in the old location.
foreach (int id in new[] { 8, 3, 12, 1, 6, 10, 14, 11 }) Add(id);
Remove(8);
if (!tree.Contains(11)) throw new Exception("Successor child lost.");
foreach (int id in model.ToArray()) Remove(id);
// Root with only a left child, then only a right child.
Add(2); Add(1); Remove(2); Remove(1);
Add(1); Add(2); Remove(1); Remove(2);
var random = new Random(1705);
for (int step = 0; step < 600; step++)
{
    int id = random.Next(-60, 61);
    switch (random.Next(3))
    {
        case 0: Add(id); break;
        case 1: Remove(id); break;
        default:
            if (tree.Contains(id) != model.Contains(id)) throw new Exception("Search mismatch.");
            Check(); break;
    }
}
foreach (int id in model.ToArray()) Remove(id);
Add(42); Remove(42); Check();
// Construction costs are shape dependent; verify the chapter's height convention.
var chain = new TicketTree();
foreach (int id in Enumerable.Range(1, 20)) chain.Add(id);
if (chain.Height != 19) throw new Exception("Chain height mismatch.");
Console.WriteLine("600 mixed operations and explicit tree boundary checks passed.");

public class TicketTree
{
    private Node? root;
    public int Count { get; private set; }
    public int Height => NodeHeight(root);

    public bool Add(int id)
    {
        bool added = false;
        root = Insert(root, id, ref added);
        if (added) Count++;
        return added;
    }

    public bool Contains(int id)
    {
        Node? current = root;
        while (current is not null)
        {
            if (id == current.Id) return true;
            current = id < current.Id ? current.Left : current.Right;
        }
        return false;
    }

    public bool Remove(int id)
    {
        bool removed = false;
        root = Delete(root, id, ref removed);
        if (removed) Count--;
        return removed;
    }

    public bool TryMinimum(out int id)
    {
        if (root is null) { id = default; return false; }
        id = Minimum(root).Id;
        return true;
    }

    public List<int> InOrder()
    {
        var ids = new List<int>();
        Visit(root, ids);
        return ids;
    }

    public bool IsValid() => Validate(root, long.MinValue, long.MaxValue);

    private static Node Insert(Node? node, int id, ref bool added)
    {
        if (node is null) { added = true; return new Node(id); }
        if (id < node.Id) node.Left = Insert(node.Left, id, ref added);
        else if (id > node.Id) node.Right = Insert(node.Right, id, ref added);
        return node;
    }

    private static Node? Delete(Node? node, int id, ref bool removed)
    {
        if (node is null) return null;
        if (id < node.Id) node.Left = Delete(node.Left, id, ref removed);
        else if (id > node.Id) node.Right = Delete(node.Right, id, ref removed);
        else
        {
            removed = true;
            if (node.Left is null) return node.Right;
            if (node.Right is null) return node.Left;
            Node successor = Minimum(node.Right);
            node.Id = successor.Id;
            bool successorRemoved = false;
            node.Right = Delete(node.Right, successor.Id, ref successorRemoved);
        }
        return node;
    }

    private static Node Minimum(Node node)
    {
        while (node.Left is not null) node = node.Left;
        return node;
    }

    private static void Visit(Node? node, List<int> ids)
    {
        if (node is null) return;
        Visit(node.Left, ids);
        ids.Add(node.Id);
        Visit(node.Right, ids);
    }

    private static int NodeHeight(Node? node) => node is null ? -1
        : 1 + Math.Max(NodeHeight(node.Left), NodeHeight(node.Right));

    private static bool Validate(Node? node, long lower, long upper)
    {
        if (node is null) return true;
        return lower < node.Id && node.Id < upper
            && Validate(node.Left, lower, node.Id)
            && Validate(node.Right, node.Id, upper);
    }

    private class Node
    {
        public int Id { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public Node(int id) => Id = id;
    }
}
