public class Fraction
{
    private int _top;
    private int _bottom;

    // Construct 1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Construct 2
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Construct 3
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    
    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    //breuk cijfer
    public string GetFractionString()
    {
        return _top + "/" + _bottom;
    }

    // Decimal cijfer
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}