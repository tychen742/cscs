// Trace: step records for the book's algorithm stepper (_static/trace_viewer.js).
//
// The runner template compiles this file next to every cell, so a cell can call
// Trace.Array(...) without declaring anything. Each Step writes one line to standard
// output in the form
//
//     @@trace {"t":"array","v":[8,4,8,2],"hi":[1],"marks":{"sorted":[0]},"vars":{"saved":4},"msg":"pass i = 1: save 4"}
//
// The page strips those lines from the printed output and renders them as a stepper
// (Previous, Next, slider), so the picture the reader steps through comes from the
// values their own program held at that moment. Record fields:
//
//     t      the kind of picture; "array" is the only kind so far
//     v      the array's values in index order (numbers, or strings for other types)
//     hi     indexes drawn in the accent color (the elements being compared or moved)
//     marks  label -> indexes carrying that label ("sorted", "low", "mid", "high", ...);
//            an index equal to v.Length is allowed, for a half-open bound one past the end
//     range  [low, high): the candidate region of a search; slots outside it are dimmed
//     vars   named values to show beside the picture (a saved element, the target, ...)
//     msg    the sentence for this step
//
// Usage from a cell:
//
//     Trace.Array(values, "start");
//     Trace.Array(values).Highlight(j, j + 1).Mark("sorted", 0, i).Var("saved", saved).Step("shift right");
//     Trace.Array(values).Range(low, high).Mark("mid", middle).Step($"compare {values[middle]}");
//
// Copy this file into a VS Code project to run a traced cell there; the lines then
// simply print.

using System.Text.Encodings.Web;
using System.Text.Json;

public static class Trace
{
    public const string Prefix = "@@trace ";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    /// <summary>Start an array step; finish it with Step(message).</summary>
    public static ArrayStep Array<T>(IEnumerable<T> values) => new(values.Select(value => (object)value));

    /// <summary>Record an array step with a message and no highlights.</summary>
    public static void Array<T>(IEnumerable<T> values, string message) => Array(values).Step(message);

    public sealed class ArrayStep
    {
        private readonly List<object> values = new();
        private readonly List<int> highlights = new();
        private readonly Dictionary<string, List<int>> marks = new();
        private readonly Dictionary<string, object> variables = new();
        private int[] range;

        internal ArrayStep(IEnumerable<object> source)
        {
            foreach (var value in source) values.Add(Plain(value));
        }

        /// <summary>Draw these indexes in the accent color.</summary>
        public ArrayStep Highlight(params int[] indexes)
        {
            highlights.AddRange(indexes);
            return this;
        }

        /// <summary>Put a label under one index. The index may equal the length (one past the end).</summary>
        public ArrayStep Mark(string label, int index) => Mark(label, index, index);

        /// <summary>Put a label under the indexes from <paramref name="from"/> through <paramref name="to"/> inclusive. Nothing is marked when from > to.</summary>
        public ArrayStep Mark(string label, int from, int to)
        {
            if (from > to) return this;
            if (!marks.TryGetValue(label, out var indexes)) marks[label] = indexes = new List<int>();
            for (int i = from; i <= to; i++) indexes.Add(i);
            return this;
        }

        /// <summary>The half-open candidate region [low, high); slots outside it are dimmed.</summary>
        public ArrayStep Range(int low, int high)
        {
            range = new[] { low, high };
            return this;
        }

        /// <summary>Show a named value beside the picture.</summary>
        public ArrayStep Var(string name, object value)
        {
            variables[name] = Plain(value);
            return this;
        }

        /// <summary>Print the record for this step.</summary>
        public void Step(string message)
        {
            var record = new Dictionary<string, object> { ["t"] = "array", ["v"] = values };
            if (highlights.Count > 0) record["hi"] = highlights;
            if (marks.Count > 0) record["marks"] = marks;
            if (range is not null) record["range"] = range;
            if (variables.Count > 0) record["vars"] = variables;
            record["msg"] = message ?? string.Empty;
            Console.WriteLine(Prefix + JsonSerializer.Serialize(record, JsonOptions));
        }

        // Numbers and booleans stay JSON numbers and booleans; everything else is shown as text.
        private static object Plain(object value) => value switch
        {
            null => "null",
            int or long or short or byte or double or float or decimal or bool => value,
            _ => value.ToString()
        };
    }
}
