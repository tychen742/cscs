# Advanced graph traversal reference

Retained callback-, LINQ-, and record-based traversal implementation from the former core graph lesson. The taught Part V version is `demos/20_graphs/graph_traversal/`; use this longer frame-DFS reference only for optional algorithm depth. Copy its standalone source into a separate .NET 10 console project to run it.

## Automated Verification

From the repository root, run `python3 scripts/verify_demos.py`. The verifier copies this source unchanged into a temporary .NET 10 project and checks its output. The source remains available for optional exploration.

The final two output lines are:

```text
order=HQ,Warehouse,Helpdesk,Depot,Client
Client layer=2, Remote unreachable=True, arcs examined=6
```
