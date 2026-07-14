namespace ScriptureMemorizer;


public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verseStart;
    private readonly int? _verseEnd;

   
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public override string ToString()
    {
        return _verseEnd.HasValue
            ? $"{_book} {_chapter}:{_verseStart}-{_verseEnd}"
            : $"{_book} {_chapter}:{_verseStart}";
    }
}