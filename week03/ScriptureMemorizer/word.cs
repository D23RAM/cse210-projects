namespace ScriptureMemorizer;


public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

   
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        var hidden = new System.Text.StringBuilder();
        foreach (char c in _text)
        {
            hidden.Append(char.IsLetter(c) ? '_' : c);
        }
        return hidden.ToString();
    }
}