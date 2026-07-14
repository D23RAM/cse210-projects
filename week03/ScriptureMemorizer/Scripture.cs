namespace ScriptureMemorizer;


public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private static readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => new Word(w))
            .ToList();
    }

   
    public string GetDisplayText()
    {
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference}\n{words}";
    }


    public void HideRandomWords(int count)
    {
        List<Word> candidates = _words.Where(w => !w.IsHidden).ToList();

        int numberToHide = Math.Min(count, candidates.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            int index = _random.Next(candidates.Count);
            candidates[index].Hide();
            candidates.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}