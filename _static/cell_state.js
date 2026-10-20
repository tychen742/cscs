/*
 * ThinkPress reader cell state: "the reader's book".
 *
 * A book-agnostic store for what a reader did with each runnable code cell: the code they
 * last ran and its result. It touches no DOM and knows nothing about the runner, so any
 * ThinkPress book (this C# runner, or a thebe-based Python kernel) can load this file and
 * create a store for its own slug. Press later syncs the same records per book slug.
 *
 * Storage: localStorage, one key per page
 *     thinkpress:cellState:<book>:<pageUrl>   ->   { [cellId]: record }
 *
 * Record shape (the only shape this store reads or writes):
 *     {
 *       book:     string         book slug, e.g. "cscs"
 *       pageUrl:  string         location.pathname of the page (no query or hash)
 *       cellId:   string         the cell's stable id within the page
 *       ranAt:    string         ISO 8601 UTC time of the run (or of a later Reset, which
 *                                keeps the record but forgets its code and output)
 *       exitCode: number | null  runner exit code; null when the request itself failed
 *       output:   string         stdout and stderr of the run, capped at 8 KB
 *       code:     string         the editor's code at the time of the run, capped at 16 KB
 *       edited:   boolean        code differs from the book's code for that cell
 *       ownRanAt: string | null  ISO 8601 UTC time the reader last ran the cell on its own
 *                                (its Run button); null when it only ran in a Run all.
 *                                Drives the "ran" mark; Run all keeps the earlier value.
 *     }
 *
 * window.thinkpressCellState.create({ book }) returns a store:
 *     list(pageUrl)          -> record[]
 *     get(pageUrl, cellId)   -> record | null
 *     set(record)            -> the stored record (capped; book filled in from the store)
 *     remove(pageUrl, cellId)
 *     onChange(callback)     -> unsubscribe function; callback({ type, book, pageUrl, cellId, record })
 *                               type is "set", "remove", or "external" (another tab changed the page)
 *     book                   -> the store's slug
 *
 * A Press sync follows the reading-progress pattern (localStorage first, Press when the
 * reader is signed in): read with list()/get(), write remote records back with set()/
 * remove(), and subscribe with onChange() to push local runs upstream. Page scripts
 * re-read their records after any change, so synced records show up without a reload.
 * The C# book's execution.js does this with Press's /api/cell-output/cscs: it posts each
 * run and, on load, set()s any saved output newer than the local record.
 */
(function installThinkpressCellState() {
    if (window.thinkpressCellState) return;

    const KEY_PREFIX = "thinkpress:cellState:";
    const OUTPUT_CAP = 8 * 1024;
    const CODE_CAP = 16 * 1024;

    function create({ book, storage } = {}) {
        if (typeof book !== "string" || !book) {
            throw new TypeError("thinkpressCellState.create needs a book slug.");
        }
        const store = storage || safeLocalStorage();
        const prefix = `${KEY_PREFIX}${book}:`;
        const listeners = new Set();

        function storageKey(pageUrl) {
            return prefix + pageUrl;
        }

        function readPage(pageUrl) {
            try {
                const parsed = JSON.parse(store.getItem(storageKey(pageUrl)) || "{}");
                return parsed && typeof parsed === "object" && !Array.isArray(parsed) ? parsed : {};
            } catch (_) {
                return {};
            }
        }

        function writePage(pageUrl, records) {
            try {
                if (Object.keys(records).length) {
                    store.setItem(storageKey(pageUrl), JSON.stringify(records));
                } else {
                    store.removeItem(storageKey(pageUrl));
                }
                return true;
            } catch (_) {
                // Private browsing or a full quota: the page still runs, it just forgets.
                return false;
            }
        }

        function emit(event) {
            listeners.forEach((listener) => {
                try {
                    listener(event);
                } catch (error) {
                    console.error(error);
                }
            });
        }

        function normalize(record) {
            if (!record || typeof record.pageUrl !== "string" || typeof record.cellId !== "string") {
                throw new TypeError("A cell record needs string pageUrl and cellId fields.");
            }
            if (record.book !== undefined && record.book !== book) {
                throw new TypeError(`This store holds records for "${book}", not "${record.book}".`);
            }
            const code = typeof record.code === "string" ? record.code : "";
            const output = typeof record.output === "string" ? record.output : "";
            return {
                book,
                pageUrl: record.pageUrl,
                cellId: record.cellId,
                ranAt: typeof record.ranAt === "string" ? record.ranAt : new Date().toISOString(),
                exitCode: Number.isInteger(record.exitCode) ? record.exitCode : null,
                output: output.length > OUTPUT_CAP ? output.slice(0, OUTPUT_CAP) : output,
                code: code.length > CODE_CAP ? code.slice(0, CODE_CAP) : code,
                edited: Boolean(record.edited),
                ownRanAt: typeof record.ownRanAt === "string" ? record.ownRanAt : null
            };
        }

        window.addEventListener("storage", (event) => {
            if (!event.key || !event.key.startsWith(prefix)) return;
            emit({ type: "external", book, pageUrl: event.key.slice(prefix.length), cellId: null, record: null });
        });

        return {
            book,
            list(pageUrl) {
                return Object.values(readPage(pageUrl));
            },
            get(pageUrl, cellId) {
                return readPage(pageUrl)[cellId] || null;
            },
            set(record) {
                const stored = normalize(record);
                const records = readPage(stored.pageUrl);
                records[stored.cellId] = stored;
                writePage(stored.pageUrl, records);
                emit({ type: "set", book, pageUrl: stored.pageUrl, cellId: stored.cellId, record: stored });
                return stored;
            },
            remove(pageUrl, cellId) {
                const records = readPage(pageUrl);
                if (!(cellId in records)) return;
                delete records[cellId];
                writePage(pageUrl, records);
                emit({ type: "remove", book, pageUrl, cellId, record: null });
            },
            onChange(callback) {
                listeners.add(callback);
                return () => listeners.delete(callback);
            }
        };
    }

    // localStorage can throw on access (blocked storage); fall back to a per-page memory store.
    function safeLocalStorage() {
        try {
            if (window.localStorage) return window.localStorage;
        } catch (_) {
            // fall through
        }
        const memory = new Map();
        return {
            getItem: (key) => (memory.has(key) ? memory.get(key) : null),
            setItem: (key, value) => memory.set(key, String(value)),
            removeItem: (key) => memory.delete(key)
        };
    }

    window.thinkpressCellState = { create, KEY_PREFIX, OUTPUT_CAP, CODE_CAP };
})();
