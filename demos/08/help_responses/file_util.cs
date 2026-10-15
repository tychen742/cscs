using System.Text;

namespace IntroCS;

public class FileUtil
{
    public static string ReadParagraph(StreamReader reader)
    {
        var result = new StringBuilder();
        string? line;
        while ((line = reader.ReadLine()) != null && !string.IsNullOrWhiteSpace(line))
            result.AppendLine(line);
        return result.ToString();
    }

    public static List<string> GetParagraphs(StreamReader reader)
    {
        var paragraphs = new List<string>();
        while (!reader.EndOfStream)
        {
            string paragraph = ReadParagraph(reader);
            if (paragraph.Length > 0) paragraphs.Add(paragraph);
        }
        return paragraphs;
    }

    public static Dictionary<string, string> GetDictionary(StreamReader reader)
    {
        var responses = new Dictionary<string, string>();
        string? key;
        while ((key = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(key)) continue;
            string value = ReadParagraph(reader);
            responses.Add(key.Trim(), value);
        }
        return responses;
    }
}
