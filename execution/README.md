# C# execution service

This local service executes textbook code cells in a Docker-isolated .NET SDK
container. It does not use Binder or .NET Interactive. Each chapter activity
can use a separate task ID. The execution requirements are documented in
`REQUIREMENTS.md`.

## Run locally

From this directory:

```bash
docker compose -f compose.yml up --build -d
```

Check the service:

```bash
curl http://127.0.0.1:8080/health
```

Execute one cell:

```bash
curl -s http://127.0.0.1:8080/v1/tasks/ch06-regex/execute \
  -H 'Content-Type: application/json' \
  -d '{"code":"int answer = 6 * 7; Console.WriteLine(answer);"}'
```

Execute stateful cells together:

```bash
curl -s http://127.0.0.1:8080/v1/tasks/ch06-regex/execute \
  -H 'Content-Type: application/json' \
  -d '{"cells":["int answer = 6 * 7;", "Console.WriteLine(answer);"]}'
```

Stop the service with:

```bash
docker compose -f compose.yml down
```

The service is bound to localhost for development. It must not be exposed
publicly until authentication, rate limiting, stronger per-execution isolation,
and a production deployment design have been added.

The development Compose setup stores the SQLite database in the named
`cscs-data` volume. Do not use SQLite as the eventual multi-instance
production database without a deliberate migration to a server database.

## Authentication API

The initial database-backed account flow is:

```text
POST /v1/auth/register  create an account
POST /v1/auth/login     create an HTTP-only cookie session
GET  /v1/auth/me        return the current authenticated user
POST /v1/auth/logout    clear the session
```

Passwords are stored as PBKDF2 hashes, never plaintext. SQLite stores the
development account data, and ASP.NET data-protection keys are persisted in the
same volume so sessions survive API container restarts.

## Notebook validation

The first authoring endpoint validates notebook structure before any future save:

```text
POST /v1/admin/notebooks/validate
```

Send the notebook JSON as the request body. It checks JSON syntax, notebook
format fields, the cells array, cell types, and source values. File writes and
Git backup/rollback will be added only after this validation boundary.

The next database phase is to add exercise drafts and assignment records keyed
to authenticated users. The eventual production deployment should migrate the
application data to a server database and add migrations, backups, role
management, rate limits, and account recovery before public release.

## Admin notebook save

Set `CSCS_ADMIN_EMAILS` to a comma-separated list of trusted administrator
emails. After login, an administrator can call:

```text
POST /v1/admin/notebooks/save
```

with `{ "path": "chapters/08-collections/0802-list.ipynb", "content": "..." }`.
The API validates the notebook, restricts writes to `chapters/**/*.ipynb`,
copies the existing file to the backup directory, and atomically replaces it.
The book root is mounted at `/workspace` in development; backups are stored in
the persistent Docker volume.

The matching source endpoint is:

```text
GET /v1/admin/notebooks/source?path=chapters/08-collections/0802-list.ipynb
```

Both endpoints require an authenticated email listed in `CSCS_ADMIN_EMAILS`.
The book build adds stable `data-cscs-cell-id` and `data-cscs-cell-index`
attributes through `_ext/notebook_cell_metadata.py`, allowing the browser
editor to map rendered code cells back to the original notebook.

## SMTP configuration

IONOS configuration is represented in `.env.example`. Copy it to `.env` and
set `SMTP_PASSWORD` locally; Docker Compose reads the values from that file.
The real `.env` file must never be committed. Use server or deployment secrets
for the password in production.
