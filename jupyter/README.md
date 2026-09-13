# Local C# notebook server

The published book uses Thebe to connect to a local Jupyter Server. This
server provides the full .NET Interactive C# kernel without Binder or a
scripting-only browser runtime.

## Requirements

- Docker Desktop
- A browser that can open `https://thinkcscs.org`

## Start the kernel

From the repository root:

```bash
docker compose up --build -d
```

Open the book, activate its interactive mode, and run a C# cell. The server
runs only on `127.0.0.1:8888`; it is not published as a public execution
service. Stop it when finished:

```bash
docker compose down
```

To inspect the kernel registration or server logs:

```bash
docker compose exec csharp-kernel jupyter kernelspec list
docker compose logs -f csharp-kernel
```
