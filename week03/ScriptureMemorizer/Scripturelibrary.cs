namespace ScriptureMemorizer;
 
/// Extra Credit:
/// This program can read scriptures from a text file.
/// Every time the program starts, it picks one scripture at random
/// instead of always using the same one.
///
/// The text file has one scripture on each line.
/// The parts are separated with a | symbol.
///
/// Format:
/// Book|Chapter|FirstVerse|LastVerse|ScriptureText
///
/// If the scripture is only one verse, leave LastVerse empty.
///
/// Example:
/// John|3|16||For God so loved the world...
/// Proverbs|3|5|6|Trust in the Lord with all thine heart...
public class ScriptureLibrary
{
    private readonly List<Scripture> _scriptures = new();
    private static readonly Random _random = new Random();
 
    public ScriptureLibrary(string filePath)
    {
        foreach (string line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
 
            string[] parts = line.Split('|');
            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int verseStart = int.Parse(parts[2]);
            string text = parts[4];
 
            Reference reference = string.IsNullOrWhiteSpace(parts[3])
                ? new Reference(book, chapter, verseStart)
                : new Reference(book, chapter, verseStart, int.Parse(parts[3]));
 
            _scriptures.Add(new Scripture(reference, text));
        }
    }
 
    public int Count => _scriptures.Count;
 
    public Scripture GetRandomScripture()
    {
        return _scriptures[_random.Next(_scriptures.Count)];
    }
}