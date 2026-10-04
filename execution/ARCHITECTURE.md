# Architecture

The service is split into three containers (`compose.yml`):

```text
Browser ─► Apache ─┬─ /cscs-exec/v1/tasks/* ─► cs-runner-gateway (127.0.0.1:8081) ─► cs-runner
                   │                               [default + runner networks]       [runner network only]
                   └─ /cscs-exec/* ─────────────► execution-api (127.0.0.1:8080) ─► postgres
```

- `cs-runner` (`runner/`) is the only place student code runs. It accepts
  `POST /v1/tasks/{taskId}/execute`, combines the cells into one temporary
  top-level C# program, copies a pre-restored console project into a temporary
  directory, and invokes `dotnet run --no-restore`. The student build starts
  from an allow-listed environment. The container has no volumes and no secrets,
  runs as UID 10001 (no host account), and sits on the internal `runner` network:
  no internet, DNS, database, account service, or host access. It also has a
  read-only root, a 256 MB `/tmp`, all capabilities dropped, `no-new-privileges`,
  `init`, and limits of 128 processes, 512 MB, and 1 CPU.
- `cs-runner-gateway` (`gateway/nginx.conf`) is an unprivileged nginx that
  forwards only `/v1/tasks/` and `/health` into `cs-runner`, because a container
  on an internal network cannot publish a port. It passes Apache's
  `X-Forwarded-For` through unchanged and runs no student code.
- `execution-api` keeps accounts, reading progress, and browser authoring. It
  holds the database and SMTP credentials and mounts the book workspace and an
  SSH directory for authoring commits; none of that is reachable from student code.

Run limits: at most two runs at once (queued, with a 20-second wait for guests),
an eight-second guest timeout, and 30 runs per minute per reader IP. Every reader
is a guest until Press issues signed run passes (see
`press/docs/PLATFORM_DECISIONS.md`); the runner holds no secret with which to check
a sign-in cookie.

Known limit: concurrent runs share one UID inside `cs-runner`, so a student program
can see or disturb another run in progress or crash the server process, which
restarts. Nothing sensitive is reachable, so the impact is disruption. Per-run users
or per-run containers are the next isolation step.

History: until 2026-10-04, student code ran inside `execution-api` and could read its
secrets and mounts. Run was blocked at Apache (`cscs-exec-block.conf`) until this
split was deployed.

The execution layer is intentionally separate from the Jupyter Book build and
does not depend on Binder, Jupyter, or .NET Interactive. The browser client
provides sample execution, editable sample copies, and inline exercise editing.

## Authentication and persistence

The API now includes a first database-backed account layer:

- Postgres stores accounts, applied via EF Core Migrations at startup.
- Passwords are stored as PBKDF2 hashes.
- Cookie sessions use persisted ASP.NET data-protection keys.
- Registration, login, current-user, and logout endpoints are available.
- Docker stores database files, protection keys, and notebook backups in a
	persistent named volume.

The database supports identity, roles, exercise drafts, assignment state, and
audit metadata. It does not replace Git or notebook files as the source of
truth for published book content.

## Admin authoring

The intended authoring workflow is a lightweight CMS layer over the existing
`.ipynb` files:

1. An authenticated administrator enables author mode in the browser.
2. Markdown and C# cell strings are edited inline.
3. C# cells can be executed immediately through the Docker runner.
4. The save API validates notebook JSON and restricts writes to
	 `chapters/**/*.ipynb`.
5. The existing notebook is backed up before atomic replacement.
6. Git remains responsible for synchronization, review, history, and rollback.

The current save endpoint is `POST /v1/admin/notebooks/save`. It requires an
authenticated user whose `UserAccount.Role` database enum is `Admin`, `Author`,
`Editor`, `Instructor`, or `TA`. Emails in `CSCS_ADMIN_EMAILS` are treated as
effective admins only as a bootstrap/emergency override. Browser author
controls expose markdown and code-cell editors only to those authoring roles.
The mounted book root for this API must be a Git checkout. Browser authoring
saves create ordinary Git working-tree changes in that checkout, and review,
commit, push, rebuild, and rollback all happen through Git.

The optional browser `Sync` action calls `POST /v1/admin/git/sync`, which
commits pending source changes, rebases on `origin/main`, and pushes to GitHub.
That container needs Git and GitHub credentials. The current deployment uses a
read-only host SSH mount and runs the API as the host checkout owner so SSH can
read the private key without relaxing key permissions. For source write access,
prefer a dedicated host group such as `cscs-authoring`; avoid `www-data` unless
the web server itself must write notebook sources.

GitHub Actions remains the production publishing path. On pushes to `main`, the
workflow builds the Jupyter Book, deploys the built HTML to `/var/www/cscs/`,
and then updates the server-side authoring checkout from `origin/main` when that
checkout is clean. If the checkout has unsynced browser-authored changes, the
workflow fails instead of overwriting them.

During the Jupyter Book build, `_ext/notebook_cell_metadata.py` annotates
rendered code and markdown cells with their source notebook cell ID, index, and
type. The browser authoring layer uses this metadata to map rendered cells back
to the original `.ipynb` safely instead of relying on DOM order.

## Future production work

Before public deployment, add automated Postgres backups (`pg_dump` or WAL
archiving) and a tested rollback path, implement email verification and
password recovery through IONOS SMTP, add rate limits and stronger execution
isolation through separate runner workers, and define a controlled Git
commit/publish workflow.
