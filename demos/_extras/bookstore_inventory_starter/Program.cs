using Microsoft.Data.Sqlite;

int checks = 0;
string database = args.Any(a => a is "--check" or "--check-core") ? ":memory:" : "bookstore.db";
using var connection = new SqliteConnection($"Data Source={database}");
connection.Open();
using (var setup = connection.CreateCommand())
{
    setup.CommandText = """
        PRAGMA foreign_keys = ON;
        CREATE TABLE IF NOT EXISTS Books (
            BookId INTEGER PRIMARY KEY,
            Title TEXT NOT NULL,
            PriceCents INTEGER NOT NULL CHECK (PriceCents >= 0),
            Stock INTEGER NOT NULL CHECK (Stock >= 0)
        );
        CREATE TABLE IF NOT EXISTS Sales (
            SaleId INTEGER PRIMARY KEY,
            BookId INTEGER NOT NULL REFERENCES Books(BookId),
            Quantity INTEGER NOT NULL CHECK (Quantity > 0)
        );
        INSERT OR IGNORE INTO Books VALUES (1, 'C# for Business', 2500, 8);
        INSERT OR IGNORE INTO Books VALUES (2, 'Data at Work', 3200, 3);
        """;
    setup.ExecuteNonQuery();
}
var inventory = new Inventory(connection);
if (args.Any(a => a is "--check" or "--check-core"))
{
    Check(inventory.List().Count == 2, "seed count");
    Check(inventory.Find(1)?.Title == "C# for Business", "find known book");
    Check(inventory.Find(999) is null, "missing book");
    long id = inventory.Add("Manager's SQL Guide", 1900, 4);
    Check(inventory.Find(id)?.Title == "Manager's SQL Guide", "parameterized title");
    Check(inventory.SetStock(id, 6), "update stock");
    Check(inventory.Find(1)?.Stock == 8, "other book unchanged");
    Check(!inventory.SetStock(999, 2), "missing update");
    foreach (Action invalid in new Action[] {
        () => inventory.Add("", 100, 1), () => inventory.Add("Bad", -1, 1),
        () => inventory.SetStock(id, -1), () => inventory.Add("Bad", 100, -1) })
    {
        bool rejected = false;
        try { invalid(); } catch (ArgumentException) { rejected = true; }
        Check(rejected, "invalid input rejected");
    }
    if (args.Contains("--check-core"))
    {
        Console.WriteLine($"{checks} core inventory checks passed.");
        return;
    }
    Check(inventory.Sell(id, 2), "successful sale");
    Check(inventory.Find(id)?.Stock == 4, "sale reduces stock");
    Check(!inventory.Sell(id, 5), "overselling rejected");
    Check(!inventory.Sell(999, 1), "missing sale rejected");
    Check(inventory.Find(id)?.Stock == 4, "rejection preserves stock");
    using var count = connection.CreateCommand();
    count.CommandText = "SELECT COUNT(*) FROM Sales;";
    Check(Convert.ToInt64(count.ExecuteScalar()) == 1, "only successful sale recorded");
    using (var trigger = connection.CreateCommand())
    {
        trigger.CommandText = "CREATE TRIGGER FailSale BEFORE INSERT ON Sales BEGIN SELECT RAISE(ABORT, 'simulated failure'); END;";
        trigger.ExecuteNonQuery();
    }
    bool failed = false;
    try { inventory.Sell(id, 1); } catch (SqliteException) { failed = true; }
    Check(failed, "sale insert failure surfaced");
    Check(inventory.Find(id)?.Stock == 4, "failed insert rolls stock back");
    Console.WriteLine($"{checks} inventory checks passed.");
}
else
{
    foreach (Book book in inventory.List())
        Console.WriteLine($"{book.Id}: {book.Title}, {book.PriceCents / 100m:C2}, stock={book.Stock}");
}

void Check(bool condition, string message)
{
    if (!condition) throw new Exception($"Check failed: {message}");
    checks++;
}

public sealed class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public int PriceCents { get; set; }
    public int Stock { get; set; }
}

public sealed class Inventory
{
    private readonly SqliteConnection connection;

    public Inventory(SqliteConnection connection)
    {
        this.connection = connection;
    }

    public List<Book> List() => throw new NotImplementedException("Task 1: list inventory");
    public Book? Find(long id) => throw new NotImplementedException("Task 2: find a book");
    public long Add(string title, int priceCents, int stock) => throw new NotImplementedException("Task 3: add a title");
    public bool SetStock(long id, int stock) => throw new NotImplementedException("Task 4: update stock");
    public bool Sell(long id, int quantity) => throw new NotImplementedException("Task 5 extension: atomic sale");
    private static Book ReadBook(SqliteDataReader reader) => throw new NotImplementedException("Task 1: map columns");
}
