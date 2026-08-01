using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);

            // Stop if the activity time has expired
            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}