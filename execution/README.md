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

The current runner executes submitted C# inside the API service container. This
is acceptable for the local-first development model, but it is not an adequate
student-facing public sandbox. A production deployment should move code
execution into separate isolated runner workers with no repository mount, no
application secrets, no database access, strict resource limits, and a bounded
queue or worker pool.

The Compose setup runs Postgres as a sibling `postgres` service, with data in
the named `cscs-postgres-data` volume. Schema changes go through EF Core
Migrations (`dotnet ef migrations add ...`); the API applies pending
migrations automatically at startup via `Database.Migrate()`.

## Authentication API

The initial database-backed account flow is:

```text
POST /v1/auth/register  create an account
POST /v1/auth/login     create an HTTP-only cookie session
POST /v1/auth/email-verification/confirm  verify a new account email
POST /v1/auth/password-reset/request   create and email a password reset link
POST /v1/auth/password-reset/complete  set a new password from a reset token
GET  /v1/auth/me        return the current authenticated user
POST /v1/auth/logout    clear the session
```

Passwords are stored as PBKDF2 hashes, never plaintext. Postgres stores
account data, and ASP.NET data-protection keys are persisted in the `cscs-data`
volume so sessions survive API container restarts.

Password reset tokens are stored only as SHA-256 hashes and expire after 2
hours. If SMTP is configured, the API emails the reset link. In development,
or when `CSCS_EXPOSE_PASSWORD_RESET_LINKS=true`, the request endpoint also
returns the reset token/link so the browser modal can be tested without email.
New accounts must verify their email address before sign-in. Verification
tokens are also stored only as SHA-256 hashes and expire after 2 days.

## Reading progress API

Anonymous reading continuity is stored in the browser with `localStorage`.
Logged-in reading continuity is stored in Postgres and keyed to the
authenticated user:

```text
GET  /v1/progress/reading   return the user's last reading page
POST /v1/progress/reading   save page URL, title, scroll position, and timestamp
```

The authentication cookie identifies the user. The cookie does not store
reading progress; it only lets the API read and update the database record.

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

Authoring access is controlled by the `UserAccount.Role` enum in the database:
`Student`, `TA`, `Instructor`, `Editor`, `Author`, or `Admin`. Set
`CSCS_ADMIN_EMAILS` only as a bootstrap/emergency list for trusted
administrators before role management UI is available. After login, a user with
the `Admin`, `Author`, `Editor`, `Instructor`, or `TA` role can call:

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

Both endpoints require an authenticated user whose database role is `Admin`,
`Author`, `Editor`, `Instructor`, or `TA`. Emails listed in `CSCS_ADMIN_EMAILS`
are treated as effective admins as a bootstrap/emergency override.
The book build adds stable `data-cscs-cell-id` and `data-cscs-cell-index`
attributes through `_ext/notebook_cell_metadata.py`, allowing the browser
editor to map rendered code and markdown cells back to the original notebook.

## SMTP configuration

IONOS configuration is represented in `.env.example`. Copy it to `.env` and
set `SMTP_PASSWORD` locally; Docker Compose reads the values from that file.
The real `.env` file must never be committed. Use server or deployment secrets
for the password in production. Password reset email uses these same SMTP
settings. If SMTP is unavailable, set `CSCS_LOG_PASSWORD_RESET_LINKS=true`
temporarily to log reset links server-side for administrator-assisted recovery.
