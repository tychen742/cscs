# Architecture

CSCS execution is now split between Press and this repository:

```text
Browser -> Apache
  /cscs-exec/v1/tasks/* -> Press cs-runner-gateway (127.0.0.1:8081) -> Press cs-runner
  /cscs-exec/*          -> CSCS execution-api (127.0.0.1:8080)
```

- Press `cs-runner` (`/Users/tychen/workspace/press/runner/csharp`) is the only
  active place student C# code runs. It accepts
  `POST /v1/tasks/{taskId}/execute`, combines the cells into one temporary
  top-level C# program, copies a pre-restored console project into a temporary
  directory, and invokes `dotnet run --no-restore`. The student build starts
  from an allow-listed environment. The container has no volumes and no secrets,
  runs as UID 10001 (no host account), and sits on the internal `runner` network:
  no internet, DNS, database, account service, or host access. It also has a
  read-only root, a 256 MB `/tmp`, all capabilities dropped, `no-new-privileges`,
  `init`, and limits of 128 processes, 512 MB, and 1 CPU.
- Press `cs-runner-gateway` (`runner/csharp/gateway/nginx.conf`) is an unprivileged nginx that
  forwards only `/v1/tasks/` and `/health` into `cs-runner`, because a container
  on an internal network cannot publish a port. It passes Apache's
  `X-Forwarded-For` through unchanged and runs no student code.
- `execution-api` is the browser-authoring API (load, save, and commit notebooks).
  Accounts, sign-in, and reading progress live in Press; each authoring request carries
  a Press-signed author pass, checked with Press's public key by
  `shared/PressPassVerifier.cs` (also used by the runner). It mounts the book
  workspace and an SSH directory for authoring commits; none of that is reachable from
  student code. It has no database.
- The local `cs-runner` and `cs-runner-gateway` services in this directory are a
  legacy rollback path only. They are hidden behind the `legacy-runner` Compose
  profile and must not run at the same time as the Press gateway, because both
  gateways bind `127.0.0.1:8081`.

Run limits: at most two runs at once (queued, with a 20-second wait for guests),
an eight-second guest timeout, and 30 runs per minute per reader IP. A valid Press
run pass (`Authorization: Bearer`, checked against the public keys in
`CSCS_RUN_PASS_PUBLIC_KEYS`) gives the signed-in tier: priority, a fifteen-second
timeout, and 30 runs per minute per user. The runner holds only public keys, so code
inside it can verify passes but not create them. See `press/docs/RUN_PASSES.md`.

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

Press owns accounts, sign-in, reading progress, run passes, and durable learner
state. This service does not have a local learner database, local account model,
or local role table. Any future exercise draft, assignment, grading, or analytics
state should be added to Press instead of this directory.

## Admin authoring

The intended authoring workflow is a lightweight CMS layer over the existing
`.ipynb` files:

1. An authenticated author enables author mode in the browser.
2. Markdown and C# cell strings are edited inline.
3. C# cells can be executed immediately through the Press-owned C# runner.
4. The save API validates notebook JSON and restricts writes to
	 `chapters/**/*.ipynb`.
5. The existing notebook is backed up before atomic replacement.
6. Git remains responsible for synchronization, review, history, and rollback.

The current save endpoint is `POST /v1/admin/notebooks/save`. It requires an
authenticated Press-signed author pass, verified with the configured public
keys. Browser author controls expose markdown and code-cell editors only to
users who can obtain that author pass from Press. The mounted book root for this
API must be a Git checkout. Browser authoring saves create ordinary Git
working-tree changes in that checkout, and review, commit, push, rebuild, and
rollback all happen through Git.

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

Production hardening now belongs in two places:

- Press: automated Postgres backups, account recovery, assignment records,
  grading records, analytics, and runner orchestration.
- CSCS `execution-api`: a controlled authoring commit/publish workflow, clear
  rollback tooling, and continued validation that notebook writes stay inside
  the book checkout.
