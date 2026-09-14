# Architecture

The browser-facing textbook will send code cells to
`POST /v1/tasks/{taskId}/execute`. The execution API combines the cells into
one temporary top-level C# program,
copies a pre-restored console project into a temporary directory, and invokes
`dotnet run --no-restore` inside the service container.

The service is local-first. Docker provides the process boundary, a read-only
root filesystem, a non-root user, a no-new-privileges policy, a temporary
filesystem, a process limit, a memory limit, and a fifteen-second execution
limit. The service is bound to `127.0.0.1` and is not a public code runner.

The execution layer is intentionally separate from the Jupyter Book build and
does not depend on Binder, Jupyter, or .NET Interactive. The browser client
provides sample execution, editable sample copies, and inline exercise editing.

## Authentication and persistence

The API now includes a first database-backed account layer:

- SQLite stores local development accounts.
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
authenticated user whose email appears in `CSCS_ADMIN_EMAILS`. Browser author
controls and Git publish automation are the next integration steps.

During the Jupyter Book build, `_ext/notebook_cell_metadata.py` annotates
rendered code cells with their source notebook cell ID, index, and type. The
browser authoring layer uses this metadata to map rendered cells back to the
original `.ipynb` safely instead of relying on DOM order. Code-cell mapping is
implemented first; markdown-cell boundary mapping remains a follow-up.

## Future production work

Before public deployment, replace development SQLite with a server database or
deliberate managed SQLite strategy, add migrations and backups, implement email
verification and password recovery through IONOS SMTP, add rate limits and
stronger execution isolation, and define a controlled Git commit/publish
workflow.
