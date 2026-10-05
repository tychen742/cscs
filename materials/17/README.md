# Chapter 17: Trees

`TicketTree.cs` contains the chapter's unique integer-key BST and a verification program. It includes search, insertion, all removal cases, Count, height, minimum lookup, inorder traversal, and ancestor-bound validation.

Create a console project, replace its `Program.cs` with this file, and run it:

```sh
dotnet new console -n TreeCheck
cp TicketTree.cs TreeCheck/Program.cs
dotnet run --project TreeCheck
```

Expected output:

```text
600 mixed operations and explicit tree boundary checks passed.
```

The checks compare with `SortedSet<int>` after each seeded operation and cover empty/singleton reuse, duplicate and missing updates, root replacement, a successor with a right child, both integer extremes, draining, and chain height. The tree is intentionally unbalanced. Recursive updates can exhaust the call stack on sufficiently long chains.
