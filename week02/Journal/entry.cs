using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _quote;


    public void Display()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Quote of the Day: {_quote}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine("----------------------------");
        Console.WriteLine();
    }
}