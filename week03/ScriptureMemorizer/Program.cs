
using ScriptureMemorizer;

string dataPath = "scriptures.txt";
var library = new ScriptureLibrary(dataPath);
Scripture scripture = library.GetRandomScripture();

int round = 0;

while (true)
{
    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
    Console.WriteLine();

    if (scripture.IsCompletelyHidden())
    {
        break;
    }

    Console.Write("Press Enter to continue, or type 'quit' to end: ");
    string? input = Console.ReadLine();

    if (string.Equals(input?.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    round++;
    int wordsToHide = 2 + (round / 4); // gradually hide miore words each round
    scripture.HideRandomWords(wordsToHide);
}